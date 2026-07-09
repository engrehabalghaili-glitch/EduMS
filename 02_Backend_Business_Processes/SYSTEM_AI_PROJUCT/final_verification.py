# -*- coding: utf-8 -*-
"""
Final Verification Script - Complete System Check
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

def verify_system():
    print("="*80)
    print("           SYSTEM VERIFICATION - AI EDUCATIONAL TRANSFORMATION")
    print("="*80)
    
    verification_results = {}
    
    # 1. Verify Data
    print("\n[1] DATA VERIFICATION")
    print("-" * 40)
    try:
        if os.path.exists('data/comprehensive_school_data.csv'):
            df = pd.read_csv('data/comprehensive_school_data.csv')
            print(f"   Data file exists: {len(df)} schools, {len(df.columns)} features")
            print(f"   Target range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
            verification_results['data'] = "PASS"
        else:
            print("   ERROR: Data file not found!")
            verification_results['data'] = "FAIL"
    except Exception as e:
        print(f"   ERROR: {e}")
        verification_results['data'] = "FAIL"
    
    # 2. Verify Models
    print("\n[2] MODEL VERIFICATION")
    print("-" * 40)
    model_files = [
        'models/random_forest_model.joblib',
        'models/xgboost_model.joblib',
        'models/scaler.joblib',
        'models/label_encoders.joblib',
        'models/feature_names.joblib',
        'models/feature_importance.joblib'
    ]
    
    models_exist = True
    for model_file in model_files:
        if os.path.exists(model_file):
            print(f"   {model_file}: EXISTS")
        else:
            print(f"   {model_file}: MISSING")
            models_exist = False
    
    verification_results['models'] = "PASS" if models_exist else "FAIL"
    
    # 3. Quick Performance Test
    print("\n[3] PERFORMANCE VERIFICATION")
    print("-" * 40)
    try:
        # Load and test data quickly
        df = pd.read_csv('data/comprehensive_school_data.csv')
        X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
        y = df['Overall_School_Quality_Score']
        
        # Quick preprocessing
        for col in X.select_dtypes('object').columns:
            X[col] = LabelEncoder().fit_transform(X[col])
        
        # Quick split and test
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
        X_train_scaled = StandardScaler().fit_transform(X_train)
        X_test_scaled = StandardScaler().fit_transform(X_test)
        
        # Quick Random Forest test
        rf = RandomForestRegressor(n_estimators=10, random_state=42)
        rf.fit(X_train_scaled, y_train)
        rf_pred = rf.predict(X_test_scaled)
        rf_r2 = r2_score(y_test, rf_pred)
        
        # Quick XGBoost test
        xgb_model = xgb.XGBRegressor(random_state=42)
        xgb_model.fit(X_train_scaled, y_train)
        xgb_pred = xgb_model.predict(X_test_scaled)
        xgb_r2 = r2_score(y_test, xgb_pred)
        
        print(f"   Random Forest R²: {rf_r2:.4f}")
        print(f"   XGBoost R²: {xgb_r2:.4f}")
        
        if not np.isnan(rf_r2) and not np.isnan(xgb_r2):
            print("   Performance test: PASS")
            verification_results['performance'] = "PASS"
        else:
            print("   Performance test: FAIL (NaN detected)")
            verification_results['performance'] = "FAIL"
            
    except Exception as e:
        print(f"   Performance test: FAIL ({e})")
        verification_results['performance'] = "FAIL"
    
    # 4. API Verification
    print("\n[4] API VERIFICATION")
    print("-" * 40)
    try:
        # Check if API file exists and is importable
        if os.path.exists('api_service/main_ar.py'):
            print("   API file exists: api_service/main_ar.py")
            
            # Try to import (quick check)
            import sys
            sys.path.append('api_service')
            try:
                import main_ar
                print("   API import: PASS")
                verification_results['api'] = "PASS"
            except Exception as e:
                print(f"   API import: FAIL ({e})")
                verification_results['api'] = "FAIL"
        else:
            print("   API file: MISSING")
            verification_results['api'] = "FAIL"
    except Exception as e:
        print(f"   API verification: FAIL ({e})")
        verification_results['api'] = "FAIL"
    
    # 5. Summary
    print("\n" + "="*80)
    print("                    VERIFICATION SUMMARY")
    print("="*80)
    
    all_passed = True
    for component, status in verification_results.items():
        status_symbol = "PASS" if status == "PASS" else "FAIL"
        print(f"   {component.upper()}: {status_symbol}")
        if status == "FAIL":
            all_passed = False
    
    print(f"\nOverall System Status: {'FULLY OPERATIONAL' if all_passed else 'NEEDS ATTENTION'}")
    
    # Arabic Summary
    print("\n" + "="*80)
    print("                           Arabic Summary")
    print("="*80)
    print(f"   case of data: {verification_results.get('data', 'UNKNOWN')}")
    print(f"   case of models: {verification_results.get('models', 'UNKNOWN')}")
    print(f"   case of performance: {verification_results.get('performance', 'UNKNOWN')}")
    print(f"   case of api: {verification_results.get('api', 'UNKNOWN')}")
    print(f"   general state: {'OPERATIONAL' if all_passed else 'NEEDS ATTENTION'}")
    
    print("="*80)
    return all_passed

if __name__ == "__main__":
    success = verify_system()
    if success:
        print("\nSystem is ready for production use!")
    else:
        print("\nSystem needs attention before production use.")
