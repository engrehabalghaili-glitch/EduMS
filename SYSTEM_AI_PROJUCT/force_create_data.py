"""
Force create data with absolute paths
"""

import os

def main():
    print("🔧 Force creating data directory and file...")
    
    # Get absolute paths
    current_dir = os.getcwd()
    data_dir = os.path.join(current_dir, 'data')
    csv_file = os.path.join(data_dir, 'comprehensive_school_data.csv')
    
    print(f"Current directory: {current_dir}")
    print(f"Data directory: {data_dir}")
    print(f"CSV file: {csv_file}")
    
    # Create directory with full path
    try:
        os.makedirs(data_dir, exist_ok=True)
        print(f"✓ Data directory created/verified: {os.path.exists(data_dir)}")
    except Exception as e:
        print(f"✗ Error creating directory: {e}")
        return
    
    # Create sample data
    sample_data = """School_ID,Region,School_Type,Student_Count,Teacher_Count,Term_1_Avg,Term_2_Avg,STEM_Subject_Rate,Literacy_Rate,Failure_Risk_Index,Average_Attendance,Library_Usage_Hours,Extracurricular_Participation,LMS_Login_Frequency,Internet_Speed_Mbps,Smart_Classroom_Ratio,Lab_Equipment_Quality_Score,Teacher_Turnover_Rate,Teacher_PhD_Ratio,Professional_Development_Hours_Per_Year,Budget_Per_Student,Budget_Allocation_IT,Budget_Allocation_Scholarships,Regional_Economic_Index,Student_Wellbeing_Score,Teacher_Burnout_Index,Overall_School_Quality_Score
SCH_0001,North,Public,1200,60,78.5,82.3,65.4,88.2,12.5,92.3,4.5,78.9,18.2,150.5,0.65,8,15.2,0.25,45.3,8500.0,0.18,0.12,0.75,7.8,3.2,82.45
SCH_0002,South,Private,800,40,85.2,87.1,78.9,92.5,8.3,95.1,6.2,85.4,22.1,280.3,0.82,9,8.7,0.35,52.8,12000.0,0.22,0.15,0.85,8.5,2.1,89.73
SCH_0003,East,Public,1500,75,65.8,68.2,45.6,72.3,18.7,85.6,2.8,62.1,12.4,85.7,0.35,5,22.4,0.15,28.9,4500.0,0.08,0.06,0.45,5.2,6.8,65.21
SCH_0004,West,Charter,600,30,91.3,89.7,88.2,95.8,5.1,97.8,8.1,92.3,25.6,450.2,0.91,10,6.3,0.42,68.4,15000.0,0.25,0.18,0.92,9.1,1.8,93.56
SCH_0005,Central,Public,2000,100,72.4,75.6,58.9,79.4,14.2,88.9,3.9,71.2,15.8,120.4,0.48,6,18.9,0.18,38.7,6200.0,0.12,0.09,0.68,6.7,4.5,74.82"""
    
    # Write file
    try:
        with open(csv_file, 'w', encoding='utf-8') as f:
            f.write(sample_data)
        print(f"✓ CSV file created: {os.path.exists(csv_file)}")
        print(f"✓ File size: {os.path.getsize(csv_file)} bytes")
    except Exception as e:
        print(f"✗ Error writing file: {e}")
        return
    
    # Verify and show content
    try:
        with open(csv_file, 'r', encoding='utf-8') as f:
            lines = f.readlines()
            print(f"✓ File contains {len(lines)} lines")
            print("\n📋 First 3 lines:")
            for i, line in enumerate(lines[:3]):
                print(f"Line {i+1}: {line.strip()}")
    except Exception as e:
        print(f"✗ Error reading file: {e}")
        return
    
    print("\n🎉 SUCCESS: Data file created successfully!")
    print(f"📍 Location: {csv_file}")

if __name__ == "__main__":
    main()
