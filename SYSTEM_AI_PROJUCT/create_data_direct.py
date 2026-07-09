"""
Direct data creation without complex dependencies
"""

print("Creating data directory and generating data...")

import os

# Create data directory
if not os.path.exists('data'):
    os.makedirs('data')
    print("✓ Created data directory")
else:
    print("✓ Data directory already exists")

# Create a simple CSV with sample data
sample_data = """School_ID,Region,School_Type,Student_Count,Teacher_Count,Term_1_Avg,Term_2_Avg,STEM_Subject_Rate,Literacy_Rate,Failure_Risk_Index,Average_Attendance,Library_Usage_Hours,Extracurricular_Participation,LMS_Login_Frequency,Internet_Speed_Mbps,Smart_Classroom_Ratio,Lab_Equipment_Quality_Score,Teacher_Turnover_Rate,Teacher_PhD_Ratio,Professional_Development_Hours_Per_Year,Budget_Per_Student,Budget_Allocation_IT,Budget_Allocation_Scholarships,Regional_Economic_Index,Student_Wellbeing_Score,Teacher_Burnout_Index,Overall_School_Quality_Score
SCH_0001,North,Public,1200,60,78.5,82.3,65.4,88.2,12.5,92.3,4.5,78.9,18.2,150.5,0.65,8,15.2,0.25,45.3,8500.0,0.18,0.12,0.75,7.8,3.2,82.45
SCH_0002,South,Private,800,40,85.2,87.1,78.9,92.5,8.3,95.1,6.2,85.4,22.1,280.3,0.82,9,8.7,0.35,52.8,12000.0,0.22,0.15,0.85,8.5,2.1,89.73
SCH_0003,East,Public,1500,75,65.8,68.2,45.6,72.3,18.7,85.6,2.8,62.1,12.4,85.7,0.35,5,22.4,0.15,28.9,4500.0,0.08,0.06,0.45,5.2,6.8,65.21
SCH_0004,West,Charter,600,30,91.3,89.7,88.2,95.8,5.1,97.8,8.1,92.3,25.6,450.2,0.91,10,6.3,0.42,68.4,15000.0,0.25,0.18,0.92,9.1,1.8,93.56
SCH_0005,Central,Public,2000,100,72.4,75.6,58.9,79.4,14.2,88.9,3.9,71.2,15.8,120.4,0.48,6,18.9,0.18,38.7,6200.0,0.12,0.09,0.68,6.7,4.5,74.82"""

with open('data/comprehensive_school_data.csv', 'w') as f:
    f.write(sample_data)

print("✓ Sample data created successfully!")
print("✓ File saved to: data/comprehensive_school_data.csv")
print("✓ Contains 5 sample schools with all required features")
print("\n🎉 Phase 1 Complete: Data Generation!")
