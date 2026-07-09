import pandas as pd
import numpy as np
import os
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import r2_score, mean_squared_error
import joblib

# Load and check the data
data_path = 'data/comprehensive_school_data.csv'
if not os.path.exists(data_path):
    print('Data file not found!')
    exit()

print('Loading data...')
df = pd.read_csv(data_path)
print(f'Loaded {len(df)} schools with {len(df.columns)} features')

# Prepare data for training
print('Preparing data for training...')
X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
y = df['Overall_School_Quality_Score']

# Handle categorical variables
print('Handling categorical variables...')
label_encoders = {}
for col in X.select_dtypes('object').columns:
    le = LabelEncoder()
    X[col] = le.fit_transform(X[col].astype(str))
    label_encoders[col] = le

# Split data
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Scale features
print('Scaling features...')
scaler = StandardScaler()
X_train_scaled = scaler.fit_transform(X_train)
X_test_scaled = scaler.transform(X_test)

# Train models
print('Training Random Forest...')
rf_model = RandomForestRegressor(n_estimators=100, random_state=42)
rf_model.fit(X_train_scaled, y_train)
rf_pred = rf_model.predict(X_test_scaled)
rf_r2 = r2_score(y_test, rf_pred)
rf_mse = mean_squared_error(y_test, rf_pred)

print('Training XGBoost...')
try:
    import xgboost as xgb
    xgb_model = xgb.XGBRegressor(random_state=42)
    xgb_model.fit(X_train_scaled, y_train)
    xgb_pred = xgb_model.predict(X_test_scaled)
    xgb_r2 = r2_score(y_test, xgb_pred)
    xgb_mse = mean_squared_error(y_test, xgb_pred)
except ImportError:
    print('XGBoost not available, skipping...')
    xgb_r2 = None
    xgb_mse = None

# Print results
print('\n' + '='*60)
print('MODEL TRAINING RESULTS')
print('='*60)
print(f'Dataset size: {len(df)} schools')
print(f'Training set: {len(X_train)} schools')
print(f'Test set: {len(X_test)} schools')
print(f'Features: {len(X.columns)}')

print(f'\nRandom Forest Results:')
print(f'  R² Score: {rf_r2:.4f}')
print(f'  MSE: {rf_mse:.4f}')
print(f'  RMSE: {np.sqrt(rf_mse):.4f}')

if xgb_r2 is not None:
    print(f'\nXGBoost Results:')
    print(f'  R² Score: {xgb_r2:.4f}')
    print(f'  MSE: {xgb_mse:.4f}')
    print(f'  RMSE: {np.sqrt(xgb_mse):.4f}')

# Feature importance
feature_importance = rf_model.feature_importances_
feature_names = X.columns
importance_df = pd.DataFrame({
    'feature': feature_names,
    'importance': feature_importance
}).sort_values('importance', ascending=False)

print(f'\nTop 10 Important Features:')
print(importance_df.head(10).to_string(index=False))

print('='*60)
