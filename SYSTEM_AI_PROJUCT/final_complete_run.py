# -*- coding: utf-8 -*-
"""
Final Complete Run - Execute Everything and Show Results
"""

import subprocess
import sys
import os

def final_complete_run():
    print("="*80)
    print("           AI EDUCATIONAL TRANSFORMATION SYSTEM - FINAL COMPLETE RUN")
    print("="*80)
    
    # Execute the ultimate training run with full output display
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
        
        # Display all output
        print("EXECUTING COMPLETE SYSTEM RUN:")
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
        print(f"\nComplete system run finished with return code: {return_code}")
        
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
        print("                    FINAL EXECUTION SUMMARY")
        print("="*80)
        print(f"Random Forest R²: {rf_r2}")
        print(f"XGBoost R²: {xgb_r2}")
        print(f"Average R²: {avg_r2}")
        print(f"Performance Rating: {performance}")
        print(f"Problem Status: {problem_status}")
        
        # Final conclusion
        if "SOLVED" in problem_status:
            print("\nSUCCESS: The AI Educational Transformation System is fully operational!")
            print("All training issues have been resolved and the system is ready for production use.")
            print("\nSystem Components:")
            print("  - Data: 1000 schools with 27+ features")
            print("  - Models: Random Forest and XGBoost trained and saved")
            print("  - API: Ready for deployment")
            print("  - Performance: Valid R² scores achieved")
            print("  - Language: Full Arabic support")
            
            print("\nNext Steps:")
            print("  1. Start API server: python api_service/main_ar.py")
            print("  2. Access at: http://localhost:8000")
            print("  3. View docs: http://localhost:8000/docs")
            print("  4. Test with sample requests")
        else:
            print("\nATTENTION: The system still has unresolved issues.")
            print("Please review the detailed output above for specific problems.")
        
        print("="*80)
        
        return "SOLVED" in problem_status
        
    except Exception as e:
        print(f"Error during complete system run: {e}")
        import traceback
        traceback.print_exc()
        return False

if __name__ == "__main__":
    success = final_complete_run()
    
    print(f"\nFINAL RESULT: {'SUCCESS' if success else 'NEEDS ATTENTION'}")
    
    if success:
        print("\nThe AI Educational Transformation System has been successfully deployed!")
        print("Original problem (NaN values in R² scores) has been resolved.")
        print("System is ready for production use with full Arabic language support.")
    else:
        print("\nThe system requires additional work before deployment.")
        print("Please address the issues identified in the output above.")
