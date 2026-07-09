import pandas as pd
import os

# Check the data file
data_path = 'data/comprehensive_school_data.csv'
if os.path.exists(data_path):
    df = pd.read_csv(data_path)
    print(f'Number of schools: {len(df)}')
    print(f'Number of features: {len(df.columns)}')
    print(f'Data shape: {df.shape}')
    print(f'First few rows:')
    print(df.head())
else:
    print('Data file not found!')
