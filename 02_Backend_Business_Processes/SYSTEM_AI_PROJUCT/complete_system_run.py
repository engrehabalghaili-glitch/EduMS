# -*- coding: utf-8 -*-
"""
Complete System Run - Final Verification
"""

import pandas as pd
import numpy as np
import os
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import r2_score, mean_squared_error, mean_absolute_error
import xgboost as xgb
import joblib
import warnings
warnings.filterwarnings('ignore')

def complete_system_run():
    print("="*80)
    print("           COMPLETE SYSTEM RUN - FINAL VERIFICATION")
    print("="*80)
    
    success = True
    
    # Step 1: Verify Data
    print("\n[STEP 1] Data Verification")
    print("-" * 50)
    try:
        if not os.path.exists('data/comprehensive_school_data.csv'):
            print("ERROR: Data file not found!")
            return False
            
        df = pd.read_csv('data/comprehensive_school_data.csv')
        print(f"SUCCESS: Loaded {len(df)} schools with {len(df.columns)} features")
        print(f"Target range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
        
        if len(df) < 100:
            print("WARNING: Dataset might be too small for reliable training")
        
    except Exception as e:
        print(f"ERROR: Failed to load data - {e}")
        return False
    
    # Step 2: Data Preparation
    print("\n[STEP 2] Data Preparation")
    print("-" * 50)
    try:
        X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
        y = df['Overall_School_Quality_Score']
        
        # Handle categorical variables
        categorical_cols = X.select_dtypes('object').columns
        label_encoders = {}
        
        for col in categorical_cols:
            le = LabelEncoder()
            X[col] = le.fit_transform(X[col])
            label_encoders[col] = le
        
        # Split data
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
        
        # Scale features
        scaler = StandardScaler()
        X_train_scaled = scaler.fit_transform(X_train)
        X_test_scaled = scaler.transform(X_test)
        
        print(f"SUCCESS: Prepared {len(X_train)} training and {len(X_test)} test samples")
        print(f"Features: {len(X.columns)}")
        
    except Exception as e:
        print(f"ERROR: Data preparation failed - {e}")
        return False
    
    # Step 3: Model Training
    print("\n[STEP 3] Model Training")
    print("-" * 50)
    
    # Random Forest
    try:
        print("Training Random Forest...")
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
        
        if np.isnan(rf_r2):
            print("ERROR: Random Forest R² is NaN!")
            success = False
        
    except Exception as e:
        print(f"ERROR: Random Forest training failed - {e}")
        success = False
    
    # XGBoost
    try:
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
        
        if np.isnan(xgb_r2):
            print("ERROR: XGBoost R² is NaN!")
            success = False
        
    except Exception as e:
        print(f"ERROR: XGBoost training failed - {e}")
        success = False
    
    # Step 4: Save Models
    print("\n[STEP 4] Saving Models")
    print("-" * 50)
    try:
        os.makedirs('models', exist_ok=True)
        
        joblib.dump(rf, 'models/random_forest_model.joblib')
        joblib.dump(xgb_model, 'models/xgboost_model.joblib')
        joblib.dump(scaler, 'models/scaler.joblib')
        joblib.dump(label_encoders, 'models/label_encoders.joblib')
        joblib.dump(X.columns.tolist(), 'models/feature_names.joblib')
        joblib.dump(rf.feature_importances_, 'models/feature_importance.joblib')
        
        print("SUCCESS: All models saved to models/ directory")
        
    except Exception as e:
        print(f"ERROR: Failed to save models - {e}")
        success = False
    
    # Step 5: Feature Importance Analysis
    print("\n[STEP 5] Feature Importance Analysis")
    print("-" * 50)
    try:
        importance_df = pd.DataFrame({
            'feature': X.columns,
            'importance': rf.feature_importances_
        }).sort_values('importance', ascending=False)
        
        print("Top 10 Most Important Features:")
        for i, row in importance_df.head(10).iterrows():
            print(f"  {i+1}. {row['feature']}: {row['importance']:.4f}")
        
    except Exception as e:
        print(f"WARNING: Feature importance analysis failed - {e}")
    
    # Step 6: Final Assessment
    print("\n[STEP 6] Final Assessment")
    print("-" * 50)
    
    print(f"Dataset Size: {len(df)} schools")
    print(f"Training Samples: {len(X_train)}")
    print(f"Test Samples: {len(X_test)}")
    print(f"Features: {len(X.columns)}")
    
    if not np.isnan(rf_r2) and not np.isnan(xgb_r2):
        avg_r2 = (rf_r2 + xgb_r2) / 2
        
        if avg_r2 > 0.8:
            performance = "EXCELLENT"
        elif avg_r2 > 0.6:
            performance = "GOOD"
        elif avg_r2 > 0.4:
            performance = "ACCEPTABLE"
        else:
            performance = "NEEDS IMPROVEMENT"
        
        print(f"\nPerformance Summary:")
        print(f"  Random Forest R²: {rf_r2:.4f}")
        print(f"  XGBoost R²: {xgb_r2:.4f}")
        print(f"  Average R²: {avg_r2:.4f}")
        print(f"  Performance Level: {performance}")
        print(f"  Problem Status: SOLVED - No NaN values!")
        
    else:
        print(f"\nERROR: NaN values detected in R² scores!")
        performance = "FAILED"
        success = False
    
    # Arabic Summary
    print("\n" + "="*80)
    print("                           Arabic Summary")
    print("="*80)
    print(f"Dataset: {len(df)} schools")
    print(f"Random Forest R²: {rf_r2:.4f}")
    print(f"XGBoost R²: {xgb_r2:.4f}")
    print(f"Performance: {performance}")
    print(f"Problem Status: {'RESOLVED' if success else 'PERSISTS'}")
    
    print("="*80)
    return success

if __name__ == "__main__":
    success = complete_system_run()
    if success:
        print("\nSYSTEM RUN COMPLETED SUCCESSFULLY!")
        print("The AI Educational Transformation System is ready for use.")
    else:
        print("\nSYSTEM RUN FAILED!")
        print("Please check the errors above and try again.")
