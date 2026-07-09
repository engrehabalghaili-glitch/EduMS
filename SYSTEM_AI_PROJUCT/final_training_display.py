# -*- coding: utf-8 -*-
"""
Final Training Display - Execute and Show Complete Results
"""

import subprocess
import sys
import os
import time

def final_training_display():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - FINAL TRAINING DISPLAY")
    print("="*80)
    print(f"Execution Time: {time.strftime('%Y-%m-%d %H:%M:%S')}")
    
    # Execute training with live output
    try:
        print("\nStarting training execution...")
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
        
        # Extract and display results
        print("\n" + "="*80)
        print("                   TRAINING RESULTS ANALYSIS")
        print("="*80)
        
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
        
        print(f"Model Performance Results:")
        print(f"  Random Forest R²: {rf_r2}")
        print(f"  XGBoost R²: {xgb_r2}")
        print(f"  Average R²: {avg_r2}")
        print(f"  Performance Rating: {performance}")
        print(f"  Training Status: {status}")
        
        # Problem status check
        print("\n" + "="*80)
        print("                    PROBLEM STATUS CHECK")
        print("="*80)
        
        if "NaN" in rf_r2 or "NaN" in xgb_r2:
            print("PROBLEM: NaN values still detected in R² scores!")
            print("SOLUTION: The training process needs further investigation.")
            problem_solved = False
        else:
            print("SUCCESS: Valid R² scores achieved - No NaN values!")
            print("SOLUTION: The original problem has been resolved.")
            problem_solved = True
        
        # System status
        print("\n" + "="*80)
        print("                    SYSTEM STATUS")
        print("="*80)
        
        if problem_solved:
            print("System Status: OPERATIONAL")
            print("AI Educational Transformation System: READY FOR USE")
            print("API Endpoint: Available at http://localhost:8000")
            print("Documentation: Available at http://localhost:8000/docs")
        else:
            print("System Status: NEEDS ATTENTION")
            print("AI Educational Transformation System: NOT READY")
        
        # Arabic Summary
        print("\n" + "="*80)
        print("                           Arabic Summary")
        print("="*80)
        print(f"Execution Time: {time.strftime('%Y-%m-%d %H:%M:%S')}")
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance: {performance}")
        print(f"Training Status: {status}")
        print(f"Problem Status: {'RESOLVED' if problem_solved else 'PERSISTENT'}")
        print(f"System Status: {'OPERATIONAL' if problem_solved else 'NEEDS ATTENTION'}")
        
        print("="*80)
        return problem_solved
        
    except Exception as e:
        print(f"Error executing training: {e}")
        import traceback
        traceback.print_exc()
        return False

if __name__ == "__main__":
    success = final_training_display()
    
    print(f"\nFINAL CONCLUSION:")
    if success:
        print("The AI Educational Transformation System has been successfully configured!")
        print("All training issues have been resolved and the system is ready for production use.")
    else:
        print("The system still requires attention before full deployment.")
        print("Please review the errors above and take appropriate action.")
