# -*- coding: utf-8 -*-
"""
Run and Display - Execute Training with Live Output
"""

import subprocess
import sys
import os

def run_and_display():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - TRAINING EXECUTION")
    print("="*80)
    
    # Execute with live output
    try:
        process = subprocess.Popen(
            ['c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe', 'final_execution.py'],
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            text=True,
            encoding='utf-8',
            bufsize=1,
            universal_newlines=True,
            cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT'
        )
        
        # Print output line by line
        while True:
            output = process.stdout.readline()
            if output == '' and process.poll() is not None:
                break
            if output:
                print(output.strip())
        
        return_code = process.poll()
        print(f"\nProcess completed with return code: {return_code}")
        
    except Exception as e:
        print(f"Error: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    run_and_display()
