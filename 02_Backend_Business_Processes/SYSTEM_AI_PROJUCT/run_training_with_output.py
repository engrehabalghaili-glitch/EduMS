# -*- coding: utf-8 -*-
"""
Run Training with Output - Execute and Display Results
"""

import subprocess
import sys
import os

def run_training_with_output():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - TRAINING WITH OUTPUT")
    print("="*80)
    
    # Execute training script and capture all output
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
        
        # Parse and display key results
        output_lines = result.stdout.split('\n')
        rf_r2 = xgb_r2 = avg_r2 = performance = status = "Not found"
        
        for line in output_lines:
            if "Random Forest R²:" in line:
                rf_r2 = line.split(':')[-1].strip()
            elif "XGBoost R²:" in line:
                xgb_r2 = line.split(':')[-1].strip()
            elif "Average R²:" in line:
                avg_r2 = line.split(':')[-1].strip()
            elif "Performance:" in line and "Average" not in line:
                performance = line.split(':')[-1].strip()
            elif "Status:" in line:
                status = line.split(':')[-1].strip()
        
        print("\n" + "="*80)
        print("                   KEY RESULTS SUMMARY")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance: {performance}")
        print(f"Status: {status}")
        
        # Final assessment
        if "NaN" in rf_r2 or "NaN" in xgb_r2:
            print("\nPROBLEM STATUS: FAILED - NaN values detected!")
        else:
            print("\nPROBLEM STATUS: SOLVED - Valid R² scores achieved!")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error executing training: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    run_training_with_output()
