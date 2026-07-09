# -*- coding: utf-8 -*-
"""
Final Execution - Complete Training with Results Display
"""

import pandas as pd
import numpy as np
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import r2_score, mean_squared_error, mean_absolute_error
import xgboost as xgb
import joblib
import os
import warnings
warnings.filterwarnings('ignore')

def final_execution():
    print("="*80)
    print("           AI EDUCATIONAL TRANSFORMATION SYSTEM - FINAL EXECUTION")
    print("="*80)
    
    # Load data
    print("Loading dataset...")
    df = pd.read_csv('data/comprehensive_school_data.csv')
    print(f"Dataset: {len(df)} schools × {len(df.columns)} features")
    
    # Prepare data
    print("Preparing data for training...")
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
    rf_mse = mean_squared_error(y_test, rf_pred)
    rf_mae = mean_absolute_error(y_test, rf_pred)
    
    print(f"Random Forest Results:")
    print(f"  R² Score: {rf_r2:.4f}")
    print(f"  MSE: {rf_mse:.4f}")
    print(f"  MAE: {rf_mae:.4f}")
    print(f"  RMSE: {np.sqrt(rf_mse):.4f}")
    
    # Train XGBoost
    print("\nTraining XGBoost...")
    xgb_model = xgb.XGBRegressor(random_state=42)
    xgb_model.fit(X_train_scaled, y_train)
    xgb_pred = xgb_model.predict(X_test_scaled)
    xgb_r2 = r2_score(y_test, xgb_pred)
    xgb_mse = mean_squared_error(y_test, xgb_pred)
    xgb_mae = mean_absolute_error(y_test, xgb_pred)
    
    print(f"XGBoost Results:")
    print(f"  R² Score: {xgb_r2:.4f}")
    print(f"  MSE: {xgb_mse:.4f}")
    print(f"  MAE: {xgb_mae:.4f}")
    print(f"  RMSE: {np.sqrt(xgb_mse):.4f}")
    
    # Save models
    print("\nSaving models...")
    os.makedirs('models', exist_ok=True)
    joblib.dump(rf, 'models/random_forest_model.joblib')
    joblib.dump(xgb_model, 'models/xgboost_model.joblib')
    joblib.dump(scaler, 'models/scaler.joblib')
    joblib.dump(X.columns.tolist(), 'models/feature_names.joblib')
    joblib.dump(rf.feature_importances_, 'models/feature_importance.joblib')
    print("Models saved successfully!")
    
    # Feature importance
    print("\nTop 10 Most Important Features:")
    importance_df = pd.DataFrame({
        'feature': X.columns,
        'importance': rf.feature_importances_
    }).sort_values('importance', ascending=False)
    
    for i, row in importance_df.head(10).iterrows():
        print(f"  {i+1}. {row['feature']}: {row['importance']:.4f}")
    
    # Final results
    print("\n" + "="*80)
    print("                    FINAL TRAINING RESULTS")
    print("="*80)
    
    print(f"Dataset Size: {len(df)} schools")
    print(f"Features: {len(X.columns)}")
    print(f"Training Samples: {len(X_train)}")
    print(f"Test Samples: {len(X_test)}")
    
    print(f"\nRandom Forest Performance:")
    print(f"  R² Score: {rf_r2:.4f}")
    print(f"  MSE: {rf_mse:.4f}")
    print(f"  MAE: {rf_mae:.4f}")
    
    print(f"\nXGBoost Performance:")
    print(f"  R² Score: {xgb_r2:.4f}")
    print(f"  MSE: {xgb_mse:.4f}")
    print(f"  MAE: {xgb_mae:.4f}")
    
    # Check for NaN
    nan_detected = np.isnan(rf_r2) or np.isnan(xgb_r2)
    
    if nan_detected:
        print(f"\nPROBLEM STATUS: FAILED - NaN values detected!")
        success = False
    else:
        print(f"\nPROBLEM STATUS: SOLVED - No NaN values!")
        success = True
    
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
    
    print(f"Overall Performance: {rating}")
    print(f"Average R² Score: {avg_r2:.4f}")
    
    # Arabic Summary
    print("\n" + "="*80)
    print("                           Arabic Summary")
    print("="*80)
    print(f"Dataset: {len(df)} schools")
    print(f"Random Forest R²: {rf_r2:.4f}")
    print(f"XGBoost R²: {xgb_r2:.4f}")
    print(f"Average R²: {avg_r2:.4f}")
    print(f"Performance: {rating}")
    print(f"Problem Status: {'RESOLVED' if success else 'PERSISTENT'}")
    
    print("="*80)
    return success, rf_r2, xgb_r2

if __name__ == "__main__":
    success, rf_r2, xgb_r2 = final_execution()
    
    print(f"\nFINAL STATUS:")
    print(f"Success: {success}")
    print(f"Random Forest R²: {rf_r2:.4f}")
    print(f"XGBoost R²: {xgb_r2:.4f}")
    print(f"Problem Solved: {success}")
