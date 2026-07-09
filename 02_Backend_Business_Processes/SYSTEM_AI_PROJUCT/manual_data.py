# Manual data generation without external libraries

def generate_school_data():
    """Generate sample school data manually"""
    schools = []
    
    # Generate 5 sample schools for demonstration
    sample_data = [
        ['SCH_0001', 500, 25, 78.5, 12.3, 7, 4500.50, 8, 5.2, 75.23],
        ['SCH_0002', 800, 40, 82.1, 15.7, 8, 6200.75, 9, 3.8, 82.45],
        ['SCH_0003', 350, 18, 65.3, 8.2, 4, 2800.00, 5, 12.5, 58.67],
        ['SCH_0004', 1200, 60, 88.9, 18.5, 9, 8500.25, 10, 2.1, 89.12],
        ['SCH_0005', 600, 30, 71.4, 10.8, 6, 3800.80, 7, 8.7, 68.34]
    ]
    
    columns = [
        'School_ID', 'Student_Count', 'Teacher_Count', 'Avg_Student_Grade',
        'Teacher_Experience_Avg', 'Infrastructure_Score', 'Budget_Per_Student',
        'Parent_Satisfaction_Score', 'Dropout_Rate', 'Target_Performance_Score'
    ]
    
    # Create CSV content
    csv_content = ','.join(columns) + '\n'
    for school in sample_data:
        csv_content += ','.join(map(str, school)) + '\n'
    
    return csv_content

# Generate and save data
print("Generating sample school data...")

csv_data = generate_school_data()

# Save to file
with open('data/school_data_sample.csv', 'w') as f:
    f.write(csv_data)

print("Sample data generated and saved to data/school_data_sample.csv")
print("\nSample data:")
print(csv_data)
