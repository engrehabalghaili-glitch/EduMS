# -*- coding: utf-8 -*-
"""
Direct Training Run with Immediate Output
"""

import sys
import os
sys.path.append(os.getcwd())

# Import and execute training directly
print("="*80)
print("           DIRECT TRAINING EXECUTION")
print("="*80)

try:
    from ml_core.model_trainer import EducationalModelTrainer
    
    print("Initializing trainer...")
    trainer = EducationalModelTrainer(model_type='xgboost')
    
    print("Starting training...")
    results = trainer.train_and_evaluate('data/comprehensive_school_data.csv')
    
    print("Training completed!")
    if results:
        print("Results available!")
    else:
        print("No results returned!")
        
except ImportError as e:
    print(f"Import error: {e}")
except Exception as e:
    print(f"Training error: {e}")

print("="*80)
