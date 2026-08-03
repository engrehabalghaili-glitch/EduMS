using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace DiagramsUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            var dllPath = @"D:\EduMS-Unified-Workspace\01_Backend\EduMS.Backend\src\EduMS.Domain\bin\Debug\net10.0\EduMS.Domain.dll";
            var entitiesPath = @"D:\EduMS-Unified-Workspace\01_Backend\EduMS.Backend\src\EduMS.Domain\Entities";
            var htmlDir = @"D:\EduMS-Unified-Workspace\_DiagramsReview\03_Graduation_Docs\Diagrams_HTML_Project\01_ERD";

            if (!File.Exists(dllPath)) { Console.WriteLine("DLL not found"); return; }
            
            Assembly assembly;
            try { assembly = Assembly.LoadFrom(dllPath); } 
            catch (ReflectionTypeLoadException ex) { assembly = ex.Types.FirstOrDefault(t => t != null)?.Assembly; if(assembly==null) return; }

            var allTypes = assembly.GetTypes().Where(t => t != null && t.IsClass && !t.IsAbstract && t.Namespace != null && t.Namespace.StartsWith("EduMS.Domain.Entities")).ToList();
            var allTypeNames = allTypes.Select(t => t.Name).ToHashSet();

            // Map entities to modules by folder by scanning file contents for class/enum declarations
            var moduleEntities = new Dictionary<string, HashSet<string>>();
            foreach (var dir in Directory.GetDirectories(entitiesPath))
            {
                var modName = new DirectoryInfo(dir).Name;
                var classNames = new HashSet<string>();
                
                foreach (var file in Directory.GetFiles(dir, "*.cs"))
                {
                    var lines = File.ReadAllLines(file);
                    foreach (var line in lines)
                    {
                        var match = Regex.Match(line, @"public\s+(?:abstract\s+)?(?:partial\s+)?class\s+([A-Za-z0-9_]+)");
                        if (match.Success)
                        {
                            classNames.Add(match.Groups[1].Value);
                        }
                    }
                }
                moduleEntities[modName] = classNames;
            }

            var htmlFiles = Directory.GetFiles(htmlDir, "ERD_*.html");

            foreach (var htmlPath in htmlFiles)
            {
                var fileName = Path.GetFileName(htmlPath);
                Console.WriteLine($"Processing {fileName}...");

                List<Type> targetTypes = new List<Type>();
                if (fileName.Contains("00_Master_Integration"))
                {
                    targetTypes = allTypes;
                }
                else
                {
                    // Match ERD_M1_SchoolAdmin.html to M1_SchoolAdmin
                    var modFolderKey = moduleEntities.Keys.FirstOrDefault(k => fileName.Contains(k.Split('_')[0]));
                    if (modFolderKey != null && moduleEntities.ContainsKey(modFolderKey))
                    {
                        var classNames = moduleEntities[modFolderKey];
                        targetTypes = allTypes.Where(t => classNames.Contains(t.Name)).ToList();
                    }
                }

                if (targetTypes.Count == 0)
                {
                    Console.WriteLine($"No target types found for {fileName}. Skipping.");
                    continue;
                }

                var entitiesArray = new JsonArray();
                var relationsArray = new JsonArray();

                foreach (var type in targetTypes)
                {
                    var entityNode = new JsonObject
                    {
                        ["name"] = type.Name,
                        ["ar"] = "",
                        ["table"] = type.Name.ToUpper(),
                        ["weak"] = false
                    };

                    var attributesArray = new JsonArray();
                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    
                    var idProp = type.GetProperty("Id");
                    if (idProp != null || type.BaseType?.Name.Contains("Entity") == true)
                    {
                        attributesArray.Add(new JsonObject { ["name"] = "Id", ["type"] = "BIGINT", ["pk"] = true, ["fk"] = false });
                    }

                    foreach (var prop in properties)
                    {
                        if (prop.Name == "Id" || prop.Name == "DomainEvents") continue;
                        
                        bool isFk = prop.Name.EndsWith("Id") && (prop.PropertyType == typeof(long) || prop.PropertyType == typeof(long?));
                        string typeStr = GetSqlType(prop.PropertyType);
                        
                        attributesArray.Add(new JsonObject { ["name"] = prop.Name, ["type"] = typeStr, ["pk"] = false, ["fk"] = isFk });
                        
                        if (isFk)
                        {
                            string targetEntity = prop.Name.Substring(0, prop.Name.Length - 2);
                            string actualTarget = allTypeNames.Contains(targetEntity) ? targetEntity : null;
                            if (actualTarget == null && targetEntity.EndsWith("Employee")) actualTarget = "Employee";
                            if (actualTarget == null && targetEntity.EndsWith("School")) actualTarget = "School";
                            if (actualTarget == null && targetEntity.EndsWith("Student")) actualTarget = "Student";
                            
                            // Only add relation if the target is IN THE CURRENT DIAGRAM (or it's master)
                            // Actually, many diagrams link to external entities. Let's add them all as relationships.
                            if (actualTarget != null)
                            {
                                relationsArray.Add(new JsonObject
                                {
                                    ["from"] = actualTarget,
                                    ["to"] = type.Name,
                                    ["name"] = actualTarget,
                                    ["cardFrom"] = "1",
                                    ["cardTo"] = "M"
                                });
                            }
                        }
                    }
                    
                    entityNode["attributes"] = attributesArray;
                    entitiesArray.Add(entityNode);
                }

                string htmlContent = File.ReadAllText(htmlPath);
                string specPattern = @"const\s+SPEC\s*=\s*(\{.*?\});";
                var match = Regex.Match(htmlContent, specPattern, RegexOptions.Singleline);
                if (match.Success)
                {
                    string jsonString = match.Groups[1].Value;
                    var specNode = JsonNode.Parse(jsonString).AsObject();
                    specNode["entities"] = entitiesArray;
                    specNode["relations"] = relationsArray;
                    var options = new JsonSerializerOptions { WriteIndented = false };
                    string newJson = specNode.ToJsonString(options);
                    string newHtml = htmlContent.Substring(0, match.Groups[1].Index) + newJson + htmlContent.Substring(match.Groups[1].Index + match.Groups[1].Length);
                    File.WriteAllText(htmlPath, newHtml);
                    Console.WriteLine($"Successfully updated {fileName} with {targetTypes.Count} entities.");
                }
            }
        }

        static string GetSqlType(Type t)
        {
            var type = Nullable.GetUnderlyingType(t) ?? t;
            if (type == typeof(long) || type == typeof(int)) return "BIGINT";
            if (type == typeof(string)) return "VARCHAR(200)";
            if (type == typeof(bool)) return "BOOL";
            if (type == typeof(decimal)) return "DECIMAL";
            if (type == typeof(DateTime) || type == typeof(DateTimeOffset)) return "TIMESTAMP";
            return "VARCHAR";
        }
    }
}
