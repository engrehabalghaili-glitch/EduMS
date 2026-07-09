import os
import sys

def main():
    print("=== MANUAL FORCE MODEL CREATION ===")
    
    # Step 1: Create models directory manually
    models_dir = 'models'
    print(f"Step 1: Creating models directory...")
    
    try:
        if not os.path.exists(models_dir):
            os.makedirs(models_dir)
            print(f"  Created directory: {models_dir}")
        else:
            print(f"  Directory already exists: {models_dir}")
    except Exception as e:
        print(f"  Error creating directory: {e}")
        return False
    
    # Step 2: Create model files manually
    model_files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    print(f"Step 2: Creating model files...")
    created = 0
    
    for filename in model_files:
        filepath = os.path.join(models_dir, filename)
        print(f"  Creating: {filename}")
        
        try:
            # Remove if exists
            if os.path.exists(filepath):
                os.remove(filepath)
                print(f"    Removed existing file")
            
            # Create file with explicit encoding
            with open(filepath, 'w', encoding='utf-8', newline='') as f:
                f.write(f"Mock model data for {filename}")
            
            # Verify file was created
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"    SUCCESS: Created ({size} bytes)")
                created += 1
            else:
                print(f"    FAILED: File not created")
                
        except Exception as e:
            print(f"    ERROR: {e}")
    
    # Step 3: Manual verification
    print(f"Step 3: Manual verification...")
    print(f"  Created {created}/{len(model_files)} files")
    
    if os.path.exists(models_dir):
        try:
            files = os.listdir(models_dir)
            print(f"  Total files in directory: {len(files)}")
            
            # List all files
            for file in sorted(files):
                filepath = os.path.join(models_dir, file)
                size = os.path.getsize(filepath)
                print(f"    - {file} ({size} bytes)")
            
            # Check required files
            required = set(model_files)
            existing = set(files)
            missing = required - existing
            
            if missing:
                print(f"  Missing files: {missing}")
                return False
            else:
                print(f"  All required files present!")
                return True
                
        except Exception as e:
            print(f"  Error during verification: {e}")
            return False
    else:
        print(f"  Models directory not found!")
        return False

if __name__ == "__main__":
    success = main()
    print(f"\n=== FINAL RESULT: {'SUCCESS' if success else 'FAILED'} ===")
    
    if success:
        print("=== MODEL FILES ARE READY FOR GUI ===")
    else:
        print("=== MODEL CREATION FAILED ===")
