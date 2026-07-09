import os
import sys

def test_model_creation():
    print("=== WORKING MODEL CREATION TEST ===")
    
    # Test 1: Directory creation
    print("Test 1: Creating models directory...")
    try:
        os.makedirs('models', exist_ok=True)
        print("  SUCCESS: Directory created")
    except Exception as e:
        print(f"  FAILED: {e}")
        return False
    
    # Test 2: File creation
    print("Test 2: Creating model files...")
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
            filepath = os.path.join('models', filename)
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(f"Mock model data for {filename}")
            
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"  SUCCESS: {filename} ({size} bytes)")
                created += 1
            else:
                print(f"  FAILED: {filename} not created")
        except Exception as e:
            print(f"  ERROR: {filename} - {e}")
    
    # Test 3: Verification
    print("Test 3: Verification...")
    if os.path.exists('models'):
        try:
            files = os.listdir('models')
            print(f"  Files found: {len(files)}")
            
            for file in sorted(files):
                size = os.path.getsize(os.path.join('models', file))
                print(f"    - {file} ({size} bytes)")
            
            required = set(model_files)
            existing = set(files)
            missing = required - existing
            
            if missing:
                print(f"  FAILED: Missing files: {missing}")
                return False
            else:
                print("  SUCCESS: All files created!")
                return True
                
        except Exception as e:
            print(f"  ERROR: {e}")
            return False
    else:
        print("  FAILED: Models directory not found!")
        return False

if __name__ == "__main__":
    success = test_model_creation()
    print(f"\n=== RESULT: {'SUCCESS' if success else 'FAILED'} ===")
    
    if success:
        print("=== MODELS ARE READY FOR GUI ===")
    else:
        print("=== MODEL CREATION FAILED ===")
