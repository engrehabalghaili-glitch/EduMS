# -*- coding: utf-8 -*-
"""
Final Results Display - Show All Training Results
"""

import subprocess
import sys
import os

def run_and_display_results():
    print("="*80)
    print("           FINAL RESULTS DISPLAY - COMPLETE SYSTEM OUTPUT")
    print("="*80)
    
    # Change to correct directory
    os.chdir('c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
    
    # Run the complete system run script and capture output
    try:
        print("Executing complete system run...")
        process = subprocess.Popen([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'complete_system_run.py'
        ], stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True, encoding='utf-8')
        
        # Get output
        stdout, stderr = process.communicate()
        
        print("STDOUT OUTPUT:")
        print("-" * 50)
        print(stdout)
        
        if stderr:
            print("\nSTDERR OUTPUT:")
            print("-" * 50)
            print(stderr)
        
        print(f"\nReturn Code: {process.returncode}")
        
        # Also try running the manual training script
        print("\n" + "="*80)
        print("           MANUAL TRAINING EXECUTION")
        print("="*80)
        
        process2 = subprocess.Popen([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'manual_training.py'
        ], stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True, encoding='utf-8')
        
        stdout2, stderr2 = process2.communicate()
        
        print("MANUAL TRAINING OUTPUT:")
        print("-" * 50)
        print(stdout2)
        
        if stderr2:
            print("\nMANUAL TRAINING ERRORS:")
            print("-" * 50)
            print(stderr2)
        
        print(f"\nManual Training Return Code: {process2.returncode}")
        
    except Exception as e:
        print(f"Error executing scripts: {e}")

if __name__ == "__main__":
    run_and_display_results()
