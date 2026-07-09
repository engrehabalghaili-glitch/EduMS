# -*- coding: utf-8 -*-
"""
Execute and Capture Training Results
"""

import subprocess
import sys
import os
import time

def main():
    print("="*80)
    print("           EXECUTING AND CAPTURING TRAINING RESULTS")
    print("="*80)
    
    # Change to project directory
    os.chdir('c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
    
    # Execute the simple direct script
    print("Executing training script...")
    
    try:
        # Run the script
        process = subprocess.Popen(
            ['c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe', 'simple_direct.py'],
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
            text=True,
            encoding='utf-8',
            cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT'
        )
        
        # Wait for completion and get output
        stdout, stderr = process.communicate()
        
        print("\nTRAINING OUTPUT:")
        print("-" * 60)
        print(stdout)
        
        if stderr:
            print("\nERRORS/WARNINGS:")
            print("-" * 60)
            print(stderr)
        
        print(f"\nProcess completed with return code: {process.returncode}")
        
        # Also try the manual training script
        print("\n" + "="*80)
        print("           EXECUTING MANUAL TRAINING")
        print("="*80)
        
        process2 = subprocess.Popen(
            ['c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe', 'manual_training.py'],
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
            text=True,
            encoding='utf-8',
            cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT'
        )
        
        stdout2, stderr2 = process2.communicate()
        
        print("\nMANUAL TRAINING OUTPUT:")
        print("-" * 60)
        print(stdout2)
        
        if stderr2:
            print("\nMANUAL TRAINING ERRORS:")
            print("-" * 60)
            print(stderr2)
        
        print(f"\nManual training completed with return code: {process2.returncode}")
        
    except Exception as e:
        print(f"Error executing scripts: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    main()
