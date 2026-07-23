const fs = require('fs');
const path = require('path');

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

function capitalizeFirstLetter(string) {
  return string.charAt(0).toUpperCase() + string.slice(1);
}

function toCamelCase(str) {
  return str.replace(/-([a-z])/g, function (g) { return g[1].toUpperCase(); });
}

function toPascalCase(str) {
  const camel = toCamelCase(str);
  return camel.charAt(0).toUpperCase() + camel.slice(1);
}

let generatedCount = 0;
let skippedCount = 0;

for (const [backendModule, frontendModule] of Object.entries(modulesMap)) {
  const OUTPUT_BASE_DIR = path.join(__dirname, '..', 'src', 'app', 'modules', frontendModule);

  if (!fs.existsSync(OUTPUT_BASE_DIR)) continue;

  const featureDirs = fs.readdirSync(OUTPUT_BASE_DIR).filter(f => fs.statSync(path.join(OUTPUT_BASE_DIR, f)).isDirectory());

  for (const featureDir of featureDirs) {
    const dataAccessDir = path.join(OUTPUT_BASE_DIR, featureDir, 'data-access');
    if (!fs.existsSync(dataAccessDir)) continue;

    const serviceFileName = `${featureDir}.service.ts`;
    const serviceFilePath = path.join(dataAccessDir, serviceFileName);
    const storeFilePath = path.join(dataAccessDir, `${featureDir}.store.ts`);

    if (!fs.existsSync(serviceFilePath)) continue;

    const serviceContent = fs.readFileSync(serviceFilePath, 'utf-8');

    // Extract Types and Interface Path from Service
    const importMatch = serviceContent.match(/import\s+\{[\s\S]*?\}\s+from\s+['"](.*core\/api\/interfaces.*)['"]/);
    if (!importMatch) {
      console.log(`Skipping ${featureDir}: Could not find core API interface import.`);
      skippedCount++;
      continue;
    }
    const interfacePath = importMatch[1];

    const typeMatch = serviceContent.match(/extends BaseApiService<\s*([\w\s]+),\s*([\w\s]+),\s*([\w\s]+)\s*>/);
    if (!typeMatch) {
      console.log(`Skipping ${featureDir}: Could not find type generics.`);
      skippedCount++;
      continue;
    }

    const entityType = typeMatch[1].trim();
    const createType = typeMatch[2].trim();
    const updateType = typeMatch[3].trim();
    
    // Create the interface import string
    let typeSet = new Set();
    if(entityType !== 'any') typeSet.add(entityType);
    if(createType !== 'any') typeSet.add(createType);
    if(updateType !== 'any') typeSet.add(updateType);
    
    const typesToImport = Array.from(typeSet).join(', ');
    const validImportString = typesToImport ? `import { ${typesToImport} } from '${interfacePath}';` : '';

    const serviceClassName = `${toPascalCase(featureDir)}Service`;
    const storeClassName = `${toPascalCase(featureDir)}Store`;

    const storeTemplate = `import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { pipe, switchMap, tap } from 'rxjs';
import { ${serviceClassName} } from './${featureDir}.service';
${validImportString}

type ${storeClassName}State = {
  items: ${entityType}[];
  selectedItem: ${entityType} | null;
  isLoading: boolean;
  error: string | null;
};

const initialState: ${storeClassName}State = {
  items: [],
  selectedItem: null,
  isLoading: false,
  error: null,
};

export const ${storeClassName} = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, service = inject(${serviceClassName})) => ({
    loadAll: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() => service.getAll().pipe(
          tap({
            next: (response) => patchState(store, { items: response || [], isLoading: false }),
            error: (err) => patchState(store, { error: err.message || 'Error loading data', isLoading: false })
          })
        ))
      )
    ),
    loadById: rxMethod<number | string>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) => service.getById(id).pipe(
          tap({
            next: (response) => patchState(store, { selectedItem: response, isLoading: false }),
            error: (err) => patchState(store, { error: err.message || 'Error loading data', isLoading: false })
          })
        ))
      )
    ),
    create: rxMethod<${createType}>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((payload) => service.create(payload).pipe(
          tap({
            next: (response) => {
              if (response) {
                patchState(store, { items: [...store.items(), response as ${entityType}] });
              }
              patchState(store, { isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error creating item', isLoading: false })
          })
        ))
      )
    ),
    update: rxMethod<{id: number | string, payload: ${updateType}}>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({id, payload}) => service.update(id, payload).pipe(
          tap({
            next: () => {
              const updatedItems = store.items().map(item => (item as any).id === id ? { ...item, ...payload } : item);
              patchState(store, { items: updatedItems as ${entityType}[] });
              patchState(store, { isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error updating item', isLoading: false })
          })
        ))
      )
    ),
    delete: rxMethod<number | string>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) => service.delete(id).pipe(
          tap({
            next: () => {
              const updatedItems = store.items().filter(item => (item as any).id !== id);
              patchState(store, { items: updatedItems as ${entityType}[], isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error deleting item', isLoading: false })
          })
        ))
      )
    )
  }))
);
`;

    fs.writeFileSync(storeFilePath, storeTemplate, 'utf-8');
    generatedCount++;
  }
}

console.log(`Successfully generated ${generatedCount} NgRx SignalStores!`);
console.log(`Skipped ${skippedCount} files.`);
