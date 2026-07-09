"""
Simple test without complex imports
"""

import csv
import random
import os

print("🚀 Starting simple data generation...")

# Create data directory
os.makedirs('data', exist_ok=True)

# Generate basic data
num_schools = 1000
schools = []

for i in range(1, num_schools + 1):
    school_id = f'SCH_{i:04d}'
    region = random.choice(['North', 'South', 'East', 'West', 'Central'])
    school_type = random.choice(['Public', 'Private', 'Charter'])
    student_count = random.randint(200, 2500)
    teacher_count = random.randint(15, 200)
    
    # Generate correlated quality metrics
    base_quality = random.random()  # 0-1 scale
    
    term1_avg = round(45 + base_quality * 50 + random.uniform(-10, 10), 2)
    term2_avg = round(45 + base_quality * 50 + random.uniform(-10, 10), 2)
    stem_rate = round(40 + base_quality * 50 + random.uniform(-15, 15), 2)
    literacy_rate = round(50 + base_quality * 45 + random.uniform(-10, 10), 2)
    failure_risk = round(50 * (1 - base_quality) + random.uniform(-10, 10), 2)
    
    attendance = round(75 + base_quality * 20 + random.uniform(-5, 5), 2)
    library_hours = round(1 + base_quality * 9 + random.uniform(-2, 2), 2)
    extracurricular = round(base_quality * 80 + random.uniform(-20, 20), 2)
    lms_frequency = round(base_quality * 20 + random.uniform(-5, 5), 2)
    
    internet_speed = round(20 + base_quality * 200 + random.uniform(-50, 50), 2)
    smart_classroom = round(base_quality * 0.8 + random.uniform(-0.2, 0.2), 3)
    lab_quality = random.randint(1, 11)
    
    turnover_rate = round(30 * (1 - base_quality) + random.uniform(-10, 10), 2)
    phd_ratio = round(base_quality * 0.4 + random.uniform(-0.1, 0.1), 3)
    dev_hours = round(10 + base_quality * 40 + random.uniform(-10, 10), 2)
    
    budget_per_student = round(2000 + base_quality * 8000 + random.uniform(-1000, 1000), 2)
    budget_it = round(base_quality * 0.2 + random.uniform(-0.05, 0.05), 3)
    budget_scholarships = round(base_quality * 0.15 + random.uniform(-0.03, 0.03), 3)
    regional_economic = round(random.uniform(0.3, 1.0), 3)
    
    student_wellbeing = round(3 + base_quality * 6 + random.uniform(-2, 2), 2)
    teacher_burnout = round(8 * (1 - base_quality) + random.uniform(-2, 2), 2)
    
    # Calculate overall quality score
    overall_score = round(
        (term1_avg + term2_avg) * 0.15 +
        stem_rate * 0.1 +
        literacy_rate * 0.1 +
        attendance * 0.15 +
        (internet_speed / 100) * 10 +
        lab_quality * 2 +
        (1 - turnover_rate / 50) * 15 +
        phd_ratio * 20 +
        (budget_per_student / 100) * 0.5 +
        student_wellbeing * 3 -
        teacher_burnout * 2 -
        failure_risk * 0.1,
        2
    )
    overall_score = max(0, min(100, overall_score))
    
    schools.append([
        school_id, region, school_type, student_count, teacher_count,
        term1_avg, term2_avg, stem_rate, literacy_rate, failure_risk,
        attendance, library_hours, extracurricular, lms_frequency,
        internet_speed, smart_classroom, lab_quality,
        turnover_rate, phd_ratio, dev_hours,
        budget_per_student, budget_it, budget_scholarships, regional_economic,
        student_wellbeing, teacher_burnout, overall_score
    ])

# Save to CSV
headers = [
    'School_ID', 'Region', 'School_Type', 'Student_Count', 'Teacher_Count',
    'Term_1_Avg', 'Term_2_Avg', 'STEM_Subject_Rate', 'Literacy_Rate', 'Failure_Risk_Index',
    'Average_Attendance', 'Library_Usage_Hours', 'Extracurricular_Participation', 'LMS_Login_Frequency',
    'Internet_Speed_Mbps', 'Smart_Classroom_Ratio', 'Lab_Equipment_Quality_Score',
    'Teacher_Turnover_Rate', 'Teacher_PhD_Ratio', 'Professional_Development_Hours_Per_Year',
    'Budget_Per_Student', 'Budget_Allocation_IT', 'Budget_Allocation_Scholarships', 'Regional_Economic_Index',
    'Student_Wellbeing_Score', 'Teacher_Burnout_Index', 'Overall_School_Quality_Score'
]

with open('data/comprehensive_school_data.csv', 'w', newline='') as csvfile:
    writer = csv.writer(csvfile)
    writer.writerow(headers)
    writer.writerows(schools)

print("✅ Data generation completed!")
print(f"📊 Generated {num_schools} schools")
print(f"📁 Saved to data/comprehensive_school_data.csv")

# Show sample
print("\n📋 Sample Data (First 3 Schools):")
for i in range(min(3, len(schools))):
    print(f"School {i+1}: {schools[i][:5]}... Quality Score: {schools[i][-1]}")

print("\n🎉 Phase 1 Complete: Data Generation!")
