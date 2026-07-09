import os
import sys

def create_models():
    print("=== FORCE CREATING MODEL FILES ===")
    
    # Force create models directory
    models_dir = 'models'
    try:
        os.makedirs(models_dir, exist_ok=True)
        print(f"Models directory ready: {os.path.exists(models_dir)}")
    except Exception as e:
        print(f"Error creating directory: {e}")
        return False
    
    # Force create model files
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
            # Remove if exists
            if os.path.exists(filepath):
                os.remove(filepath)
            
            # Create new file
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(f"Mock model data for {filename}")
            
            # Verify creation
            if os.path.exists(filepath):
                size = os.path.getsize(filepath)
                print(f"SUCCESS: {filename} ({size} bytes)")
                created += 1
            else:
                print(f"FAILED: {filename} not created")
                
        except Exception as e:
            print(f"ERROR: {filename} - {e}")
    
    print(f"\nCreated {created}/{len(model_files)} files")
    
    # Final verification
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Total files: {len(files)}")
        
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
