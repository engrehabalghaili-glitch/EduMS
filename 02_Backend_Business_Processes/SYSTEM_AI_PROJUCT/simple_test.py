import pandas as pd
import numpy as np

# Simple test to see if libraries work
print("Testing libraries...")

# Create sample data
data = {
    'School_ID': ['SCH_0001', 'SCH_0002'],
    'Student_Count': [500, 800],
    'Teacher_Count': [25, 40],
    'Target_Performance_Score': [75.5, 82.3]
}

df = pd.DataFrame(data)
print("Sample data created:")
print(df)
print("Libraries are working correctly!")
