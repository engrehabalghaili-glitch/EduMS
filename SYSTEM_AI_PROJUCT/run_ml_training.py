"""
Runner script for ML training with proper path handling
"""

import sys
import os

# Add the project root to Python path
project_root = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, project_root)

try:
    from ml_core.model_trainer import train_and_save_models
    
    print("🚀 Starting ML Model Training...")
    
    # Check data file path
    data_path = os.path.join(project_root, 'data', 'comprehensive_school_data.csv')
    
    if os.path.exists(data_path):
        print(f"✓ Found data file: {data_path}")
        results = train_and_save_models(data_path)
        print("\n✅ SUCCESS: ML training completed!")
    else:
        print(f"❌ Data file not found: {data_path}")
        print("Available files:")
        for root, dirs, files in os.walk(project_root):
            for file in files:
                if file.endswith('.csv'):
                    print(f"  - {os.path.join(root, file)}")
    
except Exception as e:
    print(f"❌ ERROR: {e}")
    import traceback
    traceback.print_exc()
