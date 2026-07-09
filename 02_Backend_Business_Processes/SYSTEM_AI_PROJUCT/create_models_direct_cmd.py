import os
import subprocess
import sys

print("Creating model files using direct command...")

# Try to run the script directly
try:
    result = subprocess.run([sys.executable, 'create_models_for_gui.py'], 
                          capture_output=True, text=True, cwd='.')
    print("STDOUT:", result.stdout)
    if result.stderr:
        print("STDERR:", result.stderr)
    print("Return code:", result.returncode)
except Exception as e:
    print(f"Error: {e}")

# Check if models directory exists and list files
if os.path.exists('models'):
    print("\nFiles in models directory:")
    for file in os.listdir('models'):
        print(f"  - {file}")
else:
    print("Models directory does not exist")
