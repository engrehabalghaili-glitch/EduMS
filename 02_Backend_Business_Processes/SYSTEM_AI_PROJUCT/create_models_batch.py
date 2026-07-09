import os
import sys

def main():
    print("Creating model files for GUI...")
    
    # Get current directory
    current_dir = os.getcwd()
    print(f"Current directory: {current_dir}")
    
    # Create models directory
    models_dir = os.path.join(current_dir, 'models')
    if not os.path.exists(models_dir):
        os.makedirs(models_dir)
        print(f"Created: {models_dir}")
    else:
        print(f"Directory exists: {models_dir}")
    
    # Create mock model files
    files_to_create = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    for filename in files_to_create:
        filepath = os.path.join(models_dir, filename)
        try:
            with open(filepath, 'w') as f:
                f.write(f"Mock model data for {filename}")
            print(f"Created: {filename}")
        except Exception as e:
            print(f"Error creating {filename}: {e}")
    
    # Verify creation
    print("\n=== Verification ===")
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Files in models directory: {len(files)}")
        for file in sorted(files):
            filepath = os.path.join(models_dir, file)
            size = os.path.getsize(filepath)
            print(f"  - {file} ({size} bytes)")
    else:
        print("Models directory not found!")
    
    print("\n=== Done ===")

if __name__ == "__main__":
    main()
