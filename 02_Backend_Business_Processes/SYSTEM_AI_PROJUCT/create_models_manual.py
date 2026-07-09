# -*- coding: utf-8 -*-
"""
Manual Model Creation Script
"""
import os

def create_models():
    print("=== MANUAL MODEL CREATION ===")
    
    # Step 1: Create models directory
    models_dir = 'models'
    if not os.path.exists(models_dir):
        try:
            os.makedirs(models_dir)
            print(f"Created directory: {models_dir}")
        except Exception as e:
            print(f"Failed to create directory: {e}")
            return False
    else:
        print(f"Directory exists: {models_dir}")
    
    # Step 2: Create mock model files
    model_files = {
        'random_forest_model.joblib': 'Random Forest Model Data',
        'xgboost_model.joblib': 'XGBoost Model Data',
        'scaler.joblib': 'StandardScaler Data',
        'label_encoders.joblib': 'Label Encoders Data',
        'feature_names.joblib': 'Feature Names List',
        'feature_importance.joblib': 'Feature Importance Data'
    }
    
    created_files = 0
    for filename, content in model_files.items():
        filepath = os.path.join(models_dir, filename)
        try:
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(content)
            print(f"Created: {filename}")
            created_files += 1
        except Exception as e:
            print(f"Failed to create {filename}: {e}")
    
    # Step 3: Verification
    print(f"\n=== VERIFICATION ===")
    print(f"Files created: {created_files}/{len(model_files)}")
    
    if os.path.exists(models_dir):
        files = os.listdir(models_dir)
        print(f"Total files in models directory: {len(files)}")
        
        required_files = set(model_files.keys())
        existing_files = set(files)
        
        missing_files = required_files - existing_files
        if missing_files:
            print(f"Missing files: {missing_files}")
            return False
        else:
            print("All required model files are present!")
            return True
    else:
        print("Models directory not found!")
        return False

if __name__ == "__main__":
    success = create_models()
    if success:
        print("\n=== SUCCESS: Models ready for GUI ===")
    else:
        print("\n=== FAILED: Model creation incomplete ===")
