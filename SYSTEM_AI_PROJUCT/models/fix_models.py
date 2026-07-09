import os
import shutil

# المسارات
fake_file = 'random_forest_model.joblib'
real_file = 'randomforest_model.joblib'

print("=== إصلاح ملفات النماذج ===")
print(f"الدليل الحالي: {os.getcwd()}")

# حذف الملف الوهمي
if os.path.exists(fake_file):
    size = os.path.getsize(fake_file)
    print(f"\n1. حذف الملف الوهمي: {fake_file} ({size} bytes)")
    try:
        os.remove(fake_file)
        print("   ✓ تم الحذف")
    except Exception as e:
        print(f"   ✗ فشل الحذف: {e}")
else:
    print("\n1. الملف الوهمي غير موجود")

# نسخ الملف الحقيقي
if os.path.exists(real_file):
    size = os.path.getsize(real_file)
    print(f"\n2. نسخ الملف الحقيقي: {real_file} ({size} bytes)")
    try:
        shutil.copy(real_file, fake_file)
        print("   ✓ تم النسخ")
    except Exception as e:
        print(f"   ✗ فشل النسخ: {e}")
else:
    print("\n2. الملف الحقيقي غير موجود")

# التحقق النهائي
print("\n=== التحقق النهائي ===")
if os.path.exists(fake_file):
    size = os.path.getsize(fake_file)
    print(f"{fake_file}: {size} bytes")
else:
    print(f"{fake_file}: غير موجود")

if os.path.exists(real_file):
    size = os.path.getsize(real_file)
    print(f"{real_file}: {size} bytes")
else:
    print(f"{real_file}: غير موجود")

print("\n=== تم ===")
