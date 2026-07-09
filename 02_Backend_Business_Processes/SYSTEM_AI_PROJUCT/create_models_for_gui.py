# -*- coding: utf-8 -*-
"""
Create Model Files for GUI Testing
"""
import os

print("Creating model files for GUI testing...")

# Create models directory
models_dir = 'models'
if not os.path.exists(models_dir):
    os.makedirs(models_dir)
    print(f"Created directory: {models_dir}")

# Create simple mock model files using joblib format
import joblib
import numpy as np
from sklearn.ensemble import RandomForestRegressor
from sklearn.preprocessing import StandardScaler, LabelEncoder

# Create mock data
np.random.seed(42)
X = np.random.rand(100, 20)
y = np.random.rand(100)

# Create and train simple models
rf_model = RandomForestRegressor(n_estimators=5, random_state=42)
rf_model.fit(X, y)

xgb_model = RandomForestRegressor(n_estimators=5, random_state=42)
xgb_model.fit(X, y)

# Create scaler
scaler = StandardScaler()
scaler.fit(X)

# Create label encoders
label_encoders = {
    'Region': LabelEncoder().fit(['North', 'South', 'East', 'West', 'Central']),
    'School_Type': LabelEncoder().fit(['Public', 'Private', 'Charter']),
    'Grades': LabelEncoder().fit(['K-5', '6-8', '9-12']),
    'Curriculum': LabelEncoder().fit(['National', 'International', 'Vocational'])
}

# Create feature names
feature_names = [
    'Total_Students', 'Total_Teachers', 'Total_Classrooms', 'Total_Area',
    'Math_Score', 'Science_Score', 'Reading_Score', 'Writing_Score',
    'Success_Rate', 'Attendance_Rate', 'Annual_Budget', 'Per_Student_Spending',
    'Teacher_Salary', 'Lab_Count', 'Library_Count', 'Internet_Access',
    'Participation_Rate', 'Extracurricular_Count', 'Teacher_Student_Ratio',
    'Teacher_Retention_Rate', 'Training_Hours', 'Satisfaction_Score'
]

# Create feature importance
feature_importance = {name: np.random.random() for name in feature_names}
# Normalize to sum to 1
total = sum(feature_importance.values())
feature_importance = {k: v/total for k, v in feature_importance.items()}

# Save all model files
try:
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
    
    print("\nAll model files created successfully!")
    
    # List created files
    print(f"\nFiles in {models_dir}:")
    for file in sorted(os.listdir(models_dir)):
        file_path = os.path.join(models_dir, file)
        size = os.path.getsize(file_path)
        print(f"  - {file} ({size} bytes)")
    
    print("\nModels are ready for GUI testing!")
    
except Exception as e:
    print(f"Error creating model files: {e}")
    import traceback
    traceback.print_exc()
