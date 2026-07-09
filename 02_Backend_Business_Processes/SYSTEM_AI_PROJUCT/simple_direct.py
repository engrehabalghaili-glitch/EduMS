# -*- coding: utf-8 -*-
"""
Simple Direct Execution - Show Results Immediately
"""

import pandas as pd
import numpy as np
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import r2_score, mean_squared_error
import xgboost as xgb
import warnings
warnings.filterwarnings('ignore')

print("="*60)
print("AI EDUCATIONAL SYSTEM - TRAINING RESULTS")
print("="*60)

# Load data
df = pd.read_csv('data/comprehensive_school_data.csv')
print(f"Data loaded: {len(df)} schools")

# Prepare data
X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
y = df['Overall_School_Quality_Score']

# Handle categoricals
for col in X.select_dtypes('object').columns:
    X[col] = LabelEncoder().fit_transform(X[col])

# Split and scale
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
scaler = StandardScaler()
X_train_scaled = scaler.fit_transform(X_train)
X_test_scaled = scaler.transform(X_test)

# Train Random Forest
print("\nTraining Random Forest...")
rf = RandomForestRegressor(n_estimators=100, random_state=42)
rf.fit(X_train_scaled, y_train)
rf_pred = rf.predict(X_test_scaled)
rf_r2 = r2_score(y_test, rf_pred)

# Train XGBoost
print("Training XGBoost...")
xgb_model = xgb.XGBRegressor(random_state=42)
xgb_model.fit(X_train_scaled, y_train)
xgb_pred = xgb_model.predict(X_test_scaled)
xgb_r2 = r2_score(y_test, xgb_pred)

# Results
print("\n" + "="*60)
print("TRAINING RESULTS")
print("="*60)
print(f"Random Forest R²: {rf_r2:.4f}")
print(f"XGBoost R²: {xgb_r2:.4f}")

# Check for NaN
if np.isnan(rf_r2) or np.isnan(xgb_r2):
    print("\nPROBLEM: NaN values detected!")
    status = "FAILED"
else:
    print("\nSUCCESS: No NaN values!")
    status = "PASSED"

print(f"Status: {status}")
print("="*60)

# Arabic summary
print("\nArabic Summary:")
print(f"Random Forest R²: {rf_r2:.4f}")
print(f"XGBoost R²: {xgb_r2:.4f}")
print(f"State: {'SOLVED' if status == 'PASSED' else 'FAILED'}")
