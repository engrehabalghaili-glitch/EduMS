"""
===============================================================================
script: fix_and_run.py - script to fix issues and run the system
===============================================================================
"""

import subprocess
import sys
import os

def run_command(command, description):
    """Run command and handle errors"""
    print(f"\n{'='*60}")
    print(f"Running: {description}")
    print(f"Command: {command}")
    print(f"{'='*60}")
    
    try:
        result = subprocess.run(command, shell=True, capture_output=True, text=True, encoding='utf-8')
        
        if result.returncode == 0:
            print("SUCCESS!")
            if result.stdout:
                print("Output:", result.stdout)
        else:
            print("FAILED!")
            if result.stderr:
                print("Error:", result.stderr)
            if result.stdout:
                print("Output:", result.stdout)
        
        return result.returncode == 0
    
    except Exception as e:
        print(f"Exception: {e}")
        return False

def main():
    """Main function to fix and run the system"""
    print("AI Educational Transformation System - Fix and Run Script")
    print("="*60)
    
    # Get the virtual environment python path
    venv_python = "c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe"
    
    # Step 1: Install required packages
    packages = [
        "fastapi",
        "uvicorn[standard]",
        "pydantic",
        "pandas",
        "numpy",
        "scikit-learn",
        "xgboost",
        "matplotlib",
        "seaborn",
        "joblib"
    ]
    
    print("\nStep 1: Installing required packages...")
    for package in packages:
        success = run_command(f"{venv_python} -m pip install {package}", f"Installing {package}")
        if not success:
            print(f"Failed to install {package}")
    
    # Step 2: Verify installations
    print("\nStep 2: Verifying installations...")
    test_commands = [
        (f"{venv_python} -c \"import fastapi; print('FastAPI:', fastapi.__version__)\"", "Testing FastAPI"),
        (f"{venv_python} -c \"import uvicorn; print('Uvicorn installed')\"", "Testing Uvicorn"),
        (f"{venv_python} -c \"import pydantic; print('Pydantic:', pydantic.__version__)\"", "Testing Pydantic"),
        (f"{venv_python} -c \"import pandas; print('Pandas:', pandas.__version__)\"", "Testing Pandas"),
        (f"{venv_python} -c \"import numpy; print('Numpy:', numpy.__version__)\"", "Testing Numpy"),
    ]
    
    for cmd, desc in test_commands:
        run_command(cmd, desc)
    
    # Step 3: Test importing the API
    print("\nStep 3: Testing API import...")
    import_test = f'{venv_python} -c "import sys; sys.path.append(\'.\'); from api_service.main_ar import app; print(\'API imported successfully!\')"'
    run_command(import_test, "Testing API import")
    
    # Step 4: Run the API server
    print("\nStep 4: Starting API server...")
    print("The API server will start on http://localhost:8000")
    print("Press Ctrl+C to stop the server")
    print("\nAvailable endpoints:")
    print("- http://localhost:8000/docs (Swagger UI)")
    print("- http://localhost:8000/redoc (ReDoc)")
    print("- http://localhost:8000/health (Health check)")
    
    api_command = f"{venv_python} api_service/main_ar.py"
    
    try:
        # Change to project directory
        os.chdir("c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT")
        
        # Run the API server
        subprocess.run(api_command, shell=True)
        
    except KeyboardInterrupt:
        print("\nAPI server stopped by user")
    except Exception as e:
        print(f"Error running API: {e}")

if __name__ == "__main__":
    main()
