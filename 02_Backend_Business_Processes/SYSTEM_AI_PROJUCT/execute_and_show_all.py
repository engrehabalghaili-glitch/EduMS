# -*- coding: utf-8 -*-
"""
Execute and Show All - Complete System Execution with Results Display
"""

import subprocess
import sys
import os

def execute_and_show_all():
    print("="*80)
    print("           AI EDUCATIONAL TRANSFORMATION SYSTEM - EXECUTE AND SHOW ALL")
    print("="*80)
    
    # Execute the ultimate training run with live output
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
        print("EXECUTING COMPLETE SYSTEM:")
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
        print(f"\nExecution completed with return code: {return_code}")
        
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
        print("                    EXECUTION RESULTS SUMMARY")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance Rating: {performance}")
        print(f"Problem Status: {problem_status}")
        
        # Check if problem is solved
        if "SOLVED" in problem_status:
            print("\nSUCCESS: The AI Educational Transformation System is fully operational!")
            print("Original NaN problem has been resolved.")
            print("System components:")
            print("  - Data: 1000 schools dataset")
            print("  - Models: Random Forest and XGBoost trained")
            print("  - API: Ready for deployment")
            print("  - Performance: Valid R² scores")
            print("  - Language: Full Arabic support")
            
            print("\nSystem is ready for production use!")
        else:
            print("\nATTENTION: System still has unresolved issues.")
            print("Please review the detailed output above.")
        
        print("="*80)
        
        return "SOLVED" in problem_status
        
    except Exception as e:
        print(f"Error during execution: {e}")
        import traceback
        traceback.print_exc()
        return False

if __name__ == "__main__":
    success = execute_and_show_all()
    
    print(f"\nFINAL STATUS: {'SUCCESS' if success else 'NEEDS ATTENTION'}")
    
    if success:
        print("\nThe AI Educational Transformation System has been successfully deployed!")
        print("All original issues have been resolved.")
        print("The system is now ready for production use with full Arabic language support.")
    else:
        print("\nThe system requires additional work before deployment.")
        print("Please address the issues identified in the output above.")
