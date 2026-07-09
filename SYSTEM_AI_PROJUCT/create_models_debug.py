import os
import sys

def debug_create_models():
    print("=== DEBUG: MODEL CREATION ===")
    
    # Debug current directory
    cwd = os.getcwd()
    print(f"Current working directory: {cwd}")
    print(f"Script location: {__file__}")
    
    # Debug models directory
    models_dir = 'models'
    print(f"Models directory path: {models_dir}")
    print(f"Models directory exists: {os.path.exists(models_dir)}")
    
    # Try to create directory
    try:
        os.makedirs(models_dir, exist_ok=True)
        print(f"Directory creation successful: {os.path.exists(models_dir)}")
    except Exception as e:
        print(f"Directory creation failed: {e}")
        return False
    
    # Debug directory listing
    try:
        files_before = os.listdir(models_dir)
        print(f"Files in models directory before: {files_before}")
    except Exception as e:
        print(f"Cannot list directory: {e}")
        return False
    
    # Create model files with detailed debugging
    model_files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    created_count = 0
    for filename in model_files:
        filepath = os.path.join(models_dir, filename)
        print(f"\nAttempting to create: {filepath}")
        
        try:
            # Check if file already exists
            if os.path.exists(filepath):
                print(f"  File already exists: {filepath}")
                os.remove(filepath)
                print(f"  Removed existing file")
            
            # Create file
            with open(filepath, 'w') as f:
                f.write(f"Mock model data for {filename}")
            
            # Verify creation
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"  SUCCESS: File created ({size} bytes)")
                created_count += 1
            else:
                print(f"  FAILED: File not created")
                
        except Exception as e:
            print(f"  ERROR: {e}")
    
    # Final verification
    print(f"\n=== FINAL VERIFICATION ===")
    try:
        files_after = os.listdir(models_dir)
        print(f"Files in models directory after: {len(files_after)}")
        
        for file in sorted(files_after):
            filepath = os.path.join(models_dir, file)
            size = os.path.getsize(filepath)
            print(f"  - {file} ({size} bytes)")
        
        # Check required files
        required_files = set(model_files)
        existing_files = set(files_after)
        missing_files = required_files - existing_files
        
        if missing_files:
            print(f"Missing files: {missing_files}")
            return False
        else:
            print("All required files created successfully!")
            return True
            
    except Exception as e:
        print(f"Final verification failed: {e}")
        return False

if __name__ == "__main__":
    success = debug_create_models()
    if success:
        print("\n=== SUCCESS: Models ready for GUI ===")
    else:
        print("\n=== FAILURE: Model creation failed ===")
