import os
import sys

def create_models():
    print("=== CREATING MODEL FILES FOR GUI ===")
    
    # Create models directory
    models_dir = 'models'
    if not os.path.exists(models_dir):
        os.makedirs(models_dir)
        print(f"Created directory: {models_dir}")
    else:
        print(f"Directory exists: {models_dir}")
    
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
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(f"Mock model data for {filename}")
            print(f"Created: {filename}")
            created += 1
        except Exception as e:
            print(f"Error creating {filename}: {e}")
    
    # Verify
    print(f"\nCreated {created}/{len(model_files)} files")
    
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Files in models directory: {len(files)}")
        
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
    else:
        print("Models directory not found!")
        return False

if __name__ == "__main__":
    success = create_models()
    print(f"\nResult: {'SUCCESS' if success else 'FAILED'}")
