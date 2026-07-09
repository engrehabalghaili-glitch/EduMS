import os
import sys

def create_models():
    print("=== CREATING MODEL FILES FOR GUI ===")
    
    # Use absolute path
    script_dir = os.path.dirname(os.path.abspath(__file__))
    models_dir = os.path.join(script_dir, 'models')
    
    print(f"Script directory: {script_dir}")
    print(f"Models directory: {models_dir}")
    
    # Create directory
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
    
    # Create files
    created = 0
    for filename in model_files:
        filepath = os.path.join(models_dir, filename)
        try:
            with open(filepath, 'w') as f:
                f.write(f"Mock model data for {filename}")
            print(f"Created: {filename}")
            created += 1
        except Exception as e:
            print(f"Error creating {filename}: {e}")
    
    # Verify
    print(f"\nCreated {created}/{len(model_files)} files")
    
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Files in directory: {len(files)}")
        
        required = set(model_files)
        existing = set(files)
        missing = required - existing
        
        if missing:
            print(f"Missing: {missing}")
            return False
        else:
            print("All files created!")
            return True
    else:
        print("Directory not found!")
        return False

if __name__ == "__main__":
    success = create_models()
    print(f"\nResult: {'SUCCESS' if success else 'FAILED'}")
