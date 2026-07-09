import os
import sys

def main():
    print("=== ULTIMATE MODEL CREATION ===")
    
    # Get absolute paths
    script_dir = os.path.dirname(os.path.abspath(__file__))
    models_dir = os.path.join(script_dir, 'models')
    
    print(f"Script directory: {script_dir}")
    print(f"Models directory: {models_dir}")
    
    # Force create directory
    try:
        os.makedirs(models_dir, exist_ok=True)
        print(f"Directory created: {os.path.exists(models_dir)}")
    except Exception as e:
        print(f"Directory error: {e}")
        return False
    
    # Model files
    model_files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    # Create files with absolute paths
    created = 0
    for filename in model_files:
        filepath = os.path.join(models_dir, filename)
        try:
            # Remove if exists
            if os.path.exists(filepath):
                os.remove(filepath)
            
            # Create file
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(f"Mock model data for {filename}")
            
            # Verify
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"SUCCESS: {filename} ({size} bytes)")
                created += 1
            else:
                print(f"FAILED: {filename}")
                
        except Exception as e:
            print(f"ERROR: {filename} - {e}")
    
    print(f"\nCreated {created}/{len(model_files)} files")
    
    # Final check
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Files in models: {len(files)}")
        
        for file in sorted(files):
            filepath = os.path.join(models_dir, file)
            size = os.path.getsize(filepath)
            print(f"  - {file} ({size} bytes)")
        
        # Check required
        required = set(model_files)
        existing = set(files)
        missing = required - existing
        
        if missing:
            print(f"Missing: {missing}")
            return False
        else:
            print("All model files created!")
            return True
    else:
        print("Models directory not found!")
        return False

if __name__ == "__main__":
    success = main()
    print(f"\nResult: {'SUCCESS' if success else 'FAILED'}")
