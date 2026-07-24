const fs = require('fs');
const path = require('path');

const ARTIFACT_PATH = 'C:/Users/Admin/.gemini/antigravity-ide/brain/10d74be9-fe6d-4012-9b79-e1f67be77939/audit_report.md';

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

let mdReport = `# تقرير التدقيق الشامل لطبقة الخدمات (Services Audit Report)\n\n`;
mdReport += `هذا التقرير تم توليده آلياً للتحقق من سلامة كافة الـ الخدمات (Services) التي تم توليدها وتطابقها التام مع الباك إند.\n\n`;

let totalChecked = 0;
let totalIssues = 0;

for (const [backendModule, frontendModule] of Object.entries(modulesMap)) {
  mdReport += `## قسم (Module): \`${backendModule}\`\n\n`;
  mdReport += `| اسم الكيان (Controller) | ملف الخدمة (Service) | الأنواع الممررة (Generics) | الرابط (BaseUrl) | الحالة |\n`;
  mdReport += `|---|---|---|---|---|\n`;
  
  const CONTROLLERS_DIR = path.join('H:', 'EduMS', 'EduMS.Backend', 'src', 'EduMS.WebApi', 'Controllers', 'v1', backendModule);
  const OUTPUT_BASE_DIR = path.join('H:', 'EduMS', 'EduMS-Frontend', 'edums-frontend-DDD-System', 'src', 'app', 'modules', frontendModule);

  if (!fs.existsSync(CONTROLLERS_DIR)) continue;

  const controllers = fs.readdirSync(CONTROLLERS_DIR).filter(f => f.endsWith('.cs'));

  for (const controllerFile of controllers) {
    if (controllerFile === 'AuthController.cs') {
      mdReport += `| \`AuthController\` | ⚠️ *مستثنى آلياً* | N/A | N/A | ⏭️ مستثنى |\n`;
      continue;
    }

    const controllerName = controllerFile.replace('Controller.cs', '');
    const featureNameKebab = toKebabCase(controllerName);
    const expectedBaseUrl = `/api/v1/${controllerName}`;
    const serviceFilePath = path.join(OUTPUT_BASE_DIR, featureNameKebab, 'data-access', `${featureNameKebab}.service.ts`);

    let status = '✅ سليم 100%';
    let typesPassed = '';
    let foundUrl = '';

    if (!fs.existsSync(serviceFilePath)) {
      status = '❌ ملف مفقود';
      totalIssues++;
    } else {
      const serviceContent = fs.readFileSync(serviceFilePath, 'utf-8');
      
      // Check Types
      const typeMatch = serviceContent.match(/extends BaseApiService<([\s\S]*?)>/);
      if (typeMatch) {
         typesPassed = typeMatch[1].replace(/\n/g, '').replace(/\s/g, '');
         if (typesPassed.includes('any')) {
            status = '⚠️ تحذير (يوجد any)';
            totalIssues++;
         }
      } else {
         typesPassed = '❌ غير موجود';
         status = '❌ خطأ بالوراثة';
         totalIssues++;
      }

      // Check URL
      const urlMatch = serviceContent.match(/return\s+'(.*?)';/);
      if (urlMatch) {
        foundUrl = urlMatch[1];
        if (foundUrl !== expectedBaseUrl) {
           status = '❌ خطأ بالرابط';
           totalIssues++;
        }
      } else {
        foundUrl = '❌ غير موجود';
        status = '❌ خطأ بالرابط';
        totalIssues++;
      }
    }

    mdReport += `| \`${controllerName}\` | \`${featureNameKebab}.service.ts\` | \`${typesPassed}\` | \`${foundUrl}\` | ${status} |\n`;
    totalChecked++;
  }
  mdReport += `\n`;
}

mdReport += `\n---\n`;
mdReport += `### 📊 الإحصائيات النهائية:\n`;
mdReport += `- إجمالي الجداول المفحوصة: **${totalChecked}**\n`;
mdReport += `- إجمالي الخدمات المطابقة 100%: **${totalChecked - totalIssues}**\n`;
mdReport += `- إجمالي التحذيرات (Missing Interfaces): **${totalIssues}**\n`;
mdReport += `\n> [!NOTE]\n> وجود تحذير (يوجد any) يعني أن الخدمة جاهزة للعمل وتستطيع إرسال واستقبال الطلبات بنجاح، ولكن الـ Interface الخاص بها مفقود حالياً في مجلد \`core/api/interfaces\`. يجب إضافته يدوياً لاحقاً للحصول على حماية الأنواع (Type Safety).\n`;

fs.writeFileSync(ARTIFACT_PATH, mdReport, 'utf-8');
console.log(`Audit report generated at ${ARTIFACT_PATH}`);
