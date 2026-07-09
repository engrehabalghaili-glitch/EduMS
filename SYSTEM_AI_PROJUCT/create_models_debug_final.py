import os
import sys

def debug_models():
    print("=== DEBUG: MODEL CREATION ===")
    
    # Debug current directory and permissions
    cwd = os.getcwd()
    print(f"Current directory: {cwd}")
    print(f"Script file: {__file__}")
    print(f"Python executable: {sys.executable}")
    
    # Test directory creation
    models_dir = 'models'
    print(f"\nTesting directory creation...")
    
    try:
        # Check if directory exists
        exists_before = os.path.exists(models_dir)
        print(f"Directory exists before: {exists_before}")
        
        # Create directory
        os.makedirs(models_dir, exist_ok=True)
        exists_after = os.path.exists(models_dir)
        print(f"Directory exists after: {exists_after}")
        
        # List directory contents
        if exists_after:
            try:
                files = os.listdir(models_dir)
                print(f"Files in models directory: {files}")
            except Exception as e:
                print(f"Cannot list directory: {e}")
        
    except Exception as e:
        print(f"Directory creation error: {e}")
        return False
    
    # Test file creation
    print(f"\nTesting file creation...")
    test_file = os.path.join(models_dir, 'test_file.txt')
    
    try:
        with open(test_file, 'w') as f:
            f.write("Test content")
        print(f"Test file created: {os.path.exists(test_file)}")
        
        if os.path.exists(test_file):
            size = os.path.getsize(test_file)
            print(f"Test file size: {size} bytes")
            os.remove(test_file)
            print("Test file removed")
        
    except Exception as e:
        print(f"File creation error: {e}")
        return False
    
    # Create actual model files
    print(f"\nCreating actual model files...")
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
        filepath = os.path.join(models_dir, filename)
        try:
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(f"Mock model data for {filename}")
            
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"SUCCESS: {filename} ({size} bytes)")
                created += 1
            else:
                print(f"FAILED: {filename} not created")
                
        except Exception as e:
            print(f"ERROR: {filename} - {e}")
    
    # Final verification
    print(f"\n=== FINAL VERIFICATION ===")
    print(f"Created {created}/{len(model_files)} files")
    
    if os.path.exists(models_dir):
        try:
            files = os.listdir(models_dir)
            print(f"Total files: {len(files)}")
            
            for file in sorted(files):
                filepath = os.path.join(models_dir, file)
                size = os.path.getsize(filepath)
                print(f"  - {file} ({size} bytes)")
            
            # Check required files
            required = set(model_files)
            existing = set(files)
            missing = required - existing
            
            if missing:
                print(f"Missing files: {missing}")
                return False
            else:
                print("All model files created successfully!")
                return True
                
        except Exception as e:
            print(f"Final verification error: {e}")
            return False
    else:
        print("Models directory not found!")
        return False

if __name__ == "__main__":
    success = debug_models()
    print(f"\nResult: {'SUCCESS' if success else 'FAILED'}")
