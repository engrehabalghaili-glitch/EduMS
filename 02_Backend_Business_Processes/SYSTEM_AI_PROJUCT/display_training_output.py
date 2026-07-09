# -*- coding: utf-8 -*-
"""
Display Training Output - Execute and Show Results
"""

import subprocess
import sys
import os

def display_output():
    print("="*80)
    print("           DISPLAYING TRAINING OUTPUT")
    print("="*80)
    
    # Execute the final execution script
    try:
        result = subprocess.run([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'final_execution.py'
        ], capture_output=True, text=True, encoding='utf-8', 
        cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
        
        print("TRAINING OUTPUT:")
        print("="*80)
        print(result.stdout)
        
        if result.stderr:
            print("\nERRORS:")
            print("="*80)
            print(result.stderr)
        
        print(f"\nReturn Code: {result.returncode}")
        
        # Parse results
        output_lines = result.stdout.split('\n')
        rf_r2 = xgb_r2 = "Not found"
        
        for i, line in enumerate(output_lines):
            if "Random Forest Results:" in line:
                # Look for R² in next few lines
                for j in range(i+1, min(i+5, len(output_lines))):
                    if "R² Score:" in output_lines[j]:
                        rf_r2 = output_lines[j].split(':')[-1].strip()
                        break
            elif "XGBoost Results:" in line:
                # Look for R² in next few lines
                for j in range(i+1, min(i+5, len(output_lines))):
                    if "R² Score:" in output_lines[j]:
                        xgb_r2 = output_lines[j].split(':')[-1].strip()
                        break
        
        print("\n" + "="*80)
        print("                   RESULTS SUMMARY")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        
        # Check problem status
        if "NaN" in rf_r2 or "NaN" in xgb_r2:
            print("PROBLEM STATUS: FAILED - NaN values still present!")
        else:
            print("PROBLEM STATUS: SOLVED - Valid R² scores achieved!")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error executing training: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    display_output()
