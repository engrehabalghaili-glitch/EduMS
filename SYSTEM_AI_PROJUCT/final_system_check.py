# -*- coding: utf-8 -*-
"""
Final System Check - Complete Status Report
"""

import pandas as pd
import numpy as np
import os
import joblib
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import r2_score, mean_squared_error
import xgboost as xgb
import warnings
warnings.filterwarnings('ignore')

def final_system_check():
    print("="*80)
    print("           FINAL SYSTEM CHECK - AI EDUCATIONAL TRANSFORMATION")
    print("="*80)
    print(f"Check performed: {pd.Timestamp.now().strftime('%Y-%m-%d %H:%M:%S')}")
    
    # System Components Status
    print("\n[SYSTEM COMPONENTS STATUS]")
    print("-" * 60)
    
    components = {
        'Data File': 'data/comprehensive_school_data.csv',
        'API Service': 'api_service/main_ar.py',
        'Model Trainer': 'ml_core/model_trainer.py',
        'Data Generator': 'data_engine/data_generator.py',
        'Strategy Planner': 'strategy_engine/strategy_planner.py'
    }
    
    for name, path in components.items():
        status = "EXISTS" if os.path.exists(path) else "MISSING"
        print(f"{name}: {status}")
    
    # Data Analysis
    print("\n[DATA ANALYSIS]")
    print("-" * 60)
    
    if os.path.exists('data/comprehensive_school_data.csv'):
        try:
            df = pd.read_csv('data/comprehensive_school_data.csv')
            print(f"Dataset: {len(df)} schools × {len(df.columns)} features")
            print(f"Target range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
            print(f"Mean quality: {df['Overall_School_Quality_Score'].mean():.2f}")
            print(f"Std deviation: {df['Overall_School_Quality_Score'].std():.2f}")
            
            # Regional distribution
            if 'Region' in df.columns:
                print(f"\nRegional distribution:")
                for region, count in df['Region'].value_counts().items():
                    print(f"  {region}: {count} schools")
            
        except Exception as e:
            print(f"Error loading data: {e}")
    else:
        print("Data file not found!")
    
    # Model Performance Test
    print("\n[MODEL PERFORMANCE TEST]")
    print("-" * 60)
    
    try:
        # Load and prepare data
        df = pd.read_csv('data/comprehensive_school_data.csv')
        X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
        y = df['Overall_School_Quality_Score']
        
        # Preprocess
        for col in X.select_dtypes('object').columns:
            X[col] = LabelEncoder().fit_transform(X[col])
        
        # Split and scale
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
        scaler = StandardScaler()
        X_train_scaled = scaler.fit_transform(X_train)
        X_test_scaled = scaler.transform(X_test)
        
        # Test Random Forest
        rf = RandomForestRegressor(n_estimators=100, random_state=42)
        rf.fit(X_train_scaled, y_train)
        rf_pred = rf.predict(X_test_scaled)
        rf_r2 = r2_score(y_test, rf_pred)
        rf_mse = mean_squared_error(y_test, rf_pred)
        
        # Test XGBoost
        xgb_model = xgb.XGBRegressor(random_state=42)
        xgb_model.fit(X_train_scaled, y_train)
        xgb_pred = xgb_model.predict(X_test_scaled)
        xgb_r2 = r2_score(y_test, xgb_pred)
        xgb_mse = mean_squared_error(y_test, xgb_pred)
        
        print(f"Random Forest:")
        print(f"  R² Score: {rf_r2:.4f}")
        print(f"  MSE: {rf_mse:.4f}")
        print(f"  RMSE: {np.sqrt(rf_mse):.4f}")
        
        print(f"\nXGBoost:")
        print(f"  R² Score: {xgb_r2:.4f}")
        print(f"  MSE: {xgb_mse:.4f}")
        print(f"  RMSE: {np.sqrt(xgb_mse):.4f}")
        
        # Check for NaN
        nan_status = "CLEAN" if not (np.isnan(rf_r2) or np.isnan(xgb_r2)) else "NaN DETECTED"
        print(f"\nNaN Status: {nan_status}")
        
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
        
        print(f"Performance Rating: {rating}")
        
    except Exception as e:
        print(f"Performance test failed: {e}")
        rf_r2 = xgb_r2 = np.nan
        rating = "FAILED"
    
    # Saved Models Check
    print("\n[SAVED MODELS CHECK]")
    print("-" * 60)
    
    model_files = [
        ('Random Forest', 'models/random_forest_model.joblib'),
        ('XGBoost', 'models/xgboost_model.joblib'),
        ('Scaler', 'models/scaler.joblib'),
        ('Label Encoders', 'models/label_encoders.joblib'),
        ('Feature Names', 'models/feature_names.joblib'),
        ('Feature Importance', 'models/feature_importance.joblib')
    ]
    
    models_saved = 0
    for name, path in model_files:
        if os.path.exists(path):
            print(f"{name}: SAVED")
            models_saved += 1
        else:
            print(f"{name}: MISSING")
    
    print(f"Models saved: {models_saved}/{len(model_files)}")
    
    # API Status
    print("\n[API STATUS]")
    print("-" * 60)
    
    if os.path.exists('api_service/main_ar.py'):
        print("API file: EXISTS")
        try:
            import sys
            sys.path.append('api_service')
            import main_ar
            print("API import: SUCCESS")
            print("Available endpoints:")
            endpoints = [
                "/ - Health check",
                "/health - Detailed status", 
                "/analyze-and-strategize - Main analysis",
                "/predict - Performance prediction",
                "/recommend - Recommendations",
                "/docs - Swagger documentation"
            ]
            for endpoint in endpoints:
                print(f"  {endpoint}")
        except Exception as e:
            print(f"API import: FAILED ({e})")
    else:
        print("API file: MISSING")
    
    # Overall System Status
    print("\n[OVERALL SYSTEM STATUS]")
    print("-" * 60)
    
    checks = {
        'Data Available': os.path.exists('data/comprehensive_school_data.csv'),
        'Models Trained': not (np.isnan(rf_r2) or np.isnan(xgb_r2)) if 'rf_r2' in locals() else False,
        'Models Saved': models_saved == len(model_files),
        'API Ready': os.path.exists('api_service/main_ar.py'),
        'Performance OK': (rf_r2 > 0.3 and xgb_r2 > 0.3) if 'rf_r2' in locals() else False
    }
    
    for check, status in checks.items():
        icon = "PASS" if status else "FAIL"
        print(f"{check}: {icon}")
    
    overall_status = all(checks.values())
    print(f"\nOverall Status: {'FULLY OPERATIONAL' if overall_status else 'NEEDS ATTENTION'}")
    
    # Arabic Summary
    print("\n" + "="*80)
    print("                           Arabic Summary")
    print("="*80)
    print(f"Date: {pd.Timestamp.now().strftime('%Y-%m-%d %H:%M:%S')}")
    print(f"Data: {len(df) if 'df' in locals() else 'Unknown'} schools")
    print(f"Random Forest R²: {rf_r2:.4f if not np.isnan(rf_r2) else 'NaN'}")
    print(f"XGBoost R²: {xgb_r2:.4f if not np.isnan(xgb_r2) else 'NaN'}")
    print(f"Performance: {rating if 'rating' in locals() else 'Unknown'}")
    print(f"Overall Status: {'OPERATIONAL' if overall_status else 'NEEDS ATTENTION'}")
    
    print("="*80)
    return overall_status

if __name__ == "__main__":
    success = final_system_check()
    if success:
        print("\nSystem is fully operational and ready for use!")
    else:
        print("\nSystem needs attention before full deployment.")
