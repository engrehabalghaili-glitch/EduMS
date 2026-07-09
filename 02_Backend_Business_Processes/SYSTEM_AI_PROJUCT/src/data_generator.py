import pandas as pd
import numpy as np
from datetime import datetime
import os

def generate_school_data(num_schools=500, random_seed=42):
    """
    Generate synthetic school data for ML model training
    
    Args:
        num_schools (int): Number of schools to generate
        random_seed (int): Random seed for reproducibility
    
    Returns:
        pd.DataFrame: Generated school data
    """
    np.random.seed(random_seed)
    
    # Generate basic school information
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
    
    # Calculate Target_Performance_Score based on multiple factors
    # This creates a realistic relationship between features and target
    df['Target_Performance_Score'] = (
        0.3 * (df['Avg_Student_Grade'] / 100 * 100) +
        0.2 * (df['Teacher_Experience_Avg'] / 25 * 100) +
        0.15 * (df['Infrastructure_Score'] / 10 * 100) +
        0.15 * (df['Budget_Per_Student'] / 10000 * 100) +
        0.1 * (df['Parent_Satisfaction_Score'] / 10 * 100) -
        0.1 * df['Dropout_Rate'] +
        np.random.normal(0, 5, num_schools)  # Add some noise
    )
    
    # Ensure performance score is within 0-100 range
    df['Target_Performance_Score'] = np.clip(df['Target_Performance_Score'], 0, 100)
    
    # Round numerical columns for cleaner output
    df['Avg_Student_Grade'] = df['Avg_Student_Grade'].round(2)
    df['Teacher_Experience_Avg'] = df['Teacher_Experience_Avg'].round(1)
    df['Budget_Per_Student'] = df['Budget_Per_Student'].round(2)
    df['Dropout_Rate'] = df['Dropout_Rate'].round(2)
    df['Target_Performance_Score'] = df['Target_Performance_Score'].round(2)
    
    return df

def save_data(df, filename='school_data.csv'):
    """Save generated data to CSV file"""
    # Create data directory if it doesn't exist
    data_dir = os.path.join(os.path.dirname(os.path.dirname(__file__)), 'data')
    os.makedirs(data_dir, exist_ok=True)
    
    filepath = os.path.join(data_dir, filename)
    df.to_csv(filepath, index=False)
    print(f"Data saved to {filepath}")
    return filepath

def display_sample(df, num_samples=5):
    """Display sample of generated data"""
    print("=" * 80)
    print("SAMPLE OF GENERATED SCHOOL DATA")
    print("=" * 80)
    print(df.head(num_samples).to_string(index=False))
    print("\n" + "=" * 80)
    print(f"Dataset Shape: {df.shape}")
    print(f"Target Performance Score Range: {df['Target_Performance_Score'].min():.2f} - {df['Target_Performance_Score'].max():.2f}")
    print("=" * 80)

if __name__ == "__main__":
    # Generate data
    school_data = generate_school_data(num_schools=500)
    
    # Display sample
    display_sample(school_data)
    
    # Save data
    save_data(school_data)
