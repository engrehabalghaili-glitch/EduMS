import os
import shutil
import sys

# إنشاء المجلدات
folders = {
    'legacy_scripts': ['.py'],
    'legacy_docs': ['.md'],
    'legacy_bat': ['.bat'],
    'legacy_txt': ['.txt'],
    'legacy_misc': []  # للملفات الأخرى
}

# المجلدات الموجودة التي يجب عدم نقلها
keep_folders = {'core', 'ui', 'scripts', 'docs', 'data', 'models', 'api_service', 'ml_core', 'data_engine', 'strategy_engine', 'src', 'venv', 'backups', 'legacy_scripts', 'legacy_docs', 'legacy_bat', 'legacy_txt', 'legacy_misc'}

# الملفات التي يجب عدم نقلها
keep_files = {'requirements.txt', 'README.md', 'organize_files.py'}

# إنشاء المجلدات
for folder in folders.keys():
    os.makedirs(folder, exist_ok=True)

# نقل الملفات
moved_count = 0
for file in os.listdir('.'):
    if os.path.isfile(file):
        file_ext = os.path.splitext(file)[1].lower()
        
        # تخطي الملفات التي يجب الاحتفاظ بها
        if file in keep_files:
            continue
        
        # نقل الملفات حسب الامتداد
        moved = False
        for folder, extensions in folders.items():
            if file_ext in extensions:
                try:
                    shutil.move(file, f'{folder}/{file}')
                    print(f'Moved {file} to {folder}/')
                    moved_count += 1
                    moved = True
                    break
                except Exception as e:
                    print(f'Error moving {file}: {e}')
        
        # نقل الملفات الأخرى إلى legacy_misc
        if not moved:
            try:
                shutil.move(file, f'legacy_misc/{file}')
                print(f'Moved {file} to legacy_misc/')
                moved_count += 1
            except Exception as e:
                print(f'Error moving {file}: {e}')

print(f'\nFile organization completed! Moved {moved_count} files.')
