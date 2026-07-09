"""
Test script for the API endpoints
"""

import requests
import json
import time

def test_api_endpoints():
    """Test all API endpoints with sample data"""
    
    # Sample school data for testing
    sample_school = {
        "School_ID": "SCH_TEST_001",
        "Region": "North",
        "School_Type": "Public",
        "Student_Count": 1200,
        "Teacher_Count": 60,
        "Term_1_Avg": 65.5,
        "Term_2_Avg": 68.2,
        "STEM_Subject_Rate": 45.3,
        "Literacy_Rate": 58.7,
        "Failure_Risk_Index": 28.4,
        "Average_Attendance": 78.5,
        "Library_Usage_Hours": 1.8,
        "Extracurricular_Participation": 42.1,
        "LMS_Login_Frequency": 8.3,
        "Internet_Speed_Mbps": 35.7,
        "Smart_Classroom_Ratio": 0.45,
        "Lab_Equipment_Quality_Score": 4,
        "Teacher_Turnover_Rate": 24.8,
        "Teacher_PhD_Ratio": 0.08,
        "Professional_Development_Hours_Per_Year": 15.2,
        "Budget_Per_Student": 2800.0,
        "Budget_Allocation_IT": 0.07,
        "Budget_Allocation_Scholarships": 0.04,
        "Regional_Economic_Index": 0.52,
        "Student_Wellbeing_Score": 4.2,
        "Teacher_Burnout_Index": 7.1
    }
    
    base_url = "http://localhost:8000"
    
    print("Testing AI Educational Transformation API")
    print("=" * 50)
    
    # Test 1: Health Check
    print("\n1. Testing Health Check...")
    try:
        response = requests.get(f"{base_url}/health")
        if response.status_code == 200:
            print("   Health check: PASSED")
            health_data = response.json()
            print(f"   API Status: {health_data.get('status')}")
            print(f"   Components: {health_data.get('components', {})}")
        else:
            print(f"   Health check: FAILED ({response.status_code})")
            return False
    except requests.exceptions.ConnectionError:
        print("   Health check: FAILED - API not running")
        print("   Please start the API first: python run_api.py")
        return False
    
    # Test 2: Predict Endpoint
    print("\n2. Testing Predict Endpoint...")
    try:
        response = requests.post(f"{base_url}/predict", json=sample_school)
        if response.status_code == 200:
            print("   Predict endpoint: PASSED")
            pred_data = response.json()
            print(f"   Predicted Score: {pred_data.get('predicted_score')}")
            print(f"   Confidence Interval: {pred_data.get('confidence_interval')}")
        else:
            print(f"   Predict endpoint: FAILED ({response.status_code})")
            print(f"   Error: {response.text}")
    except Exception as e:
        print(f"   Predict endpoint: ERROR - {e}")
    
    # Test 3: Recommend Endpoint
    print("\n3. Testing Recommend Endpoint...")
    try:
        response = requests.post(f"{base_url}/recommend", json=sample_school)
        if response.status_code == 200:
            print("   Recommend endpoint: PASSED")
            rec_data = response.json()
            strategy = rec_data.get('strategy_plan', {})
            print(f"   Urgency Level: {strategy.get('urgency_level')}")
            print(f"   Total Issues: {strategy.get('total_issues_identified')}")
        else:
            print(f"   Recommend endpoint: FAILED ({response.status_code})")
            print(f"   Error: {response.text}")
    except Exception as e:
        print(f"   Recommend endpoint: ERROR - {e}")
    
    # Test 4: Main Analyze and Strategize Endpoint
    print("\n4. Testing Main Analyze-and-Strategize Endpoint...")
    try:
        response = requests.post(f"{base_url}/analyze-and-strategize", json=sample_school)
        if response.status_code == 200:
            print("   Main endpoint: PASSED")
            analysis_data = response.json()
            print(f"   Predicted Score: {analysis_data.get('predicted_score')}")
            print(f"   Critical Factors: {len(analysis_data.get('critical_factors', []))}")
            
            strategy = analysis_data.get('strategy_plan', {})
            stakeholders = strategy.get('stakeholder_strategies', {})
            
            print(f"   Stakeholder Strategies Generated:")
            for stakeholder, plans in stakeholders.items():
                issues = len(plans.get('priority_issues', plans.get('critical_issues', [])))
                print(f"     - {stakeholder.title()}: {issues} issues identified")
            
            print(f"   Processing Time: {analysis_data.get('processing_time_ms')} ms")
            
        else:
            print(f"   Main endpoint: FAILED ({response.status_code})")
            print(f"   Error: {response.text}")
    except Exception as e:
        print(f"   Main endpoint: ERROR - {e}")
    
    print("\n" + "=" * 50)
    print("API Testing Complete!")
    print("\nTo manually test the API:")
    print("1. Start the server: python run_api.py")
    print("2. Open browser to: http://localhost:8000/docs")
    print("3. Use the Swagger UI to test endpoints")
    
    return True

if __name__ == "__main__":
    test_api_endpoints()
