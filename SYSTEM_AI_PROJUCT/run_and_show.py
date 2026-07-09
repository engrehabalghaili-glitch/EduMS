import subprocess
import sys
import os

print("EXECUTING TRAINING AND SHOWING RESULTS")
print("="*50)

# Run the training script and capture output
try:
    result = subprocess.run([
        'c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe',
        'ml_core/model_trainer.py'
    ], capture_output=True, text=True, encoding='utf-8', cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT')
    
    print("STDOUT:")
    print(result.stdout)
    
    if result.stderr:
        print("STDERR:")
        print(result.stderr)
    
    print(f"Return code: {result.returncode}")
    
except Exception as e:
    print(f"Error running script: {e}")

print("="*50)
