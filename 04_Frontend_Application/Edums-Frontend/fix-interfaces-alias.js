const fs = require('fs');
const path = require('path');

const modulesDir = 'src/app/modules';

function walkSync(dir, filelist = []) {
  const files = fs.readdirSync(dir);
  for (const file of files) {
    const dirFile = path.join(dir, file);
    if (fs.statSync(dirFile).isDirectory()) {
      walkSync(dirFile, filelist);
    } else if (dirFile.endsWith('.ts')) {
      filelist.push(dirFile);
    }
  }
  return filelist;
}

const allTsFiles = walkSync(modulesDir);
let modifiedCount = 0;

for (const file of allTsFiles) {
  // Only process .service.ts and .store.ts
  if (!file.endsWith('.service.ts') && !file.endsWith('.store.ts')) continue;
  
  let content = fs.readFileSync(file, 'utf8');
  
  // Example file path: src\app\modules\m2-student-Affairs\data-access\attendance-details\data-access\attendance-details.service.ts
  // We want to extract the module name: m2-student-Affairs
  const parts = file.split(path.sep);
  const modulesIndex = parts.indexOf('modules');
  if (modulesIndex === -1 || modulesIndex + 1 >= parts.length) continue;
  
  const moduleName = parts[modulesIndex + 1]; // e.g. m2-student-Affairs
  
  let changed = false;
  
  // Replace ../../../interfaces with @modules/moduleName/interfaces
  if (content.includes('../../../interfaces')) {
    content = content.replace(/\.\.\/\.\.\/\.\.\/interfaces/g, `@modules/${moduleName}/interfaces`);
    changed = true;
  }
  
  // Replace ../../../interface with @modules/moduleName/interface (for M1)
  if (content.includes('../../../interface')) {
    content = content.replace(/\.\.\/\.\.\/\.\.\/interface/g, `@modules/${moduleName}/interface`);
    changed = true;
  }
  
  if (changed) {
    fs.writeFileSync(file, content);
    modifiedCount++;
  }
}

console.log('Done modifying ' + modifiedCount + ' files to use @modules alias.');
