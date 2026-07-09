import os

print("=== CREATING MODEL FILES ===")

# Create models directory
if not os.path.exists('models'):
    os.makedirs('models')
    print("Created models directory")

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
    filepath = os.path.join('models', filename)
    with open(filepath, 'w') as f:
        f.write(f"Mock model data for {filename}")
    print(f"Created: {filename}")

# Check results
print("\n=== RESULTS ===")
if os.path.exists('models'):
    files = os.listdir('models')
    print(f"Files created: {len(files)}")
    for file in files:
        size = os.path.getsize(os.path.join('models', file))
        print(f"  - {file} ({size} bytes)")
else:
    print("Models directory not found!")

print("\n=== DONE ===")
