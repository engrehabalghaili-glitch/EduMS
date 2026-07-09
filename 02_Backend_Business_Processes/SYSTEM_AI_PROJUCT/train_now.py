import sys
import os
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

from core.model_trainer import EducationalModelTrainer, train_and_save_models

# مسار البيانات
data_path = 'data/comprehensive_school_data.csv'

print("=" * 60)
print("بدء تدريب النماذج")
print("=" * 60)
print(f"مسار البيانات: {data_path}")

# التحقق من وجود البيانات
if not os.path.exists(data_path):
    print(f"خطأ: ملف البيانات غير موجود: {data_path}")
    sys.exit(1)

# تدريب النماذج
try:
    train_and_save_models(data_path)
    print("\n" + "=" * 60)
    print("تم تدريب النماذج وحفظها بنجاح!")
    print("=" * 60)
except Exception as e:
    print(f"\nخطأ أثناء التدريب: {e}")
    import traceback
    traceback.print_exc()
    sys.exit(1)
