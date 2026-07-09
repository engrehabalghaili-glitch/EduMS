# -*- coding: utf-8 -*-
"""
Show Final Results - Execute Training and Display Output
"""

import subprocess
import sys
import os

def show_results():
    print("="*80)
    print("           SHOWING FINAL TRAINING RESULTS")
    print("="*80)
    
    # Execute training script and capture output
    try:
        result = subprocess.run([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'execute_training_now.py'
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
        
        # Extract key metrics from output
        output_lines = result.stdout.split('\n')
        rf_r2 = xgb_r2 = "Not found"
        
        for line in output_lines:
            if "Random Forest Results:" in line:
                # Look for R² in next few lines
                idx = output_lines.index(line)
                for i in range(idx+1, min(idx+5, len(output_lines))):
                    if "R² Score:" in output_lines[i]:
                        rf_r2 = output_lines[i].split(':')[-1].strip()
                        break
            elif "XGBoost Results:" in line:
                # Look for R² in next few lines
                idx = output_lines.index(line)
                for i in range(idx+1, min(idx+5, len(output_lines))):
                    if "R² Score:" in output_lines[i]:
                        xgb_r2 = output_lines[i].split(':')[-1].strip()
                        break
        
        print("\n" + "="*80)
        print("                   KEY METRICS SUMMARY")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        
        # Check if NaN values are present
        if "NaN" in rf_r2 or "NaN" in xgb_r2:
            print("PROBLEM STATUS: FAILED - NaN values detected!")
        else:
            print("PROBLEM STATUS: SOLVED - Valid R² scores!")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error executing training: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    show_results()
