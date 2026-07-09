# -*- coding: utf-8 -*-
"""
Show Results Now - Execute and Display Training Results
"""

import subprocess
import sys
import os

def show_results():
    print("="*80)
    print("           SHOWING TRAINING RESULTS NOW")
    print("="*80)
    
    # Execute training script
    try:
        result = subprocess.run([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'execute_now.py'
        ], capture_output=True, text=True, encoding='utf-8', 
        cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
        
        print("TRAINING EXECUTION OUTPUT:")
        print("="*80)
        print(result.stdout)
        
        if result.stderr:
            print("\nERRORS/WARNINGS:")
            print("="*80)
            print(result.stderr)
        
        print(f"\nReturn Code: {result.returncode}")
        
        # Extract key metrics
        output_lines = result.stdout.split('\n')
        rf_r2 = xgb_r2 = "Not found"
        
        for i, line in enumerate(output_lines):
            if "Random Forest R²:" in line:
                rf_r2 = line.split(':')[-1].strip()
            elif "XGBoost R²:" in line:
                xgb_r2 = line.split(':')[-1].strip()
        
        print("\n" + "="*80)
        print("                   KEY RESULTS")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        
        # Check problem status
        if "NaN" in rf_r2 or "NaN" in xgb_r2:
            print("PROBLEM STATUS: FAILED - NaN values detected!")
        else:
            print("PROBLEM STATUS: SOLVED - Valid R² scores!")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    show_results()
