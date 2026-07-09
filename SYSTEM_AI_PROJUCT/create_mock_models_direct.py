# -*- coding: utf-8 -*-
"""
Create Mock Models Direct - Simple version
"""
import os
import numpy as np
import pandas as pd
import joblib
from sklearn.ensemble import RandomForestRegressor
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.datasets import make_regression

def main():
    print("Creating mock models...")
    
    # Create models directory
    models_dir = 'models'
    os.makedirs(models_dir, exist_ok=True)
    
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
        le.fit(['North', 'South', 'East', 'West', 'Central'])
        label_encoders[feature] = le
    
    # Create and train mock models
    rf_model = RandomForestRegressor(n_estimators=10, random_state=42)
    rf_model.fit(X, y)
    
    xgb_model = RandomForestRegressor(n_estimators=10, random_state=42)
    xgb_model.fit(X, y)
    
    # Create scaler
    scaler = StandardScaler()
    scaler.fit(X)
    
    # Create feature importance
    feature_importance = dict(zip(feature_names, np.random.dirichlet(np.ones(n_features))))
    
    # Save all models
    joblib.dump(rf_model, os.path.join(models_dir, 'random_forest_model.joblib'))
    print("Created: random_forest_model.joblib")
    
    joblib.dump(xgb_model, os.path.join(models_dir, 'xgboost_model.joblib'))
    print("Created: xgboost_model.joblib")
    
    joblib.dump(scaler, os.path.join(models_dir, 'scaler.joblib'))
    print("Created: scaler.joblib")
    
    joblib.dump(label_encoders, os.path.join(models_dir, 'label_encoders.joblib'))
    print("Created: label_encoders.joblib")
    
    joblib.dump(feature_names, os.path.join(models_dir, 'feature_names.joblib'))
    print("Created: feature_names.joblib")
    
    joblib.dump(feature_importance, os.path.join(models_dir, 'feature_importance.joblib'))
    print("Created: feature_importance.joblib")
    
    print("Mock models created successfully!")
    return True

if __name__ == "__main__":
    main()
