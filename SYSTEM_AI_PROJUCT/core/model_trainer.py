"""
ML Core for AI-Powered Educational Transformation Suite
Implements XGBoost and RandomForest models with feature importance analysis
"""

import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestRegressor
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import mean_squared_error, r2_score, mean_absolute_error
import xgboost as xgb
import joblib
import os
import matplotlib.pyplot as plt
import seaborn as sns
from typing import Dict, Tuple, Any

class EducationalModelTrainer:
    def __init__(self, model_type='xgboost'):
        self.model_type = model_type
        self.model = None
        self.scaler = StandardScaler()
        self.label_encoders = {}
        self.feature_names = []
        self.feature_importance = {}
        
    def load_and_preprocess_data(self, data_path: str) -> Tuple[pd.DataFrame, pd.Series]:
        """Load and preprocess the educational dataset"""
        print(f"Loading data from {data_path}...")
        
        df = pd.read_csv(data_path)
        print(f"Dataset shape: {df.shape}")
        
        # Separate features and target
        X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
        y = df['Overall_School_Quality_Score']
        
        # Handle categorical variables
        categorical_columns = X.select_dtypes(include=['object']).columns
        for col in categorical_columns:
            le = LabelEncoder()
            X[col] = le.fit_transform(X[col])
            self.label_encoders[col] = le
        
        # Store feature names
        self.feature_names = X.columns.tolist()
        
        print(f"Features: {len(self.feature_names)}")
        print(f"Target range: {y.min():.2f} - {y.max():.2f}")
        
        return X, y
    
    def split_data(self, X: pd.DataFrame, y: pd.Series, test_size: float = 0.2) -> Tuple:
        """Split data into train and test sets"""
        X_train, X_test, y_train, y_test = train_test_split(
            X, y, test_size=test_size, random_state=42
        )
        
        # Scale features
        X_train_scaled = self.scaler.fit_transform(X_train)
        X_test_scaled = self.scaler.transform(X_test)
        
        print(f"Training set: {X_train_scaled.shape}")
        print(f"Test set: {X_test_scaled.shape}")
        
        return X_train_scaled, X_test_scaled, y_train, y_test
    
    def train_model(self, X_train: np.ndarray, y_train: pd.Series) -> None:
        """Train the selected ML model"""
        print(f"Training {self.model_type} model...")
        
        if self.model_type == 'xgboost':
            self.model = xgb.XGBRegressor(
                n_estimators=100,
                max_depth=6,
                learning_rate=0.1,
                random_state=42,
                n_jobs=-1
            )
        elif self.model_type == 'randomforest':
            self.model = RandomForestRegressor(
                n_estimators=100,
                max_depth=10,
                random_state=42,
                n_jobs=-1
            )
        else:
            raise ValueError(f"Unsupported model type: {self.model_type}")
        
        self.model.fit(X_train, y_train)
        print(f"✓ {self.model_type} model trained successfully")
    
    def evaluate_model(self, X_test: np.ndarray, y_test: pd.Series) -> Dict[str, float]:
        """Evaluate model performance"""
        y_pred = self.model.predict(X_test)
        
        metrics = {
            'mse': mean_squared_error(y_test, y_pred),
            'rmse': np.sqrt(mean_squared_error(y_test, y_pred)),
            'mae': mean_absolute_error(y_test, y_pred),
            'r2': r2_score(y_test, y_pred)
        }
        
        print("\nModel Performance Metrics:")
        print(f"  MSE: {metrics['mse']:.4f}")
        print(f"  RMSE: {metrics['rmse']:.4f}")
        print(f"  MAE: {metrics['mae']:.4f}")
        print(f"  R²: {metrics['r2']:.4f}")
        
        return metrics
    
    def extract_feature_importance(self) -> Dict[str, float]:
        """Extract and analyze feature importance"""
        if hasattr(self.model, 'feature_importances_'):
            importance = self.model.feature_importances_
        elif hasattr(self.model, 'coef_'):
            importance = np.abs(self.model.coef_)
        else:
            print("Model doesn't support feature importance")
            return {}
        
        # Create feature importance dictionary
        feature_importance = dict(zip(self.feature_names, importance))
        self.feature_importance = feature_importance
        
        # Sort by importance
        sorted_importance = dict(sorted(feature_importance.items(), key=lambda x: x[1], reverse=True))
        
        print("\nTop 10 Most Important Features:")
        for i, (feature, score) in enumerate(list(sorted_importance.items())[:10]):
            print(f"  {i+1:2d}. {feature:<30}: {score:.4f}")
        
        return sorted_importance
    
    def save_model(self, model_dir: str = 'models') -> None:
        """Save trained model and preprocessing objects"""
        # Use absolute path from project root
        import os
        project_root = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
        model_dir = os.path.join(project_root, model_dir)
        os.makedirs(model_dir, exist_ok=True)
        
        # Save model
        model_path = os.path.join(model_dir, f'{self.model_type}_model.joblib')
        joblib.dump(self.model, model_path)
        
        # Save scaler
        scaler_path = os.path.join(model_dir, 'scaler.joblib')
        joblib.dump(self.scaler, scaler_path)
        
        # Save label encoders
        encoders_path = os.path.join(model_dir, 'label_encoders.joblib')
        joblib.dump(self.label_encoders, encoders_path)
        
        # Save feature names
        features_path = os.path.join(model_dir, 'feature_names.joblib')
        joblib.dump(self.feature_names, features_path)
        
        # Save feature importance
        importance_path = os.path.join(model_dir, 'feature_importance.joblib')
        joblib.dump(self.feature_importance, importance_path)
        
        print(f"\n✓ Model and artifacts saved to {model_dir}/")
        print(f"  - Model: {model_path}")
        print(f"  - Scaler: {scaler_path}")
        print(f"  - Encoders: {encoders_path}")
        print(f"  - Features: {features_path}")
        print(f"  - Importance: {importance_path}")
    
    def generate_feature_analysis_report(self, save_path: str = '../logs/feature_analysis.txt') -> None:
        """Generate detailed feature analysis report"""
        os.makedirs(os.path.dirname(save_path), exist_ok=True)
        
        with open(save_path, 'w') as f:
            f.write("EDUCATIONAL MODEL FEATURE ANALYSIS REPORT\n")
            f.write("=" * 50 + "\n\n")
            f.write(f"Model Type: {self.model_type}\n")
            f.write(f"Number of Features: {len(self.feature_names)}\n")
            f.write(f"Training Date: {pd.Timestamp.now()}\n\n")
            
            f.write("FEATURE IMPORTANCE RANKING:\n")
            f.write("-" * 30 + "\n")
            
            sorted_importance = dict(sorted(self.feature_importance.items(), key=lambda x: x[1], reverse=True))
            
            for i, (feature, score) in enumerate(sorted_importance.items()):
                f.write(f"{i+1:2d}. {feature:<30}: {score:.4f}\n")
            
            f.write("\nFEATURE CATEGORIES:\n")
            f.write("-" * 20 + "\n")
            
            # Categorize features
            categories = {
                'Academic': ['Term_1_Avg', 'Term_2_Avg', 'STEM_Subject_Rate', 'Literacy_Rate', 'Failure_Risk_Index'],
                'Engagement': ['Average_Attendance', 'Library_Usage_Hours', 'Extracurricular_Participation', 'LMS_Login_Frequency'],
                'Infrastructure': ['Internet_Speed_Mbps', 'Smart_Classroom_Ratio', 'Lab_Equipment_Quality_Score'],
                'Human Capital': ['Teacher_Turnover_Rate', 'Teacher_PhD_Ratio', 'Professional_Development_Hours_Per_Year'],
                'Financial': ['Budget_Per_Student', 'Budget_Allocation_IT', 'Budget_Allocation_Scholarships'],
                'Psychological': ['Student_Wellbeing_Score', 'Teacher_Burnout_Index']
            }
            
            for category, features in categories.items():
                f.write(f"\n{category}:\n")
                category_importance = 0
                count = 0
                for feature in features:
                    if feature in sorted_importance:
                        f.write(f"  - {feature}: {sorted_importance[feature]:.4f}\n")
                        category_importance += sorted_importance[feature]
                        count += 1
                if count > 0:
                    f.write(f"  Category Total: {category_importance:.4f}\n")
        
        print(f"✓ Feature analysis report saved to {save_path}")

