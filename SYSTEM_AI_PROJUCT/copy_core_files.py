import os
import shutil

# مسار المشروع
project_dir = r'c:\Users\Elite\Desktop\SYSTEM_AI_PROJUCT'

# نسخ الملفات الأساسية إلى core/
files_to_copy = [
    ('ml_core/model_trainer.py', 'core/model_trainer.py'),
    ('data_engine/data_generator.py', 'core/data_generator.py'),
    ('strategy_engine/strategy_planner.py', 'core/strategy_planner.py'),
    ('gui_app_arabic_final_fixed.py', 'ui/gui_app.py')
]

print("=== نسخ الملفات الأساسية ===")
for src, dest in files_to_copy:
    src_path = os.path.join(project_dir, src)
    dest_path = os.path.join(project_dir, dest)
    
    if os.path.exists(src_path):
        print(f"نسخ: {src} -> {dest}")
        shutil.copy2(src_path, dest_path)
    else:
        print(f"الملف غير موجود: {src}")

print("\n=== تم النسخ ===")
