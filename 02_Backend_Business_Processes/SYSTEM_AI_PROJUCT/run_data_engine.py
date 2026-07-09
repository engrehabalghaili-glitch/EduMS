"""
Runner script for data engine with proper path handling
"""

import sys
import os

# Add the project root to Python path
project_root = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, project_root)

try:
    from data_engine.data_generator import EducationalDataGenerator
    
    print("🚀 Starting Educational Data Generation...")
    
    generator = EducationalDataGenerator(num_schools=1000, random_seed=42)
    
    # Generate dataset
    df = generator.generate_comprehensive_dataset()
    
    # Display summary
    correlations = generator.display_summary_statistics(df)
    
    # Save dataset
    filepath = generator.save_dataset(df)
    
    print(f"\n✅ SUCCESS: Data generation completed!")
    print(f"📁 File location: {filepath}")
    print(f"📊 Dataset shape: {df.shape}")
    
except Exception as e:
    print(f"❌ ERROR: {e}")
    import traceback
    traceback.print_exc()
