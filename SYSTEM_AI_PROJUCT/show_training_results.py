# -*- coding: utf-8 -*-
"""
Show Training Results - Execute and Display
"""

import subprocess
import sys
import os

def execute_and_show():
    print("Executing training and showing results...")
    
    # Execute the simple direct script
    try:
        result = subprocess.run([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'simple_direct.py'
        ], capture_output=True, text=True, encoding='utf-8', 
        cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
        
        print("OUTPUT:")
        print(result.stdout)
        
        if result.stderr:
            print("ERRORS:")
            print(result.stderr)
            
    except Exception as e:
        print(f"Execution error: {e}")

if __name__ == "__main__":
    execute_and_show()
