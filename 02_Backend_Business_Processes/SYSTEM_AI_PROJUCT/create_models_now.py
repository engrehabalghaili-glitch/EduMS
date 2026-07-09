import os
import numpy as np
import joblib
from sklearn.ensemble import RandomForestRegressor
from sklearn.preprocessing import StandardScaler, LabelEncoder

# Create models directory
if not os.path.exists('models'):
    os.makedirs('models')
    print("Created models directory")

# Create mock data
np.random.seed(42)
X = np.random.rand(100, 20)
y = np.random.rand(100)

# Create models
rf_model = RandomForestRegressor(n_estimators=10, random_state=42)
rf_model.fit(X, y)

xgb_model = RandomForestRegressor(n_estimators=10, random_state=42)
xgb_model.fit(X, y)

scaler = StandardScaler()
scaler.fit(X)

label_encoders = {'Region': LabelEncoder(), 'School_Type': LabelEncoder()}
label_encoders['Region'].fit(['North', 'South', 'East', 'West'])
label_encoders['School_Type'].fit(['Public', 'Private', 'Charter'])

feature_names = [f'Feature_{i}' for i in range(20)]
feature_importance = {f'Feature_{i}': 0.05 for i in range(20)}

# Save models
try:
    joblib.dump(rf_model, 'models/random_forest_model.joblib')
    print("Saved: random_forest_model.joblib")
    
    joblib.dump(xgb_model, 'models/xgboost_model.joblib')
    print("Saved: xgboost_model.joblib")
    
    joblib.dump(scaler, 'models/scaler.joblib')
    print("Saved: scaler.joblib")
    
    joblib.dump(label_encoders, 'models/label_encoders.joblib')
    print("Saved: label_encoders.joblib")
    
    joblib.dump(feature_names, 'models/feature_names.joblib')
    print("Saved: feature_names.joblib")
    
    joblib.dump(feature_importance, 'models/feature_importance.joblib')
    print("Saved: feature_importance.joblib")
    
    print("All models created successfully!")
except Exception as e:
    print(f"Error: {e}")

# List files
print("\nFiles in models directory:")
for file in os.listdir('models'):
    print(f"  - {file}")
