import os
import pandas as pd

print("Checking training results...")
print("="*50)

# Check if models were created
models_dir = 'models'
if os.path.exists(models_dir):
    model_files = os.listdir(models_dir)
    print(f"Model files found: {model_files}")
else:
    print("No models directory found!")

# Check data file
if os.path.exists('data/comprehensive_school_data.csv'):
    df = pd.read_csv('data/comprehensive_school_data.csv')
    print(f"Data file: {len(df)} schools, {len(df.columns)} features")
    print(f"Target range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
else:
    print("No data file found!")

# Check for any training output files
for file in ['training_results.txt', 'model_performance.txt', 'training_log.txt']:
    if os.path.exists(file):
        print(f"Found output file: {file}")
        with open(file, 'r', encoding='utf-8') as f:
            print(f.read())

print("="*50)
