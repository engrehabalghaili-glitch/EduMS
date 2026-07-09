import os
import sys

def create_models():
    print("Creating model files...")
    
    # Create models directory
    models_dir = 'models'
    if not os.path.exists(models_dir):
        os.makedirs(models_dir)
        print(f"Created directory: {models_dir}")
    
    # Create simple mock files
    files = [
        'random_forest_model.joblib',
        'xgboost_model.joblib', 
        'scaler.joblib',
        'label_encoders.joblib',
        'feature_names.joblib',
        'feature_importance.joblib'
    ]
    
    for file in files:
        filepath = os.path.join(models_dir, file)
        with open(filepath, 'wb') as f:
            f.write(b"mock_model_data")
        print(f"Created: {file}")
    
    print("All model files created!")
    return True

if __name__ == "__main__":
    create_models()
