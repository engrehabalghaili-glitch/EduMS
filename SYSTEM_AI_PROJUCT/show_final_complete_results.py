# -*- coding: utf-8 -*-
"""
Show Final Complete Results - Execute and Display All Results
"""

import subprocess
import sys
import os

def show_final_complete_results():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - SHOWING FINAL COMPLETE RESULTS")
    print("="*80)
    
    # Execute the final complete run and capture all output
    try:
        result = subprocess.run([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'final_complete_run.py'
        ], capture_output=True, text=True, encoding='utf-8', 
        cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
        
        print("FINAL COMPLETE EXECUTION OUTPUT:")
        print("="*80)
        print(result.stdout)
        
        if result.stderr:
            print("\nERRORS/WARNINGS:")
            print("="*80)
            print(result.stderr)
        
        print(f"\nReturn Code: {result.returncode}")
        
        # Extract and display key results
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
        print("                    KEY RESULTS SUMMARY")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance Rating: {performance}")
        print(f"Problem Status: {problem_status}")
        
        # Final assessment
        if "SOLVED" in problem_status:
            print("\nSUCCESS: The AI Educational Transformation System is fully operational!")
            print("Original NaN problem has been resolved.")
            print("System is ready for production use.")
        else:
            print("\nATTENTION: The system still has unresolved issues.")
            print("Further investigation is required.")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error executing final complete run: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    show_final_complete_results()
