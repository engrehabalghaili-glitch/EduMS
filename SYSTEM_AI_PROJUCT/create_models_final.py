import os
import sys

def main():
    print("Creating model files for GUI...")
    
    # Create models directory
    models_dir = 'models'
    if not os.path.exists(models_dir):
        os.makedirs(models_dir)
        print(f"Created directory: {models_dir}")
    
    # Import required libraries
    try:
        import joblib
        import numpy as np
        from sklearn.ensemble import RandomForestRegressor
        from sklearn.preprocessing import StandardScaler, LabelEncoder
        print("Libraries imported successfully")
    except ImportError as e:
        print(f"Import error: {e}")
        return False
    
    # Create mock data
    np.random.seed(42)
    X = np.random.rand(100, 22)  # 22 features
    y = np.random.rand(100)
    
    # Create feature names
    feature_names = [
        'Total_Students', 'Total_Teachers', 'Total_Classrooms', 'Total_Area',
        'Math_Score', 'Science_Score', 'Reading_Score', 'Writing_Score',
        'Success_Rate', 'Attendance_Rate', 'Annual_Budget', 'Per_Student_Spending',
        'Teacher_Salary', 'Lab_Count', 'Library_Count', 'Internet_Access',
        'Participation_Rate', 'Extracurricular_Count', 'Teacher_Student_Ratio',
        'Teacher_Retention_Rate', 'Training_Hours', 'Satisfaction_Score'
    ]
    
    # Create and train models
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
    
    # Create feature importance
    feature_importance = {name: np.random.random() for name in feature_names}
    total = sum(feature_importance.values())
    feature_importance = {k: v/total for k, v in feature_importance.items()}
    
    # Save models
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
        return True
        
    except Exception as e:
        print(f"Error saving models: {e}")
        return False

if __name__ == "__main__":
    success = main()
    if success:
        print("Models are ready for GUI!")
    else:
        print("Failed to create models.")
