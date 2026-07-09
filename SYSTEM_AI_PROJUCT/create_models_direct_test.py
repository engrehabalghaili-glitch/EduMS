import os
import sys

def main():
    print("=== DIRECT MODEL CREATION TEST ===")
    
    # Test directory creation
    print("1. Testing directory creation...")
    try:
        os.makedirs('models', exist_ok=True)
        print("   Directory created successfully")
    except Exception as e:
        print(f"   Error: {e}")
        return False
    
    # Test file creation
    print("2. Testing file creation...")
    test_files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    created = 0
    for filename in test_files:
        try:
            filepath = os.path.join('models', filename)
            with open(filepath, 'w') as f:
                f.write(f"Mock model data for {filename}")
            
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"   Created: {filename} ({size} bytes)")
                created += 1
            else:
                print(f"   Failed: {filename}")
        except Exception as e:
            print(f"   Error: {filename} - {e}")
    
    # Verification
    print("3. Verification...")
    if os.path.exists('models'):
        files = os.listdir('models')
        print(f"   Total files: {len(files)}")
        
        for file in sorted(files):
            size = os.path.getsize(os.path.join('models', file))
            print(f"   - {file} ({size} bytes)")
        
        required = set(test_files)
        existing = set(files)
        missing = required - existing
        
        if missing:
            print(f"   Missing files: {missing}")
            return False
        else:
            print("   All files created successfully!")
            return True
    else:
        print("   Models directory not found!")
        return False

if __name__ == "__main__":
    success = main()
    print(f"\nResult: {'SUCCESS' if success else 'FAILED'}")
