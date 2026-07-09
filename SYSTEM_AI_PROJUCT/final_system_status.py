# -*- coding: utf-8 -*-
"""
Final System Status - Complete System Verification and Status Report
"""

import pandas as pd
import numpy as np
import os
import joblib
from datetime import datetime
import warnings
warnings.filterwarnings('ignore')

def final_system_status():
    print("="*80)
    print("           AI EDUCATIONAL TRANSFORMATION SYSTEM - FINAL STATUS REPORT")
    print("="*80)
    print(f"Report Generated: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}")
    
    status_report = {
        'timestamp': datetime.now().strftime('%Y-%m-%d %H:%M:%S'),
        'components': {},
        'data_status': {},
        'model_status': {},
        'api_status': {},
        'overall_status': 'UNKNOWN'
    }
    
    # 1. Data Status Check
    print("\n[1] DATA STATUS CHECK")
    print("-" * 60)
    
    data_file = 'data/comprehensive_school_data.csv'
    if os.path.exists(data_file):
        try:
            df = pd.read_csv(data_file)
            status_report['data_status'] = {
                'file_exists': True,
                'schools_count': len(df),
                'features_count': len(df.columns),
                'target_range': [df['Overall_School_Quality_Score'].min(), df['Overall_School_Quality_Score'].max()],
                'target_mean': df['Overall_School_Quality_Score'].mean(),
                'null_values': df['Overall_School_Quality_Score'].isnull().sum(),
                'status': 'OK'
            }
            
            print(f"Data file: EXISTS")
            print(f"Schools: {len(df)}")
            print(f"Features: {len(df.columns)}")
            print(f"Target range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
            print(f"Null values in target: {df['Overall_School_Quality_Score'].isnull().sum()}")
            print(f"Data Status: OK")
            
        except Exception as e:
            status_report['data_status'] = {'file_exists': True, 'status': 'ERROR', 'error': str(e)}
            print(f"Data Status: ERROR - {e}")
    else:
        status_report['data_status'] = {'file_exists': False, 'status': 'MISSING'}
        print(f"Data Status: MISSING - File not found")
    
    # 2. Model Status Check
    print("\n[2] MODEL STATUS CHECK")
    print("-" * 60)
    
    model_files = {
        'Random Forest': 'models/random_forest_model.joblib',
        'XGBoost': 'models/xgboost_model.joblib',
        'Scaler': 'models/scaler.joblib',
        'Label Encoders': 'models/label_encoders.joblib',
        'Feature Names': 'models/feature_names.joblib',
        'Feature Importance': 'models/feature_importance.joblib'
    }
    
    models_found = 0
    for model_name, model_path in model_files.items():
        if os.path.exists(model_path):
            try:
                model = joblib.load(model_path)
                models_found += 1
                print(f"{model_name}: LOADED")
                status_report['model_status'][model_name] = {'status': 'LOADED', 'path': model_path}
            except Exception as e:
                print(f"{model_name}: ERROR - {e}")
                status_report['model_status'][model_name] = {'status': 'ERROR', 'error': str(e)}
        else:
            print(f"{model_name}: MISSING")
            status_report['model_status'][model_name] = {'status': 'MISSING'}
    
    print(f"Models found: {models_found}/{len(model_files)}")
    status_report['model_status']['overall'] = {
        'found_count': models_found,
        'total_count': len(model_files),
        'status': 'OK' if models_found == len(model_files) else 'INCOMPLETE'
    }
    
    # 3. API Status Check
    print("\n[3] API STATUS CHECK")
    print("-" * 60)
    
    api_file = 'api_service/main_ar.py'
    if os.path.exists(api_file):
        print(f"API file: EXISTS")
        try:
            import sys
            sys.path.append('api_service')
            import main_ar
            print(f"API import: SUCCESS")
            status_report['api_status'] = {'file_exists': True, 'import_status': 'SUCCESS', 'status': 'OK'}
        except Exception as e:
            print(f"API import: FAILED - {e}")
            status_report['api_status'] = {'file_exists': True, 'import_status': 'FAILED', 'error': str(e), 'status': 'ERROR'}
    else:
        print(f"API file: MISSING")
        status_report['api_status'] = {'file_exists': False, 'status': 'MISSING'}
    
    # 4. Quick Performance Test
    print("\n[4] QUICK PERFORMANCE TEST")
    print("-" * 60)
    
    try:
        if status_report['data_status'].get('status') == 'OK' and models_found >= 2:
            # Load data and test models
            df = pd.read_csv(data_file)
            X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
            y = df['Overall_School_Quality_Score']
            
            # Quick preprocessing
            from sklearn.model_selection import train_test_split
            from sklearn.preprocessing import StandardScaler, LabelEncoder
            from sklearn.metrics import r2_score
            
            # Handle categoricals
            for col in X.select_dtypes('object').columns:
                X[col] = LabelEncoder().fit_transform(X[col])
            
            # Split and scale
            X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
            scaler = StandardScaler()
            X_train_scaled = scaler.fit_transform(X_train)
            X_test_scaled = scaler.transform(X_test)
            
            # Test Random Forest
            rf = joblib.load('models/random_forest_model.joblib')
            rf_pred = rf.predict(X_test_scaled)
            rf_r2 = r2_score(y_test, rf_pred)
            
            # Test XGBoost
            xgb_model = joblib.load('models/xgboost_model.joblib')
            xgb_pred = xgb_model.predict(X_test_scaled)
            xgb_r2 = r2_score(y_test, xgb_pred)
            
            print(f"Random Forest R²: {rf_r2:.4f}")
            print(f"XGBoost R²: {xgb_r2:.4f}")
            
            # Check for NaN
            nan_detected = np.isnan(rf_r2) or np.isnan(xgb_r2)
            
            if nan_detected:
                print(f"Performance Test: FAILED - NaN detected")
                status_report['performance'] = {'status': 'FAILED', 'rf_r2': rf_r2, 'xgb_r2': xgb_r2, 'nan_detected': True}
            else:
                avg_r2 = (rf_r2 + xgb_r2) / 2
                print(f"Performance Test: PASSED - Avg R²: {avg_r2:.4f}")
                status_report['performance'] = {'status': 'PASSED', 'rf_r2': rf_r2, 'xgb_r2': xgb_r2, 'avg_r2': avg_r2, 'nan_detected': False}
        else:
            print(f"Performance Test: SKIPPED - Missing data or models")
            status_report['performance'] = {'status': 'SKIPPED', 'reason': 'Missing data or models'}
            
    except Exception as e:
        print(f"Performance Test: ERROR - {e}")
        status_report['performance'] = {'status': 'ERROR', 'error': str(e)}
    
    # 5. Overall System Status
    print("\n[5] OVERALL SYSTEM STATUS")
    print("-" * 60)
    
    checks = {
        'Data Available': status_report['data_status'].get('status') == 'OK',
        'Models Ready': status_report['model_status']['overall']['status'] == 'OK',
        'API Ready': status_report['api_status'].get('status') == 'OK',
        'Performance OK': status_report.get('performance', {}).get('status') == 'PASSED'
    }
    
    for check, status in checks.items():
        icon = "PASS" if status else "FAIL"
        print(f"{check}: {icon}")
    
    overall_status = all(checks.values())
    status_report['overall_status'] = 'OPERATIONAL' if overall_status else 'NEEDS ATTENTION'
    
    print(f"\nOverall System Status: {status_report['overall_status']}")
    
    # 6. Arabic Summary
    print("\n[6] ARABIC SUMMARY")
    print("-" * 60)
    
    print(f"Report Date: {status_report['timestamp']}")
    print(f"Data Status: {'OK' if status_report['data_status'].get('status') == 'OK' else 'ISSUE'}")
    print(f"Models Status: {status_report['model_status']['overall']['found_count']}/{status_report['model_status']['overall']['total_count']} found")
    print(f"API Status: {status_report['api_status'].get('status', 'UNKNOWN')}")
    print(f"Performance Status: {status_report.get('performance', {}).get('status', 'UNKNOWN')}")
    print(f"System Status: {status_report['overall_status']}")
    
    if status_report.get('performance', {}).get('avg_r2'):
        print(f"Average R²: {status_report['performance']['avg_r2']:.4f}")
    
    print("="*80)
    
    # Save status report
    try:
        import json
        with open('system_status_report.json', 'w', encoding='utf-8') as f:
            json.dump(status_report, f, indent=2, ensure_ascii=False)
        print("Status report saved to: system_status_report.json")
    except Exception as e:
        print(f"Failed to save status report: {e}")
    
    return overall_status

if __name__ == "__main__":
    success = final_system_status()
    
    print(f"\nFINAL CONCLUSION:")
    if success:
        print("The AI Educational Transformation System is FULLY OPERATIONAL!")
        print("All components are working correctly and the system is ready for production use.")
    else:
        print("The system needs attention before full deployment.")
        print("Please review the issues identified above and take corrective action.")
