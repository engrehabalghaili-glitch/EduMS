"""
===============================================================================
script: run_api_arabic.py - script to run the Arabic API
===============================================================================
"""

import subprocess
import sys
import os

def main():
    """Run the Arabic API server"""
    print("==========================================")
    print("AI Educational Transformation System")
    print("Arabic API Server")
    print("==========================================")
    
    # Get the virtual environment python path
    venv_python = "c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe"
    
    # Change to project directory
    os.chdir("c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT")
    
    print("Installing required packages...")
    
    # Install packages
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
    
    for package in packages:
        print(f"Installing {package}...")
        result = subprocess.run([venv_python, "-m", "pip", "install", package], 
                              capture_output=True, text=True)
        if result.returncode != 0:
            print(f"Failed to install {package}: {result.stderr}")
        else:
            print(f"Successfully installed {package}")
    
    print("\nStarting API server...")
    print("API will be available at:")
    print("- http://localhost:8000/docs (Swagger UI)")
    print("- http://localhost:8000/redoc (ReDoc)")
    print("- http://localhost:8000/health (Health check)")
    print("\nPress Ctrl+C to stop the server")
    print("="*50)
    
    # Run the API server
    try:
        subprocess.run([
            venv_python, 
            "-m", 
            "uvicorn", 
            "api_service.main_ar:app", 
            "--host", 
            "0.0.0.0", 
            "--port", 
            "8000", 
            "--reload"
        ])
    except KeyboardInterrupt:
        print("\nAPI server stopped by user")
    except Exception as e:
        print(f"Error: {e}")

if __name__ == "__main__":
    main()
