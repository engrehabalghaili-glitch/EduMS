import pandas as pd
import numpy as np
import os

def generate_school_data(num_schools=500):
    """Generate synthetic school data"""
    np.random.seed(42)
    
    data = {
        'School_ID': [f'SCH_{i:04d}' for i in range(1, num_schools + 1)],
        'Student_Count': np.random.randint(100, 2000, num_schools),
        'Teacher_Count': np.random.randint(10, 150, num_schools),
        'Avg_Student_Grade': np.random.uniform(45, 95, num_schools),
        'Teacher_Experience_Avg': np.random.uniform(1, 25, num_schools),
        'Infrastructure_Score': np.random.randint(1, 11, num_schools),
        'Budget_Per_Student': np.random.uniform(1000, 10000, num_schools),
        'Parent_Satisfaction_Score': np.random.randint(1, 11, num_schools),
        'Dropout_Rate': np.random.uniform(0, 30, num_schools)
    }
    
    df = pd.DataFrame(data)
    
    # Calculate Target_Performance_Score
    df['Target_Performance_Score'] = (
        0.3 * (df['Avg_Student_Grade'] / 100 * 100) +
        0.2 * (df['Teacher_Experience_Avg'] / 25 * 100) +
        0.15 * (df['Infrastructure_Score'] / 10 * 100) +
        0.15 * (df['Budget_Per_Student'] / 10000 * 100) +
        0.1 * (df['Parent_Satisfaction_Score'] / 10 * 100) -
        0.1 * df['Dropout_Rate'] +
        np.random.normal(0, 5, num_schools)
    )
    
    df['Target_Performance_Score'] = np.clip(df['Target_Performance_Score'], 0, 100)
    
    # Round values
    df['Avg_Student_Grade'] = df['Avg_Student_Grade'].round(2)
    df['Teacher_Experience_Avg'] = df['Teacher_Experience_Avg'].round(1)
    df['Budget_Per_Student'] = df['Budget_Per_Student'].round(2)
    df['Dropout_Rate'] = df['Dropout_Rate'].round(2)
    df['Target_Performance_Score'] = df['Target_Performance_Score'].round(2)
    
    return df

# Generate and display data
print("Generating school data...")
school_data = generate_school_data(num_schools=500)

print("=" * 80)
print("SAMPLE OF GENERATED SCHOOL DATA")
print("=" * 80)
print(school_data.head().to_string(index=False))
print("\n" + "=" * 80)
print(f"Dataset Shape: {school_data.shape}")
print(f"Target Performance Score Range: {school_data['Target_Performance_Score'].min():.2f} - {school_data['Target_Performance_Score'].max():.2f}")
print("=" * 80)

# Save data
os.makedirs('data', exist_ok=True)
school_data.to_csv('data/school_data.csv', index=False)
print("Data saved to data/school_data.csv")
