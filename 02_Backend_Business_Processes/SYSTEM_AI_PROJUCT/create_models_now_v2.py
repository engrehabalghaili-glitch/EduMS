import os

print("=== Creating Model Files ===")

# Create models directory
models_dir = 'models'
if not os.path.exists(models_dir):
    os.makedirs(models_dir)
    print(f"Created: {models_dir}")

# Create mock model files
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
        f.write(f"Mock model data for {filename}")
    print(f"Created: {filename}")

print("\n=== Verification ===")
print(f"Models directory: {os.path.exists(models_dir)}")
if os.path.exists(models_dir):
    files = os.listdir(models_dir)
    print(f"Files created: {len(files)}")
    for file in files:
        print(f"  - {file}")

print("\n=== Models Ready for GUI ===")
