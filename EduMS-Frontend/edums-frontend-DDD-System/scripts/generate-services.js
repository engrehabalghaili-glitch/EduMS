const fs = require('fs');
const path = require('path');

// Helper: Pascal to kebab case
function toKebabCase(str) {
  return str.replace(/([a-z])([A-Z])/g, '$1-$2').toLowerCase();
}

const modulesMap = {
  'M1_SchoolAdmin': 'school-admin',
  'M2_StudentAffairs': 'student-affairs',
  'M3_EmployeeManagement': 'employee-management',
  'M4_AssetLogistics': 'asset-logistics',
  'M5_FinancialManagement': 'financial-management',
  'M6_StatisticsReports': 'statistics-reports',
  'M7_EmergencyManagement': 'emergency-management',
  'M8_AuthenticationUsers': 'authentication-users'
};

let totalSuccess = 0;
let totalErrors = 0;
let skippedFiles = [];

for (const [backendModule, frontendModule] of Object.entries(modulesMap)) {
  console.log(`\n--- Processing Module: ${backendModule} ---`);
  
  const CONTROLLERS_DIR = path.join('H:', 'EduMS', 'EduMS.Backend', 'src', 'EduMS.WebApi', 'Controllers', 'v1', backendModule);
  const INTERFACES_DIR = path.join('H:', 'EduMS', 'EduMS-Frontend', 'edums-frontend-DDD-System', 'src', 'app', 'core', 'api', 'interfaces', backendModule);
  const OUTPUT_BASE_DIR = path.join('H:', 'EduMS', 'EduMS-Frontend', 'edums-frontend-DDD-System', 'src', 'app', 'modules', frontendModule);

  if (!fs.existsSync(CONTROLLERS_DIR)) {
    console.log(`[SKIP] Controllers dir not found: ${CONTROLLERS_DIR}`);
    continue;
  }

  // 1. Build an index of all exported interfaces in the frontend module
  const interfacesIndex = {}; 
  const availableInterfaces = new Set();
  
  if (fs.existsSync(INTERFACES_DIR)) {
    const interfaceFiles = fs.readdirSync(INTERFACES_DIR).filter(f => f.endsWith('.ts'));
    for (const file of interfaceFiles) {
      const content = fs.readFileSync(path.join(INTERFACES_DIR, file), 'utf-8');
      const regex = /export\s+interface\s+([a-zA-Z0-9_]+)/g;
      let match;
      while ((match = regex.exec(content)) !== null) {
        interfacesIndex[match[1]] = file; // map interface name to filename
        availableInterfaces.add(match[1]);
      }
    }
  } else {
    console.log(`[WARN] Interfaces dir not found: ${INTERFACES_DIR}`);
  }

  // 2. Read controllers
  const controllers = fs.readdirSync(CONTROLLERS_DIR).filter(f => f.endsWith('.cs'));

  for (const controllerFile of controllers) {
    const content = fs.readFileSync(path.join(CONTROLLERS_DIR, controllerFile), 'utf-8');
    
    // استخراج الاسم والرابط
    const controllerName = controllerFile.replace('Controller.cs', '');
    const baseUrl = `/api/v1/${controllerName}`;

    // البحث عن اسم الكيان بذكاء لدعم القراءة فقط
    let entityName = null;
    const createDtoMatch = content.match(/\[FromBody\]\s+Create([a-zA-Z0-9_]+)Dto/);
    if (createDtoMatch) {
      entityName = createDtoMatch[1];
    } else {
      // Fallback: search for IEnumerable<...Dto>
      const enumMatch = content.match(/IEnumerable<([a-zA-Z0-9_]+)Dto>/);
      if (enumMatch) {
        entityName = enumMatch[1];
      } else {
        // Fallback: ActionResult<ApiResponse<...Dto>>
        const actionMatch = content.match(/ActionResult<ApiResponse<([a-zA-Z0-9_]+)Dto>>/);
        if (actionMatch) {
            entityName = actionMatch[1];
        }
      }
    }

    if (!entityName) {
      console.log(`[SKIP] Could not extract Entity Name from ${controllerFile}. Manual review needed.`);
      skippedFiles.push(`${backendModule}/${controllerFile}`);
      totalErrors++;
      continue;
    }
    
    // الأنواع المفترضة بناءً على المعايير
    const T_Base = entityName;
    const T_Create = `Create${entityName}Payload`;
    const T_Update = `Update${entityName}Payload`;

    // التحقق الفعلي من تواجد الواجهات في النظام
    const hasBase = availableInterfaces.has(T_Base);
    const hasCreate = availableInterfaces.has(T_Create);
    const hasUpdate = availableInterfaces.has(T_Update);

    if (!hasBase && !hasCreate && !hasUpdate) {
        console.log(`[SKIP] No interface found for Entity ${entityName} in ${controllerFile}`);
        skippedFiles.push(`${backendModule}/${controllerFile} (No Interfaces)`);
        totalErrors++;
        continue;
    }

    // تحديد ملف الـ Interface بناءً على أي واجهة تم العثور عليها
    let interfaceFile = interfacesIndex[T_Base] || interfacesIndex[T_Create] || interfacesIndex[T_Update];
    
    // تحويل التسمية إلى kebab-case للمسارات
    const featureNameKebab = toKebabCase(controllerName);

    // الأنواع النهائية التي سيتم كتابتها في الكود لضمان عدم حدوث خطأ
    const T = hasBase ? T_Base : 'any';
    const TCreate = hasCreate ? T_Create : T;
    const TUpdate = hasUpdate ? T_Update : T;

    // استيراد الأنواع المتاحة فقط لعدم الإخلال بالكومبايلر
    const importsToInject = [];
    if (hasBase) importsToInject.push(T_Base);
    if (hasCreate) importsToInject.push(T_Create);
    if (hasUpdate) importsToInject.push(T_Update);

    const interfaceImportPath = interfaceFile.replace('.ts', '');

    // قالب الكود للـ Service
    const serviceCode = `import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  ${importsToInject.join(', \n  ')} 
} from '../../../../core/api/interfaces/${backendModule}/${interfaceImportPath}';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (${controllerName})
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class ${controllerName}Service extends BaseApiService<
  ${T}, 
  ${TCreate}, 
  ${TUpdate}
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '${baseUrl}';
  }
}
`;

    // إنشاء المجلدات
    const featureDir = path.join(OUTPUT_BASE_DIR, featureNameKebab, 'data-access');
    fs.mkdirSync(featureDir, { recursive: true });

    // حفظ الملف
    const serviceFilePath = path.join(featureDir, `${featureNameKebab}.service.ts`);
    fs.writeFileSync(serviceFilePath, serviceCode, 'utf-8');
    totalSuccess++;
  }
}

console.log(`\n================================`);
console.log(`ALL MODULES DONE!`);
console.log(`Total Successfully Generated: ${totalSuccess}`);
console.log(`Total Errors/Skipped: ${totalErrors}`);
if (skippedFiles.length > 0) {
    console.log(`\nSkipped Files List (Manual Review Needed):`);
    skippedFiles.forEach(f => console.log(`- ${f}`));
}
console.log(`================================\n`);
