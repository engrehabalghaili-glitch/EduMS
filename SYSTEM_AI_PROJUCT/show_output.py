# -*- coding: utf-8 -*-
"""
Show Training Output Directly
"""

import subprocess
import sys
import os

def show_training_output():
    print("="*80)
    print("           SHOWING TRAINING OUTPUT DIRECTLY")
    print("="*80)
    
    # Change to the correct directory
    os.chdir('c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
    
    # Run the training script with direct output
    try:
        print("Running training script...")
        result = subprocess.run([
            'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
            'ml_core/model_trainer.py'
        ], text=True, encoding='utf-8', capture_output=False)
        
        print(f"Return code: {result.returncode}")
        
    except Exception as e:
        print(f"Error: {e}")

if __name__ == "__main__":
    show_training_output()
