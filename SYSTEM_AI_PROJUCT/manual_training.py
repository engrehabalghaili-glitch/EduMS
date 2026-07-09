# -*- coding: utf-8 -*-
"""
Manual Training Execution with Full Output Display
"""

import pandas as pd
import numpy as np
from sklearn.ensemble import RandomForestRegressor
import xgboost as xgb
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import r2_score, mean_squared_error, mean_absolute_error
import joblib
import os
import warnings
warnings.filterwarnings('ignore')

def train_models():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - MANUAL TRAINING EXECUTION")
    print("="*80)
    
    # Step 1: Load data
    print("\n[STEP 1] Loading dataset...")
    try:
        df = pd.read_csv('data/comprehensive_school_data.csv')
        print(f"   SUCCESS: Loaded {len(df)} schools with {len(df.columns)} features")
        print(f"   Target variable range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
    except Exception as e:
        print(f"   ERROR: {e}")
        return False
    
    # Step 2: Prepare data
    print("\n[STEP 2] Preparing data for training...")
    try:
        X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
        y = df['Overall_School_Quality_Score']
        
        # Handle categorical variables
        categorical_cols = X.select_dtypes('object').columns
        print(f"   Found {len(categorical_cols)} categorical columns: {list(categorical_cols)}")
        
        label_encoders = {}
        for col in categorical_cols:
            le = LabelEncoder()
            X[col] = le.fit_transform(X[col])
            label_encoders[col] = le
        
        # Split data
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
        print(f"   Training set: {len(X_train)} samples")
        print(f"   Test set: {len(X_test)} samples")
        
        # Scale features
        scaler = StandardScaler()
        X_train_scaled = scaler.fit_transform(X_train)
        X_test_scaled = scaler.transform(X_test)
        
        print("   SUCCESS: Data preparation completed")
        
    except Exception as e:
        print(f"   ERROR: {e}")
        return False
    
    # Step 3: Train Random Forest
    print("\n[STEP 3] Training Random Forest model...")
    try:
        rf = RandomForestRegressor(n_estimators=100, random_state=42)
        rf.fit(X_train_scaled, y_train)
        rf_pred = rf.predict(X_test_scaled)
        rf_r2 = r2_score(y_test, rf_pred)
        rf_mse = mean_squared_error(y_test, rf_pred)
        rf_mae = mean_absolute_error(y_test, rf_pred)
        
        print(f"   Random Forest R²: {rf_r2:.4f}")
        print(f"   Random Forest MSE: {rf_mse:.4f}")
        print(f"   Random Forest MAE: {rf_mae:.4f}")
        print(f"   Random Forest RMSE: {np.sqrt(rf_mse):.4f}")
        
        if np.isnan(rf_r2):
            print("   WARNING: R² is NaN!")
            return False
        
    except Exception as e:
        print(f"   ERROR: {e}")
        return False
    
    # Step 4: Train XGBoost
    print("\n[STEP 4] Training XGBoost model...")
    try:
        xgb_model = xgb.XGBRegressor(random_state=42)
        xgb_model.fit(X_train_scaled, y_train)
        xgb_pred = xgb_model.predict(X_test_scaled)
        xgb_r2 = r2_score(y_test, xgb_pred)
        xgb_mse = mean_squared_error(y_test, xgb_pred)
        xgb_mae = mean_absolute_error(y_test, xgb_pred)
        
        print(f"   XGBoost R²: {xgb_r2:.4f}")
        print(f"   XGBoost MSE: {xgb_mse:.4f}")
        print(f"   XGBoost MAE: {xgb_mae:.4f}")
        print(f"   XGBoost RMSE: {np.sqrt(xgb_mse):.4f}")
        
        if np.isnan(xgb_r2):
            print("   WARNING: R² is NaN!")
            return False
        
    except Exception as e:
        print(f"   ERROR: {e}")
        return False
    
    # Step 5: Feature importance
    print("\n[STEP 5] Analyzing feature importance...")
    try:
        rf_importance = rf.feature_importances_
        feature_names = X.columns
        importance_df = pd.DataFrame({
            'feature': feature_names,
            'importance': rf_importance
        }).sort_values('importance', ascending=False)
        
        print("   Top 10 Most Important Features:")
        for i, row in importance_df.head(10).iterrows():
            print(f"     {i+1}. {row['feature']}: {row['importance']:.4f}")
        
    except Exception as e:
        print(f"   ERROR: {e}")
    
    # Step 6: Save models
    print("\n[STEP 6] Saving models...")
    try:
        os.makedirs('models', exist_ok=True)
        
        joblib.dump(rf, 'models/random_forest_model.joblib')
        joblib.dump(xgb_model, 'models/xgboost_model.joblib')
        joblib.dump(scaler, 'models/scaler.joblib')
        joblib.dump(label_encoders, 'models/label_encoders.joblib')
        joblib.dump(feature_names.tolist(), 'models/feature_names.joblib')
        joblib.dump(rf_importance, 'models/feature_importance.joblib')
        
        print("   SUCCESS: All models and components saved")
        
    except Exception as e:
        print(f"   ERROR: {e}")
    
    # Step 7: Final assessment
    print("\n" + "="*80)
    print("                    FINAL TRAINING RESULTS")
    print("="*80)
    
    print(f"\nDataset: {len(df)} schools, {len(df.columns)} features")
    print(f"Training samples: {len(X_train)}")
    print(f"Test samples: {len(X_test)}")
    
    print(f"\nRandom Forest Performance:")
    print(f"  R² Score: {rf_r2:.4f}")
    print(f"  MSE: {rf_mse:.4f}")
    print(f"  MAE: {rf_mae:.4f}")
    print(f"  RMSE: {np.sqrt(rf_mse):.4f}")
    
    print(f"\nXGBoost Performance:")
    print(f"  R² Score: {xgb_r2:.4f}")
    print(f"  MSE: {xgb_mse:.4f}")
    print(f"  MAE: {xgb_mae:.4f}")
    print(f"  RMSE: {np.sqrt(xgb_mse):.4f}")
    
    # Performance assessment
    if rf_r2 > 0.7 and xgb_r2 > 0.7:
        performance = "EXCELLENT"
    elif rf_r2 > 0.5 and xgb_r2 > 0.5:
        performance = "GOOD"
    elif rf_r2 > 0.3 and xgb_r2 > 0.3:
        performance = "ACCEPTABLE"
    else:
        performance = "NEEDS IMPROVEMENT"
    
    print(f"\nOverall Performance: {performance}")
    print(f"Problem Status: {'SOLVED' if not np.isnan(rf_r2) and not np.isnan(xgb_r2) else 'PERSISTS'}")
    
    # Arabic summary
    print("\n" + "="*80)
    print("                           Arabic Summary")
    print("="*80)
    print(f" tamaño de conjunto de datos: {len(df)} escuela")
    print(f"Random Forest R²: {rf_r2:.4f}")
    print(f"XGBoost R²: {xgb_r2:.4f}")
    print(f"Estado del problema: {'RESUELTO' if not np.isnan(rf_r2) and not np.isnan(xgb_r2) else 'PERSISTE'}")
    
    print("="*80)
    return True

if __name__ == "__main__":
    success = train_models()
    if success:
        print("\nTraining completed successfully!")
    else:
        print("\nTraining failed!")
