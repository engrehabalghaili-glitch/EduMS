# -*- coding: utf-8 -*-
"""
Run and Show Results - Execute Training with Direct Output
"""

import subprocess
import sys
import os
import time

def run_with_output():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - TRAINING EXECUTION")
    print("="*80)
    
    # Change to project directory
    os.chdir('c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
    
    # Execute the final system check
    print("Executing final system check...")
    
    try:
        # Run the script with real-time output
        process = subprocess.Popen(
            ['c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe', 'final_system_check.py'],
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            text=True,
            encoding='utf-8',
            bufsize=1,
            universal_newlines=True,
            cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT'
        )
        
        # Print output in real-time
        while True:
            output = process.stdout.readline()
            if output == '' and process.poll() is not None:
                break
            if output:
                print(output.strip())
        
        # Get final return code
        return_code = process.poll()
        print(f"\nProcess completed with return code: {return_code}")
        
    except Exception as e:
        print(f"Error executing script: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    run_with_output()
