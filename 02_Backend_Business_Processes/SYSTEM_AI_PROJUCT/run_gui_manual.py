# -*- coding: utf-8 -*-
"""
Manual GUI Runner - Start GUI with manual instructions
"""

import subprocess
import sys
import os

def run_gui():
    print("="*60)
    print("  AI Educational Transformation System - GUI Application")
    print("="*60)
    print("Starting GUI application...")
    print()
    
    # Check if we're in the correct directory
    if not os.path.exists('gui_app_arabic.py'):
        print("Error: gui_app_arabic.py not found!")
        print("Please run from the project directory.")
        return
    
    print("Starting Streamlit server...")
    print("Server will be available at: http://localhost:8501")
    print()
    print("IMPORTANT:")
    print("1. Wait 10 seconds for server to start")
    print("2. Manually open your browser")
    print("3. Navigate to: http://localhost:8501")
    print("4. If you see security warning, click 'Advanced' then 'Proceed'")
    print()
    print("Press Ctrl+C to stop the server")
    print("="*60)
    
    # Start Streamlit with specific settings
    try:
        subprocess.run([
            sys.executable, "-m", "streamlit", "run", "gui_app_arabic.py",
            "--server.port", "8501",
            "--server.address", "localhost",
            "--server.headless", "false",
            "--browser.gatherUsageStats", "false",
            "--server.enableCORS", "false",
            "--server.enableXsrfProtection", "false"
        ])
    except KeyboardInterrupt:
        print("\nServer stopped by user.")
    except Exception as e:
        print(f"Error: {e}")
        print("\nTroubleshooting:")
        print("1. Make sure port 8501 is not in use")
        print("2. Check if streamlit is installed")
        print("3. Try running: pip install streamlit")

if __name__ == "__main__":
    run_gui()
