import pandas as pd
import numpy as np

print("Checking data file...")
try:
    df = pd.read_csv('data/comprehensive_school_data.csv')
    print(f"SUCCESS: Found {len(df)} schools with {len(df.columns)} features")
    print(f"Target variable range: {df['Overall_School_Quality_Score'].min():.2f} - {df['Overall_School_Quality_Score'].max():.2f}")
    print(f"Sample schools:")
    print(df[['School_ID', 'Overall_School_Quality_Score']].head())
except Exception as e:
    print(f"ERROR: {e}")
