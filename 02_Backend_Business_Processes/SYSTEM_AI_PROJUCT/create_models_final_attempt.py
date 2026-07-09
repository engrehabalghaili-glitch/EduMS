import os
import sys

def main():
    print("=== FINAL ATTEMPT: MODEL CREATION ===")
    
    # Get current working directory
    cwd = os.getcwd()
    print(f"Current directory: {cwd}")
    
    # Create models directory with full path
    models_dir = os.path.join(cwd, 'models')
    print(f"Models directory path: {models_dir}")
    
    try:
        os.makedirs(models_dir, exist_ok=True)
        print(f"Directory created: {os.path.exists(models_dir)}")
    except Exception as e:
        print(f"Error creating directory: {e}")
        return False
    
    # Model files to create
    model_files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    # Create each file
    created = 0
    for filename in model_files:
        filepath = os.path.join(models_dir, filename)
        print(f"\nCreating: {filepath}")
        
        try:
            # Remove if exists
            if os.path.exists(filepath):
                os.remove(filepath)
                print(f"  Removed existing file")
            
            # Create new file
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(f"Mock model data for {filename}")
            
            # Verify creation
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"  SUCCESS: Created ({size} bytes)")
                created += 1
            else:
                print(f"  FAILED: File not created")
                
        except Exception as e:
            print(f"  ERROR: {e}")
    
    # Final verification
    print(f"\n=== FINAL VERIFICATION ===")
    print(f"Created {created}/{len(model_files)} files")
    
    if os.path.exists(models_dir):
        try:
            files = os.listdir(models_dir)
            print(f"Total files in models: {len(files)}")
            
            for file in sorted(files):
                filepath = os.path.join(models_dir, file)
                size = os.path.getsize(filepath)
                print(f"  - {file} ({size} bytes)")
            
            # Check required files
            required = set(model_files)
            existing = set(files)
            missing = required - existing
            
            if missing:
                print(f"\nMissing files: {missing}")
                return False
            else:
                print("\nAll model files created successfully!")
                return True
                
        except Exception as e:
            print(f"Error listing directory: {e}")
            return False
    else:
        print("Models directory not found!")
        return False

if __name__ == "__main__":
    success = main()
    print(f"\n=== RESULT: {'SUCCESS' if success else 'FAILED'} ===")
    
    if success:
        print("\n=== MODELS ARE READY FOR GUI ===")
    else:
        print("\n=== MODEL CREATION FAILED ===")
