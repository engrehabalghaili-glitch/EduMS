# -*- coding: utf-8 -*-
"""
Show Ultimate Results - Execute and Display Complete Training Results
"""

import subprocess
import sys
import os

def show_ultimate_results():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - ULTIMATE RESULTS DISPLAY")
    print("="*80)
    
    # Execute the ultimate training run
    try:
        process = subprocess.Popen(
            ['c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe', 'ultimate_training_run.py'],
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            text=True,
            encoding='utf-8',
            bufsize=1,
            universal_newlines=True,
            cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT'
        )
        
        # Display output in real-time
        print("EXECUTING ULTIMATE TRAINING RUN:")
        print("-" * 60)
        
        output_lines = []
        while True:
            output = process.stdout.readline()
            if output == '' and process.poll() is not None:
                break
            if output:
                line = output.strip()
                print(line)
                output_lines.append(line)
        
        return_code = process.poll()
        print(f"\nUltimate training run completed with return code: {return_code}")
        
        # Extract key results
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
        
        # Display final summary
        print("\n" + "="*80)
        print("                   FINAL RESULTS SUMMARY")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance Rating: {performance}")
        print(f"Problem Status: {problem_status}")
        
        # Final assessment
        if "SOLVED" in problem_status:
            print("\nSUCCESS: The original NaN problem has been resolved!")
            print("The AI Educational Transformation System is ready for production use.")
        else:
            print("\nFAILURE: The NaN problem persists!")
            print("Further investigation is required.")
        
        print("="*80)
        
    except Exception as e:
        print(f"Error executing ultimate training: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    show_ultimate_results()
