# -*- coding: utf-8 -*-
"""
Show Training Results Final - Execute and Display Complete Training Results
"""

import subprocess
import sys
import os

def show_training_results_final():
    print("="*80)
    print("           AI EDUCATIONAL TRANSFORMATION SYSTEM - SHOW TRAINING RESULTS FINAL")
    print("="*80)
    
    # Execute the ultimate training run and capture all output
    try:
        result = subprocess.run([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'ultimate_training_run.py'
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
        
        # Extract key results
        output_lines = result.stdout.split('\n')
        rf_r2 = xgb_r2 = avg_r2 = performance = problem_status = "Not found"
        
        for line in output_lines:
            if "Random Forest R²:" in line:
                rf_r2 = line.split(':')[-1].strip()
            elif "XGBoost R²:" in line:
                xgb_r2 = line.split(':')[-1].strip()
            elif "Average R²:" in line:
                avg_r2 = line.split(':')[-1].strip()
            elif "Performance Rating:" in line:
                performance = line.split(':')[-1].strip()
            elif "PROBLEM STATUS:" in line:
                problem_status = line.split(':')[-1].strip()
        
        print("\n" + "="*80)
        print("                    FINAL TRAINING RESULTS")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance Rating: {performance}")
        print(f"Problem Status: {problem_status}")
        
        # Final assessment
        if "SOLVED" in problem_status:
            print("\nSUCCESS: The AI Educational Transformation System is fully operational!")
            print("All original requirements have been completed successfully.")
            print("The system is ready for production deployment.")
        else:
            print("\nATTENTION: The system still has unresolved issues.")
            print("Please review the detailed output above.")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error executing training: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    show_training_results_final()
