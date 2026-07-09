# -*- coding: utf-8 -*-
"""
Create Mock Models for GUI Testing
"""
import os
import numpy as np
import pandas as pd
import joblib
from sklearn.ensemble import RandomForestRegressor
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.datasets import make_regression

def create_mock_models():
    """Create mock model files for testing the GUI"""
    print("Creating mock models...")
    
    # Create models directory if it doesn't exist
    models_dir = 'models'
    os.makedirs(models_dir, exist_ok=True)
    
    try:
        # Generate mock data
        np.random.seed(42)
        n_samples = 1000
        n_features = 20
        
        X, y = make_regression(n_samples=n_samples, n_features=n_features, noise=0.1)
        
        # Create feature names
        feature_names = [f'Feature_{i+1}' for i in range(n_features)]
        
        # Create mock categorical encoders
        label_encoders = {}
        categorical_features = ['Region', 'School_Type', 'Grades', 'Curriculum']
        for feature in categorical_features:
            le = LabelEncoder()
            le.fit(np.random.choice(['A', 'B', 'C'], 100))
            label_encoders[feature] = le
        
        # Create and train mock models
        rf_model = RandomForestRegressor(n_estimators=10, random_state=42)
        rf_model.fit(X, y)
        
        xgb_model = RandomForestRegressor(n_estimators=10, random_state=42)  # Using RF as mock XGBoost
        xgb_model.fit(X, y)
        
        # Create scaler
        scaler = StandardScaler()
        scaler.fit(X)
        
        # Create feature importance
        feature_importance = dict(zip(feature_names, np.random.dirichlet(np.ones(n_features))))
        
        # Save all models
        joblib.dump(rf_model, os.path.join(models_dir, 'random_forest_model.joblib'))
        joblib.dump(xgb_model, os.path.join(models_dir, 'xgboost_model.joblib'))
        joblib.dump(scaler, os.path.join(models_dir, 'scaler.joblib'))
        joblib.dump(label_encoders, os.path.join(models_dir, 'label_encoders.joblib'))
        joblib.dump(feature_names, os.path.join(models_dir, 'feature_names.joblib'))
        joblib.dump(feature_importance, os.path.join(models_dir, 'feature_importance.joblib'))
        
        print("Mock models created successfully!")
        print(f"Models saved to: {models_dir}")
        
        # List created files
        for file in os.listdir(models_dir):
            print(f"  - {file}")
        
        return True
        
    except Exception as e:
        print(f"Error creating mock models: {e}")
        return False

if __name__ == "__main__":
    success = create_mock_models()
    if success:
        print("Mock models are ready for GUI testing!")
    else:
        print("Failed to create mock models.")
