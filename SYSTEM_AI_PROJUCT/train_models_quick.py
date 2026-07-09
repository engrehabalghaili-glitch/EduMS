import sys
import os
sys.path.insert(0, os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from core.model_trainer import EducationalModelTrainer, train_and_save_models

data_path = 'data/comprehensive_school_data.csv'
print(f"Training models with data from: {data_path}")
train_and_save_models(data_path)
print("Training completed!")
