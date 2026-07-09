# -*- coding: utf-8 -*-
"""
Run GUI Application - Fixed Script to start the Streamlit GUI application
"""

import subprocess
import sys
import os

def run_gui():
    print("="*60)
    print("  AI Educational Transformation System - GUI Application")
    print("="*60)
    print("Starting the GUI application...")
    print("Please wait for the browser to open automatically.")
    print()
    print("If the browser doesn't open automatically,")
    print("please manually navigate to: http://localhost:8501")
    print()
    
    # Check if we're in the correct directory
    if not os.path.exists('gui_app_arabic.py'):
        print("Error: gui_app_arabic.py not found in current directory!")
        print("Please run this script from the project root directory.")
        return
    
    # Install required packages if needed
    try:
        import streamlit
        print(f"Streamlit version: {streamlit.__version__}")
    except ImportError:
        print("Installing required packages...")
        subprocess.run([sys.executable, "-m", "pip", "install", "streamlit"])
        subprocess.run([sys.executable, "-m", "pip", "install", "plotly"])
        subprocess.run([sys.executable, "-m", "pip", "install", "arabic-reshaper"])
        subprocess.run([sys.executable, "-m", "pip", "install", "python-bidi"])
        print("Packages installed successfully!")
    
    # Check if models exist
    if not os.path.exists('models/random_forest_model.joblib'):
        print("Warning: Model files not found. Please run the training first.")
        print("The GUI will start but predictions may not work.")
    
    # Start the Streamlit application
    try:
        print("Starting GUI application...")
        print("="*60)
        print("GUI will be available at: http://localhost:8501")
        print("Press Ctrl+C to stop the server")
        print("="*60)
        
        # Run streamlit run gui_app_arabic.py
        subprocess.run([
            sys.executable, "-m", "streamlit", "run", "gui_app_arabic.py",
            "--server.port", "8501",
            "--server.address", "localhost",
            "--server.headless", "false",
            "--browser.gatherUsageStats", "false"
        ])
        
    except KeyboardInterrupt:
        print("\nGUI application stopped by user.")
    except Exception as e:
        print(f"Error starting GUI application: {e}")
        print("\nTroubleshooting:")
        print("1. Make sure you have Python installed")
        print("2. Install required packages: pip install streamlit plotly arabic-reshaper python-bidi")
        print("3. Check that all model files exist in the models/ directory")
        print("4. Ensure the data file exists: data/comprehensive_school_data.csv")
        print("5. Make sure you're in the correct directory")

if __name__ == "__main__":
    run_gui()
