# -*- coding: utf-8 -*-
"""
Direct Model Training Script
"""
import os
import sys

# Add the ml_core directory to the path
sys.path.append(os.path.join(os.path.dirname(__file__), 'ml_core'))

from model_trainer import train_and_save_models

def main():
    print("Starting direct model training...")
    
    # Check if data file exists
    data_path = 'data/comprehensive_school_data.csv'
    if not os.path.exists(data_path):
        print(f"Data file not found: {data_path}")
        return False
    
    try:
        # Train models
        results = train_and_save_models(data_path)
        print("Model training completed successfully!")
        return True
    except Exception as e:
        print(f"Error during training: {e}")
        return False

if __name__ == "__main__":
    success = main()
    if success:
        print("Models are ready for use!")
    else:
        print("Model training failed.")
