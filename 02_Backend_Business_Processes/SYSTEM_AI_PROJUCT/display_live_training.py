# -*- coding: utf-8 -*-
"""
Display Live Training - Execute and Show Real-time Results
"""

import subprocess
import sys
import os

def display_live_training():
    print("="*80)
    print("           AI EDUCATIONAL SYSTEM - LIVE TRAINING EXECUTION")
    print("="*80)
    
    # Execute training with live output
    try:
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
        
        # Display output in real-time
        print("TRAINING EXECUTION STARTED:")
        print("-" * 60)
        
        while True:
            output = process.stdout.readline()
            if output == '' and process.poll() is not None:
                break
            if output:
                print(output.strip())
        
        return_code = process.poll()
        print(f"\nTraining completed with return code: {return_code}")
        
        # Additional verification
        print("\n" + "="*80)
        print("                    VERIFICATION COMPLETE")
        print("="*80)
        
        if return_code == 0:
            print("SUCCESS: Training completed without errors!")
        else:
            print("WARNING: Training completed with errors!")
        
    except Exception as e:
        print(f"Error executing training: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    display_live_training()
