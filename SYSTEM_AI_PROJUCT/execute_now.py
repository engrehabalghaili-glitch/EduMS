# -*- coding: utf-8 -*-
"""
Execute Now - Direct Training Execution
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
print("AI EDUCATIONAL SYSTEM - TRAINING EXECUTION")
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

print(f"Training set: {len(X_train)} samples")
print(f"Test set: {len(X_test)} samples")

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
    print("Status: FAILED")
else:
    print("\nSUCCESS: No NaN values!")
    print("Status: PASSED")

# Performance rating
avg_r2 = (rf_r2 + xgb_r2) / 2
if avg_r2 > 0.8:
    rating = "EXCELLENT"
elif avg_r2 > 0.6:
    rating = "GOOD"
elif avg_r2 > 0.4:
    rating = "ACCEPTABLE"
else:
    rating = "NEEDS IMPROVEMENT"

print(f"Average R²: {avg_r2:.4f}")
print(f"Performance: {rating}")

# Arabic summary
print("\n" + "="*60)
print("Arabic Summary")
print("="*60)
print(f"Random Forest R²: {rf_r2:.4f}")
print(f"XGBoost R²: {xgb_r2:.4f}")
print(f"Average R²: {avg_r2:.4f}")
print(f"Performance: {rating}")
print(f"Problem Status: {'RESOLVED' if not (np.isnan(rf_r2) or np.isnan(xgb_r2)) else 'PERSISTENT'}")

print("="*60)
