# -*- coding: utf-8 -*-
"""
Final Show - Execute Training and Display Complete Results
"""

import subprocess
import sys
import os
import time

def final_show():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - FINAL TRAINING EXECUTION")
    print("="*80)
    
    # Execute with live output display
    try:
        process = subprocess.Popen(
            ['c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe', 'execute_now.py'],
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            text=True,
            encoding='utf-8',
            bufsize=1,
            universal_newlines=True,
            cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT'
        )
        
        # Collect and display output
        output_lines = []
        print("TRAINING IN PROGRESS:")
        print("-" * 60)
        
        while True:
            output = process.stdout.readline()
            if output == '' and process.poll() is not None:
                break
            if output:
                line = output.strip()
                print(line)
                output_lines.append(line)
        
        return_code = process.poll()
        print(f"\nTraining completed with return code: {return_code}")
        
        # Extract and display key results
        print("\n" + "="*80)
        print("                   TRAINING RESULTS SUMMARY")
        print("="*80)
        
        rf_r2 = xgb_r2 = "Not found"
        avg_r2 = "Not found"
        performance = "Unknown"
        problem_status = "Unknown"
        
        for line in output_lines:
            if "Random Forest R²:" in line:
                rf_r2 = line.split(':')[-1].strip()
            elif "XGBoost R²:" in line:
                xgb_r2 = line.split(':')[-1].strip()
            elif "Average R²:" in line:
                avg_r2 = line.split(':')[-1].strip()
            elif "Performance:" in line and "Average" not in line:
                performance = line.split(':')[-1].strip()
            elif "Problem Status:" in line:
                problem_status = line.split(':')[-1].strip()
        
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance Rating: {performance}")
        print(f"Problem Status: {problem_status}")
        
        # Final assessment
        print("\n" + "="*80)
        print("                    FINAL ASSESSMENT")
        print("="*80)
        
        if "NaN" in rf_r2 or "NaN" in xgb_r2:
            print("PROBLEM: NaN values still detected!")
            print("STATUS: FAILED")
        else:
            print("SUCCESS: Valid R² scores achieved!")
            print("STATUS: PASSED")
        
        # Arabic summary
        print("\n" + "="*80)
        print("                           Arabic Summary")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance: {performance}")
        print(f"Problem Status: {problem_status}")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error executing training: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    final_show()
