# -*- coding: utf-8 -*-
"""
Run GUI Application - Script to start the Streamlit GUI application
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
    print("please manually navigate to the URL shown below.")
    print()
    
    # Check if Streamlit is installed
    try:
        import streamlit
        print(f"Streamlit version: {streamlit.__version__}")
    except ImportError:
        print("Streamlit is not installed. Installing required packages...")
        subprocess.run([sys.executable, "-m", "pip", "install", "-r", "requirements_gui.txt"])
        print("Packages installed successfully!")
    
    # Start the Streamlit application
    try:
        print("Starting GUI application...")
        print("="*60)
        
        # Run streamlit run gui_app.py
        subprocess.run([
            sys.executable, "-m", "streamlit", "run", "gui_app.py",
            "--server.port", "8501",
            "--server.address", "localhost",
            "--browser.gatherUsageStats", "false"
        ])
        
    except KeyboardInterrupt:
        print("\nGUI application stopped by user.")
    except Exception as e:
        print(f"Error starting GUI application: {e}")
        print("\nTroubleshooting:")
        print("1. Make sure you have Python installed")
        print("2. Install required packages: pip install -r requirements_gui.txt")
        print("3. Check that all model files exist in the models/ directory")
        print("4. Ensure the data file exists: data/comprehensive_school_data.csv")

if __name__ == "__main__":
    run_gui()
