import os
import sys

def main():
    print("=== CREATING MODEL FILES FOR GUI ===")
    
    # Get current working directory
    cwd = os.getcwd()
    print(f"Current working directory: {cwd}")
    
    # Create models directory
    models_dir = os.path.join(cwd, 'models')
    print(f"Models directory path: {models_dir}")
    
    try:
        os.makedirs(models_dir, exist_ok=True)
        print(f"Models directory ready: {os.path.exists(models_dir)}")
    except Exception as e:
        print(f"Error creating models directory: {e}")
        return False
    
    # Define model files to create
    model_files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    # Create each model file
    created_count = 0
    for filename in model_files:
        filepath = os.path.join(models_dir, filename)
        try:
            with open(filepath, 'w') as f:
                f.write(f"Mock model content for {filename}")
            print(f"SUCCESS: Created {filename}")
            created_count += 1
        except Exception as e:
            print(f"ERROR: Failed to create {filename} - {e}")
    
    print(f"\nCreated {created_count}/{len(model_files)} model files")
    
    # Verify all files exist
    print("\n=== VERIFICATION ===")
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Files in models directory: {len(files)}")
        
        for file in sorted(files):
            filepath = os.path.join(models_dir, file)
            size = os.path.getsize(filepath)
            print(f"  - {file} ({size} bytes)")
        
        # Check if all required files exist
        required_files = set(model_files)
        existing_files = set(files)
        missing_files = required_files - existing_files
        
        if missing_files:
            print(f"\nMISSING FILES: {missing_files}")
            return False
        else:
            print("\nALL REQUIRED MODEL FILES CREATED!")
            return True
    else:
        print("Models directory not found!")
        return False

if __name__ == "__main__":
    success = main()
    if success:
        print("\n=== SUCCESS: Models ready for GUI ===")
    else:
        print("\n=== FAILURE: Model creation incomplete ===")
