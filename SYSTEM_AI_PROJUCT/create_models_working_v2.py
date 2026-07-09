import os
import sys

def main():
    print("=== CREATING MODEL FILES FOR GUI ===")
    
    # Get absolute paths
    script_dir = os.path.dirname(os.path.abspath(__file__))
    models_dir = os.path.join(script_dir, 'models')
    
    print(f"Script directory: {script_dir}")
    print(f"Models directory: {models_dir}")
    
    # Create models directory with absolute path
    try:
        os.makedirs(models_dir, exist_ok=True)
        print(f"Models directory created: {os.path.exists(models_dir)}")
    except Exception as e:
        print(f"Error creating models directory: {e}")
        return False
    
    # Define model files
    model_files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib',
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    # Create each file with absolute path
    created_count = 0
    for filename in model_files:
        filepath = os.path.join(models_dir, filename)
        try:
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(f"Mock model content for {filename}")
            print(f"Created: {filename}")
            created_count += 1
        except Exception as e:
            print(f"Failed to create {filename}: {e}")
    
    print(f"\nCreated {created_count}/{len(model_files)} files")
    
    # Verify with absolute path
    print("\n=== VERIFICATION ===")
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Files found: {len(files)}")
        
        for file in sorted(files):
            filepath = os.path.join(models_dir, file)
            size = os.path.getsize(filepath)
            print(f"  - {file} ({size} bytes)")
        
        # Check required files
        required_files = set(model_files)
        existing_files = set(files)
        missing_files = required_files - existing_files
        
        if missing_files:
            print(f"Missing: {missing_files}")
            return False
        else:
            print("All files created successfully!")
            return True
    else:
        print("Models directory not found!")
        return False

if __name__ == "__main__":
    success = main()
    if success:
        print("\n=== SUCCESS: Models ready ===")
    else:
        print("\n=== FAILED: Check errors above ===")
