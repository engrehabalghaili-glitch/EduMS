# -*- coding: utf-8 -*-
"""
Final Training Test - Arabic Educational AI System
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

def main():
    print("="*80)
    print("      AI EDUCATIONAL TRANSFORMATION SYSTEM - FINAL TRAINING TEST")
    print("="*80)
    
    try:
        # Load data
        print("\n1. Loading dataset...")
        df = pd.read_csv('data/comprehensive_school_data.csv')
        print(f"   Dataset loaded: {len(df)} schools, {len(df.columns)} features")
        
        # Prepare data
        print("\n2. Preparing data for training...")
        X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
        y = df['Overall_School_Quality_Score']
        
        # Handle categorical variables
        print("   Processing categorical variables...")
        categorical_cols = X.select_dtypes('object').columns
        for col in categorical_cols:
            le = LabelEncoder()
            X[col] = le.fit_transform(X[col])
        
        # Split data
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
        
        # Scale features
        print("   Scaling features...")
        scaler = StandardScaler()
        X_train_scaled = scaler.fit_transform(X_train)
        X_test_scaled = scaler.transform(X_test)
        
        print(f"   Training set: {len(X_train)} samples")
        print(f"   Test set: {len(X_test)} samples")
        
        # Train Random Forest
        print("\n3. Training Random Forest model...")
        rf = RandomForestRegressor(n_estimators=100, random_state=42)
        rf.fit(X_train_scaled, y_train)
        rf_pred = rf.predict(X_test_scaled)
        rf_r2 = r2_score(y_test, rf_pred)
        rf_mse = mean_squared_error(y_test, rf_pred)
        
        # Train XGBoost
        print("   Training XGBoost model...")
        xgb_model = xgb.XGBRegressor(random_state=42)
        xgb_model.fit(X_train_scaled, y_train)
        xgb_pred = xgb_model.predict(X_test_scaled)
        xgb_r2 = r2_score(y_test, xgb_pred)
        xgb_mse = mean_squared_error(y_test, xgb_pred)
        
        # Display results
        print("\n" + "="*80)
        print("                    TRAINING RESULTS")
        print("="*80)
        
        print(f"\nRandom Forest Model:")
        print(f"  R² Score: {rf_r2:.4f}")
        print(f"  MSE: {rf_mse:.4f}")
        print(f"  RMSE: {np.sqrt(rf_mse):.4f}")
        
        print(f"\nXGBoost Model:")
        print(f"  R² Score: {xgb_r2:.4f}")
        print(f"  MSE: {xgb_mse:.4f}")
        print(f"  RMSE: {np.sqrt(xgb_mse):.4f}")
        
        # Feature importance
        rf_importance = rf.feature_importances_
        feature_names = X.columns
        importance_df = pd.DataFrame({
            'feature': feature_names,
            'importance': rf_importance
        }).sort_values('importance', ascending=False)
        
        print(f"\nTop 10 Important Features:")
        for i, row in importance_df.head(10).iterrows():
            print(f"  {i+1}. {row['feature']}: {row['importance']:.4f}")
        
        # Final assessment
        print("\n" + "="*80)
        print("                    FINAL ASSESSMENT")
        print("="*80)
        
        if not np.isnan(rf_r2) and not np.isnan(xgb_r2):
            if rf_r2 > 0.7 and xgb_r2 > 0.7:
                print("SUCCESS: Both models show excellent performance (R² > 0.7)")
            elif rf_r2 > 0.5 and xgb_r2 > 0.5:
                print("GOOD: Both models show good performance (R² > 0.5)")
            elif rf_r2 > 0.3 and xgb_r2 > 0.3:
                print("ACCEPTABLE: Models show moderate performance (R² > 0.3)")
            else:
                print("NEEDS IMPROVEMENT: Models show low performance (R² < 0.3)")
        else:
            print("ERROR: R² values are NaN - there's a problem with the training!")
        
        print(f"\nFinal R² Scores:")
        print(f"  Random Forest: {rf_r2:.4f}")
        print(f"  XGBoost: {xgb_r2:.4f}")
        
        # Check if problem is solved
        if not np.isnan(rf_r2) and not np.isnan(xgb_r2):
            print("\nPROBLEM SOLVED: R² values are now valid numbers!")
            return True
        else:
            print("\nPROBLEM PERSISTS: R² values are still NaN!")
            return False
            
    except Exception as e:
        print(f"\nERROR during training: {e}")
        return False

if __name__ == "__main__":
    success = main()
    if success:
        print("\nTraining completed successfully!")
    else:
        print("\nTraining failed!")
