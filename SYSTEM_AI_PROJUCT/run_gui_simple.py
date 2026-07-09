# -*- coding: utf-8 -*-
"""
Simple GUI Runner - Start GUI with proper browser settings
"""

import subprocess
import sys
import os
import webbrowser
import time
import threading

def run_gui():
    print("="*60)
    print("  AI Educational Transformation System - GUI Application")
    print("="*60)
    print("Starting GUI application...")
    print("Please wait for the server to start...")
    print()
    
    # Check if we're in the correct directory
    if not os.path.exists('gui_app_arabic.py'):
        print("Error: gui_app_arabic.py not found in current directory!")
        print("Please run this script from the project root directory.")
        return
    
    # Start Streamlit in background
    def start_streamlit():
        subprocess.run([
            sys.executable, "-m", "streamlit", "run", "gui_app_arabic.py",
            "--server.port", "8501",
            "--server.address", "localhost",
            "--server.headless", "false",
            "--browser.gatherUsageStats", "false"
        ])
    
    # Start the server
    print("Starting Streamlit server...")
    server_thread = threading.Thread(target=start_streamlit)
    server_thread.daemon = True
    server_thread.start()
    
    # Wait a moment for server to start
    print("Waiting for server to start...")
    time.sleep(5)
    
    # Open browser
    try:
        print("Opening browser...")
        webbrowser.open('http://localhost:8501')
        print("Browser opened successfully!")
        print()
        print("="*60)
        print("GUI is running at: http://localhost:8501")
        print("Press Ctrl+C in this terminal to stop the server")
        print("="*60)
    except Exception as e:
        print(f"Could not open browser automatically: {e}")
        print("Please manually open: http://localhost:8501")
    
    # Keep the script running
    try:
        while True:
            time.sleep(1)
    except KeyboardInterrupt:
        print("\nStopping GUI server...")
        print("GUI application stopped.")

if __name__ == "__main__":
    run_gui()
