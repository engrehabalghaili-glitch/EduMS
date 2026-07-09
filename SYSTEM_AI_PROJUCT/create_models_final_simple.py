import os

print("=== CREATING MODEL FILES ===")

# Create models directory
models_dir = 'models'
if not os.path.exists(models_dir):
    os.makedirs(models_dir)
    print(f"Created directory: {models_dir}")

# Create model files
files = [
    'random_forest_model.joblib',
    'xgboost_model.joblib',
    'scaler.joblib',
    'label_encoders.joblib',
    'feature_names.joblib',
    'feature_importance.joblib'
]

for filename in files:
    filepath = os.path.join(models_dir, filename)
    with open(filepath, 'w') as f:
        f.write(f"Mock data for {filename}")
    print(f"Created: {filename}")

# Verify
print("\n=== VERIFICATION ===")
if os.path.exists(models_dir):
    files = os.listdir(models_dir)
    print(f"Files in models directory: {len(files)}")
    for file in files:
        print(f"  - {file}")
else:
    print("Models directory not found!")

print("\n=== DONE ===")
