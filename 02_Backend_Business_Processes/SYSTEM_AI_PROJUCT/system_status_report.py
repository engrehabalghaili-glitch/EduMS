# -*- coding: utf-8 -*-
"""
System Status Report - Complete Analysis
"""

import pandas as pd
import numpy as np
import os
import joblib
from datetime import datetime

def generate_status_report():
    print("="*80)
    print("           AI EDUCATIONAL TRANSFORMATION SYSTEM - STATUS REPORT")
    print("="*80)
    print(f"Report Generated: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}")
    
    # Data Analysis
    print("\n[DATA ANALYSIS]")
    print("-" * 50)
    
    if os.path.exists('data/comprehensive_school_data.csv'):
        df = pd.read_csv('data/comprehensive_school_data.csv')
        print(f"Dataset Size: {len(df)} schools")
        print(f"Features: {len(df.columns)}")
        print(f"Target Variable Range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
        print(f"Average Quality Score: {df['Overall_School_Quality_Score'].mean():.2f}")
        print(f"Standard Deviation: {df['Overall_School_Quality_Score'].std():.2f}")
        
        # Regional distribution
        if 'Region' in df.columns:
            print(f"\nRegional Distribution:")
            region_counts = df['Region'].value_counts()
            for region, count in region_counts.items():
                print(f"  {region}: {count} schools")
        
        # School types
        if 'School_Type' in df.columns:
            print(f"\nSchool Types:")
            type_counts = df['School_Type'].value_counts()
            for stype, count in type_counts.items():
                print(f"  {stype}: {count} schools")
    else:
        print("Data file not found!")
    
    # Model Status
    print("\n[MODEL STATUS]")
    print("-" * 50)
    
    model_status = {}
    model_files = [
        ('Random Forest', 'models/random_forest_model.joblib'),
        ('XGBoost', 'models/xgboost_model.joblib'),
        ('Scaler', 'models/scaler.joblib'),
        ('Label Encoders', 'models/label_encoders.joblib'),
        ('Feature Names', 'models/feature_names.joblib'),
        ('Feature Importance', 'models/feature_importance.joblib')
    ]
    
    for name, path in model_files:
        if os.path.exists(path):
            try:
                model = joblib.load(path)
                if hasattr(model, 'feature_importances_'):
                    print(f"{name}: LOADED (has {len(model.feature_importances_)} features)")
                elif hasattr(model, 'n_features_in_'):
                    print(f"{name}: LOADED (trained on {model.n_features_in_} features)")
                else:
                    print(f"{name}: LOADED")
                model_status[name] = True
            except Exception as e:
                print(f"{name}: ERROR ({e})")
                model_status[name] = False
        else:
            print(f"{name}: MISSING")
            model_status[name] = False
    
    # Performance Metrics
    print("\n[PERFORMANCE METRICS]")
    print("-" * 50)
    
    try:
        # Load data and test models
        df = pd.read_csv('data/comprehensive_school_data.csv')
        X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
        y = df['Overall_School_Quality_Score']
        
        # Preprocess
        for col in X.select_dtypes('object').columns:
            X[col] = pd.factorize(X[col])[0]
        
        # Quick test with subset
        from sklearn.model_selection import train_test_split
        from sklearn.preprocessing import StandardScaler
        from sklearn.metrics import r2_score, mean_squared_error
        from sklearn.ensemble import RandomForestRegressor
        import xgboost as xgb
        
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
        scaler = StandardScaler()
        X_train_scaled = scaler.fit_transform(X_train)
        X_test_scaled = scaler.transform(X_test)
        
        # Test Random Forest
        rf = RandomForestRegressor(n_estimators=50, random_state=42)
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
        
        # Performance classification
        avg_r2 = (rf_r2 + xgb_r2) / 2
        if avg_r2 > 0.8:
            perf_level = "EXCELLENT"
        elif avg_r2 > 0.6:
            perf_level = "GOOD"
        elif avg_r2 > 0.4:
            perf_level = "ACCEPTABLE"
        else:
            perf_level = "NEEDS IMPROVEMENT"
        
        print(f"\nOverall Performance: {perf_level}")
        
    except Exception as e:
        print(f"Performance test failed: {e}")
    
    # API Status
    print("\n[API STATUS]")
    print("-" * 50)
    
    api_file = 'api_service/main_ar.py'
    if os.path.exists(api_file):
        print("API File: EXISTS")
        try:
            import sys
            sys.path.append('api_service')
            import main_ar
            print("API Import: SUCCESS")
            print("API Endpoints:")
            print("  - / (Health Check)")
            print("  - /health (Detailed Status)")
            print("  - /analyze-and-strategize (Main Analysis)")
            print("  - /predict (Performance Prediction)")
            print("  - /recommend (Recommendations)")
            print("  - /docs (Swagger Documentation)")
        except Exception as e:
            print(f"API Import: FAILED ({e})")
    else:
        print("API File: MISSING")
    
    # System Health
    print("\n[SYSTEM HEALTH]")
    print("-" * 50)
    
    health_checks = {
        'Data Available': os.path.exists('data/comprehensive_school_data.csv'),
        'Models Trained': all(model_status.values()),
        'API Ready': os.path.exists('api_service/main_ar.py'),
        'Performance OK': avg_r2 > 0.3 if 'avg_r2' in locals() else False
    }
    
    for check, status in health_checks.items():
        status_icon = "PASS" if status else "FAIL"
        print(f"{check}: {status_icon}")
    
    overall_health = all(health_checks.values())
    print(f"\nOverall System Health: {'HEALTHY' if overall_health else 'NEEDS ATTENTION'}")
    
    # Arabic Summary
    print("\n" + "="*80)
    print("                           Arabic Summary")
    print("="*80)
    print(f"Report Date: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}")
    print(f"Data Status: {'Available' if health_checks['Data Available'] else 'Missing'}")
    print(f"Models Status: {'Trained' if health_checks['Models Trained'] else 'Not Trained'}")
    print(f"API Status: {'Ready' if health_checks['API Ready'] else 'Not Ready'}")
    print(f"Performance: {'Good' if health_checks['Performance OK'] else 'Poor'}")
    print(f"System Health: {'Healthy' if overall_health else 'Needs Attention'}")
    
    if 'avg_r2' in locals():
        print(f"Average R²: {avg_r2:.4f}")
    
    print("="*80)
    return overall_health

if __name__ == "__main__":
    generate_status_report()
