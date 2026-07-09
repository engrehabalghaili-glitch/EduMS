import os
import shutil

# مسار المشروع
project_dir = r'c:\Users\Elite\Desktop\YSTEM_AI_PROJUCT'
backup_dir = os.path.join(project_dir, 'backups', 'archive')

# قائمة الملفات والمجلدات التي يجب نقلها
patterns_to_move = [
    'create_*.py',
    'final_*.py',
    'ultimate_*.py',
    'check_*.py',
    'show_*.py',
    'test_*.py',
    'execute_*.py',
    'run_*.py',
    'simple_*.py',
    'manual_*.py',
    'force_*.py',
    'display_*.py',
    'project_*.py',
    'system_*.py',
    'fix_*.py',
    'quick_*.py',
    'direct_*.py',
    'mkdir_*.py',
    'train_*.py',
    'strategy_*.py',
    'gui_app_arabic*.py',
    'gui_app*.py',
    'gui_app.py',
    '*.bat',
    'GUI_*.md',
    'explanation_files.py',
    'data_engine',
    'ml_core',
    'strategy_engine',
    'src'
]

# المجلدات والملفات التي يجب الاحتفاظ بها
keep_files = [
    'README.md',
    'requirements.txt',
    'User_Guide_AR.md',
    'api_service',
    'core',
    'ui',
    'scripts',
    'docs',
    'models',
    'data',
    'backups',
    'venv'
]

print("=== بدء تنظيف المشروع ===")
print(f"مسار المشروع: {project_dir}")
print(f"مسار النسخ الاحتياطي: {backup_dir}")

# التأكد من وجود مجلد النسخ الاحتياطي
os.makedirs(backup_dir, exist_ok=True)

# نقل الملفات والمجلدات
moved_count = 0
for item in os.listdir(project_dir):
    item_path = os.path.join(project_dir, item)
    
    # التحقق مما إذا كان يجب الاحتفاظ بالملف
    if item in keep_files:
        print(f"الاحتفاظ ب: {item}")
        continue
    
    # التحقق مما إذا كان يجب نقل الملف
    should_move = False
    for pattern in patterns_to_move:
        if pattern.endswith('.py') and item.endswith('.py'):
            if pattern.replace('*.py', '') in item or pattern == '*.py':
                should_move = True
                break
        elif pattern.endswith('.bat') and item.endswith('.bat'):
            should_move = True
            break
        elif pattern.endswith('.md') and item.endswith('.md'):
            if pattern.replace('*.md', '') in item:
                should_move = True
                break
        elif pattern in item:
            should_move = True
            break
    
    if should_move:
        dest = os.path.join(backup_dir, item)
        print(f"نقل: {item} -> {dest}")
        try:
            if os.path.isdir(item_path):
                if os.path.exists(dest):
                    shutil.rmtree(dest)
                shutil.move(item_path, dest)
            else:
                if os.path.exists(dest):
                    os.remove(dest)
                shutil.move(item_path, dest)
            moved_count += 1
        except Exception as e:
            print(f"خطأ في نقل {item}: {e}")

print(f"\n=== تم نقل {moved_count} عنصر ===")
print("=== تم التنظيف ===")
