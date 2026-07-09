import sys
import os
sys.path.append(os.getcwd())

# Import and run the training directly
from ml_core.model_trainer import EducationalModelTrainer

print("Starting direct model training...")
trainer = EducationalModelTrainer(model_type='xgboost')
results = trainer.train_and_evaluate('data/comprehensive_school_data.csv')
print("Training completed!")