def train_and_save_models(data_path: str = 'data/reference/comprehensive_school_data.csv'):
    """Train both XGBoost and RandomForest models"""
    print("🚀 Starting ML Model Training Pipeline")
    print("=" * 50)
    
    results = {}
    
    # Train XGBoost
    print("\n1. Training XGBoost Model")
    print("-" * 30)
    xgb_trainer = EducationalModelTrainer(model_type='xgboost')
    
    # Load and preprocess data
    X, y = xgb_trainer.load_and_preprocess_data(data_path)
    X_train, X_test, y_train, y_test = xgb_trainer.split_data(X, y)
    
    # Train and evaluate
    xgb_trainer.train_model(X_train, y_train)
    xgb_metrics = xgb_trainer.evaluate_model(X_test, y_test)
    xgb_importance = xgb_trainer.extract_feature_importance()
    
    # Save model
    xgb_trainer.save_model()
    xgb_trainer.generate_feature_analysis_report('logs/xgb_feature_analysis.txt')
    
    results['xgboost'] = {
        'metrics': xgb_metrics,
        'importance': xgb_importance
    }
    
    # Train RandomForest
    print("\n2. Training RandomForest Model")
    print("-" * 30)
    rf_trainer = EducationalModelTrainer(model_type='randomforest')
    
    # Use same split for fair comparison
    rf_trainer.scaler = xgb_trainer.scaler  # Use same scaler
    rf_trainer.label_encoders = xgb_trainer.label_encoders  # Use same encoders
    rf_trainer.feature_names = xgb_trainer.feature_names  # Use same feature names
    
    # Train and evaluate
    rf_trainer.train_model(X_train, y_train)
    rf_metrics = rf_trainer.evaluate_model(X_test, y_test)
    rf_importance = rf_trainer.extract_feature_importance()
    
    # Save model
    rf_trainer.save_model()
    rf_trainer.generate_feature_analysis_report('logs/rf_feature_analysis.txt')
    
    results['randomforest'] = {
        'metrics': rf_metrics,
        'importance': rf_importance
    }
    
    # Compare models
    print("\n3. Model Comparison")
    print("-" * 20)
    print(f"XGBoost R²: {xgb_metrics['r2']:.4f}")
    print(f"RandomForest R²: {rf_metrics['r2']:.4f}")
    
    better_model = 'xgboost' if xgb_metrics['r2'] > rf_metrics['r2'] else 'randomforest'
    print(f"\n✅ Better performing model: {better_model}")
    
    print("\n🎉 ML Training Pipeline Completed Successfully!")
    return results

if __name__ == "__main__":
    # Check if data file exists
    data_path = 'data/reference/comprehensive_school_data.csv'
    
    if os.path.exists(data_path):
        results = train_and_save_models(data_path)
    else:
        print(f"❌ Data file not found: {data_path}")
        print("Please run the data generation first.")
