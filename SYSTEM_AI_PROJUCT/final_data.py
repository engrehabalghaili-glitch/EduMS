# Final attempt - simple direct approach

print("Starting data generation...")

# Basic imports without pandas first
import random
import csv
import os

# Create data directory
os.makedirs('data', exist_ok=True)

# Generate data manually
num_schools = 500
schools = []

for i in range(1, num_schools + 1):
    school_id = f'SCH_{i:04d}'
    student_count = random.randint(100, 2000)
    teacher_count = random.randint(10, 150)
    avg_grade = round(random.uniform(45, 95), 2)
    teacher_exp = round(random.uniform(1, 25), 1)
    infra_score = random.randint(1, 11)
    budget = round(random.uniform(1000, 10000), 2)
    parent_sat = random.randint(1, 11)
    dropout = round(random.uniform(0, 30), 2)
    
    # Calculate performance score
    performance = (
        0.3 * avg_grade +
        0.2 * (teacher_exp / 25 * 100) +
        0.15 * (infra_score / 10 * 100) +
        0.15 * (budget / 10000 * 100) +
        0.1 * (parent_sat / 10 * 100) -
        0.1 * dropout +
        random.uniform(-5, 5)  # noise
    )
    performance = max(0, min(100, round(performance, 2)))
    
    schools.append([
        school_id, student_count, teacher_count, avg_grade, 
        teacher_exp, infra_score, budget, parent_sat, dropout, performance
    ])

# Save to CSV
with open('data/school_data.csv', 'w', newline='') as csvfile:
    writer = csv.writer(csvfile)
    writer.writerow([
        'School_ID', 'Student_Count', 'Teacher_Count', 'Avg_Student_Grade',
        'Teacher_Experience_Avg', 'Infrastructure_Score', 'Budget_Per_Student',
        'Parent_Satisfaction_Score', 'Dropout_Rate', 'Target_Performance_Score'
    ])
    writer.writerows(schools)

print("✓ Data generation completed!")
print(f"✓ Generated {num_schools} schools")
print("✓ Data saved to data/school_data.csv")

# Display sample
print("\n" + "="*80)
print("SAMPLE DATA:")
print("="*80)
for i, school in enumerate(schools[:5]):
    print(f"School {i+1}: {school}")
print("="*80)
