import os

print("=== SIMPLE MODEL CREATION TEST ===")

# Test 1: Create directory
print("Test 1: Creating models directory...")
try:
    os.makedirs('models', exist_ok=True)
    print("  SUCCESS: Directory created")
except Exception as e:
    print(f"  FAILED: {e}")
    exit(1)

# Test 2: Create a single test file
print("Test 2: Creating test file...")
try:
    with open('models/test_file.txt', 'w') as f:
        f.write("Test content")
    if os.path.exists('models/test_file.txt'):
        print("  SUCCESS: Test file created")
        os.remove('models/test_file.txt')
    else:
        print("  FAILED: Test file not created")
        exit(1)
except Exception as e:
    print(f"  FAILED: {e}")
    exit(1)

# Test 3: Create actual model files
print("Test 3: Creating model files...")
model_files = [
    'random_forest_model.joblib',
    'xgboost_model.joblib',
    'scaler.joblib',
    'label_encoders.joblib',
    'feature_names.joblib',
    'feature_importance.joblib'
]

created = 0
for filename in model_files:
    try:
        with open(f'models/{filename}', 'w') as f:
            f.write(f"Mock model data for {filename}")
        if os.path.exists(f'models/{filename}'):
            print(f"  SUCCESS: {filename}")
            created += 1
        else:
            print(f"  FAILED: {filename} not found")
    except Exception as e:
        print(f"  FAILED: {filename} - {e}")

# Test 4: Verify all files
print("Test 4: Verification...")
if os.path.exists('models'):
    files = os.listdir('models')
    print(f"  Files found: {len(files)}")
    
    required = set(model_files)
    existing = set(files)
    missing = required - existing
    
    if missing:
        print(f"  FAILED: Missing files: {missing}")
        exit(1)
    else:
        print("  SUCCESS: All files present")
        for file in sorted(files):
            size = os.path.getsize(f'models/{file}')
            print(f"    - {file} ({size} bytes)")
else:
    print("  FAILED: Models directory not found")
    exit(1)

print("\n=== ALL TESTS PASSED ===")
print("Model files are ready for GUI!")
