import subprocess
import sys
import os

def install_and_run():
    """Install packages and run data generation"""
    print("Installing required packages...")
    
    # Install packages
    packages = ['pandas', 'numpy', 'scikit-learn']
    for package in packages:
        print(f"Installing {package}...")
        result = subprocess.run([sys.executable, '-m', 'pip', 'install', package], 
                              capture_output=True, text=True)
        if result.returncode == 0:
            print(f"✓ {package} installed successfully")
        else:
            print(f"✗ Failed to install {package}: {result.stderr}")
            return False
    
    print("\nRunning data generation...")
    
    # Create data directory
    os.makedirs('data', exist_ok=True)
    
    # Import and run data generation
    try:
        import pandas as pd
        import numpy as np
        
        # Generate data
        np.random.seed(42)
        num_schools = 500
        
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
        
        # Display sample
        print("=" * 80)
        print("SAMPLE OF GENERATED SCHOOL DATA")
        print("=" * 80)
        print(df.head().to_string(index=False))
        print("\n" + "=" * 80)
        print(f"Dataset Shape: {df.shape}")
        print(f"Target Performance Score Range: {df['Target_Performance_Score'].min():.2f} - {df['Target_Performance_Score'].max():.2f}")
        print("=" * 80)
        
        # Save data
        df.to_csv('data/school_data.csv', index=False)
        print("✓ Data saved to data/school_data.csv")
        
        return True
        
    except Exception as e:
        print(f"✗ Error during data generation: {e}")
        import traceback
        traceback.print_exc()
        return False

if __name__ == "__main__":
    success = install_and_run()
    if success:
        print("\n🎉 Data generation completed successfully!")
    else:
        print("\n❌ Data generation failed!")
