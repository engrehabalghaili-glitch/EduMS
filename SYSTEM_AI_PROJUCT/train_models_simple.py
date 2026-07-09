# -*- coding: utf-8 -*-
"""
Simple Model Training Script
"""
import os
import sys

def main():
    print("Starting model training...")
    
    # Change to ml_core directory
    ml_core_path = os.path.join(os.path.dirname(__file__), 'ml_core')
    if os.path.exists(ml_core_path):
        os.chdir(ml_core_path)
        print(f"Changed to directory: {os.getcwd()}")
    else:
        print(f"ml_core directory not found: {ml_core_path}")
        return False
    
    # Import and run training
    try:
        from model_trainer import train_and_save_models
        
        # Check data file
        data_path = '../data/comprehensive_school_data.csv'
        if not os.path.exists(data_path):
            print(f"Data file not found: {data_path}")
            return False
        
        # Train models
        print("Training models...")
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
