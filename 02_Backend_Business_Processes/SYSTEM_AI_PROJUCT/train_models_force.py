# -*- coding: utf-8 -*-
"""
Force Model Training Script - Direct execution
"""
import os
import sys
import subprocess

def main():
    print("Starting forced model training...")
    
    # Get current directory
    current_dir = os.path.dirname(os.path.abspath(__file__))
    ml_core_dir = os.path.join(current_dir, 'ml_core')
    
    # Check if ml_core exists
    if not os.path.exists(ml_core_dir):
        print(f"ml_core directory not found: {ml_core_dir}")
        return False
    
    # Check if data file exists
    data_path = os.path.join(current_dir, 'data', 'comprehensive_school_data.csv')
    if not os.path.exists(data_path):
        print(f"Data file not found: {data_path}")
        return False
    
    try:
        # Change to ml_core directory and run training
        os.chdir(ml_core_dir)
        print(f"Changed to directory: {os.getcwd()}")
        
        # Import and run
        from model_trainer import EducationalModelTrainer
        
        # Create trainer and train
        trainer = EducationalModelTrainer(model_type='xgboost')
        X, y = trainer.load_and_preprocess_data(data_path)
        X_train, X_test, y_train, y_test = trainer.split_data(X, y)
        trainer.train_model(X_train, y_train)
        trainer.evaluate_model(X_test, y_test)
        trainer.extract_feature_importance()
        trainer.save_model()
        
        # Train RandomForest
        rf_trainer = EducationalModelTrainer(model_type='randomforest')
        rf_trainer.scaler = trainer.scaler
        rf_trainer.label_encoders = trainer.label_encoders
        rf_trainer.feature_names = trainer.feature_names
        rf_trainer.train_model(X_train, y_train)
        rf_trainer.evaluate_model(X_test, y_test)
        rf_trainer.extract_feature_importance()
        rf_trainer.save_model('../models', model_type='randomforest')
        
        print("Model training completed successfully!")
        return True
        
    except Exception as e:
        print(f"Error during training: {e}")
        import traceback
        traceback.print_exc()
        return False

if __name__ == "__main__":
    success = main()
    if success:
        print("Models are ready for use!")
    else:
        print("Model training failed.")
