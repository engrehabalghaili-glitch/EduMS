import os
import sys

print("Creating models...")
print(f"Current directory: {os.getcwd()}")

# Create models directory
models_dir = 'models'
if not os.path.exists(models_dir):
    os.makedirs(models_dir)
    print(f"Created directory: {models_dir}")

# Create simple mock files
model_files = [
    'random_forest_model.joblib',
    'xgboost_model.joblib',
    'scaler.joblib',
    'label_encoders.joblib',
    'feature_names.joblib',
    'feature_importance.joblib'
]

for file in model_files:
    file_path = os.path.join(models_dir, file)
    with open(file_path, 'w') as f:
        f.write(f"Mock model file: {file}")
    print(f"Created: {file_path}")

print("\nAll model files created successfully!")
print(f"Files in {models_dir}:")
for file in os.listdir(models_dir):
    print(f"  - {file}")
