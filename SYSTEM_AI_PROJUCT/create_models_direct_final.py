import os
import sys

def main():
    print("=== CREATING MODEL FILES FOR GUI ===")
    
    # Create models directory
    models_dir = 'models'
    if not os.path.exists(models_dir):
        os.makedirs(models_dir)
        print(f"Created directory: {models_dir}")
    else:
        print(f"Directory exists: {models_dir}")
    
    # Define model files
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
        
        for file in sorted(files):
            size = os.path.getsize(os.path.join(models_dir, file))
            print(f"  - {file} ({size} bytes)")
        
        # Check required files
        required = set(model_files)
        existing = set(files)
        missing = required - existing
        
        if missing:
            print(f"Missing: {missing}")
            return False
        else:
            print("All files created successfully!")
            return True
    else:
        print("Directory not found!")
        return False

if __name__ == "__main__":
    success = main()
    print(f"\nResult: {'SUCCESS' if success else 'FAILED'}")
