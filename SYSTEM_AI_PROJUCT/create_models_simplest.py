# Simplest model creation script
import os
import sys

print("=== Creating Model Files ===")

# Create models directory
models_dir = 'models'
if not os.path.exists(models_dir):
    os.makedirs(models_dir)
    print(f"Created: {models_dir}")

# Create simple mock files
files_to_create = [
    'random_forest_model.joblib',
    'xgboost_model.joblib',
    'scaler.joblib',
    'label_encoders.joblib',
    'feature_names.joblib',
    'feature_importance.joblib'
]

for filename in files_to_create:
    filepath = os.path.join(models_dir, filename)
    with open(filepath, 'w') as f:
        f.write(f"Mock data for {filename}")
    print(f"Created: {filename}")

print("\n=== Verification ===")
print(f"Directory exists: {os.path.exists(models_dir)}")
print("Files created:")
for file in os.listdir(models_dir):
    size = os.path.getsize(os.path.join(models_dir, file))
    print(f"  - {file} ({size} bytes)")

print("\n=== Done ===")
