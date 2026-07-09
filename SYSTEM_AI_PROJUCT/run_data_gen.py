import sys
import os

# Add current directory to Python path
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

try:
    import pandas as pd
    import numpy as np
    print("Libraries imported successfully")
    
    # Import our data generator
    from src.data_generator import generate_school_data, save_data, display_sample
    
    print("Generating school data...")
    school_data = generate_school_data(num_schools=500)
    
    print("Displaying sample...")
    display_sample(school_data)
    
    print("Saving data...")
    save_data(school_data)
    
    print("Data generation completed successfully!")
    
except Exception as e:
    print(f"Error: {e}")
    import traceback
    traceback.print_exc()
