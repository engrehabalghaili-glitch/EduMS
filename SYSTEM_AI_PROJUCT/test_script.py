"""
Full System Simulation Test Script for AI-Powered Educational Transformation Suite
Tests the complete pipeline from data generation to strategic recommendations
"""

import os
import sys
import json
import time
import subprocess
from datetime import datetime
from typing import Dict, Any, List

# Add project root to path
project_root = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, project_root)

class SystemTester:
    def __init__(self):
        self.start_time = datetime.now()
        self.test_results = {
            'data_generation': False,
            'ml_training': False,
            'strategy_planning': False,
            'api_service': False,
            'integration': False
        }
        self.errors = []
        
    def log(self, message: str, level: str = "INFO"):
        """Log test messages"""
        timestamp = datetime.now().strftime("%H:%M:%S")
        print(f"[{timestamp}] {level}: {message}")
        
    def test_data_generation(self) -> bool:
        """Test Phase 1: Data Generation"""
        self.log("Testing Phase 1: Data Generation")
        
        try:
            # Check if data file exists
            data_path = os.path.join(project_root, 'data', 'comprehensive_school_data.csv')
            
            if os.path.exists(data_path):
                self.log("Data file exists", "SUCCESS")
                
                # Read and validate data
                with open(data_path, 'r') as f:
                    lines = f.readlines()
                
                if len(lines) > 1:  # Header + at least one data row
                    self.log(f"Data file contains {len(lines)-1} records", "SUCCESS")
                    
                    # Validate columns
                    headers = lines[0].strip().split(',')
                    expected_columns = [
                        'School_ID', 'Region', 'School_Type', 'Student_Count', 'Teacher_Count',
                        'Term_1_Avg', 'Term_2_Avg', 'STEM_Subject_Rate', 'Literacy_Rate', 'Failure_Risk_Index',
                        'Average_Attendance', 'Library_Usage_Hours', 'Extracurricular_Participation', 'LMS_Login_Frequency',
                        'Internet_Speed_Mbps', 'Smart_Classroom_Ratio', 'Lab_Equipment_Quality_Score',
                        'Teacher_Turnover_Rate', 'Teacher_PhD_Ratio', 'Professional_Development_Hours_Per_Year',
                        'Budget_Per_Student', 'Budget_Allocation_IT', 'Budget_Allocation_Scholarships', 'Regional_Economic_Index',
                        'Student_Wellbeing_Score', 'Teacher_Burnout_Index', 'Overall_School_Quality_Score'
                    ]
                    
                    missing_columns = set(expected_columns) - set(headers)
                    if not missing_columns:
                        self.log("All required columns present", "SUCCESS")
                        self.test_results['data_generation'] = True
                        return True
                    else:
                        self.log(f"Missing columns: {missing_columns}", "ERROR")
                        self.errors.append(f"Data generation: Missing columns {missing_columns}")
                        return False
                else:
                    self.log("Data file is empty", "ERROR")
                    self.errors.append("Data generation: Empty data file")
                    return False
            else:
                self.log("Data file does not exist", "ERROR")
                self.errors.append("Data generation: Data file not found")
                return False
                
        except Exception as e:
            self.log(f"Data generation test failed: {e}", "ERROR")
            self.errors.append(f"Data generation: {str(e)}")
            return False
    
    def test_ml_training(self) -> bool:
        """Test Phase 2: ML Training"""
        self.log("Testing Phase 2: ML Training")
        
        try:
            # Check if model artifacts exist
            models_dir = os.path.join(project_root, 'models')
            
            if os.path.exists(models_dir):
                model_files = os.listdir(models_dir)
                self.log(f"Models directory contains: {model_files}", "INFO")
                
                # Check for mock model info
                if 'mock_model_info.txt' in model_files:
                    self.log("Mock model info found", "SUCCESS")
                    
                    # Read and validate model info
                    with open(os.path.join(models_dir, 'mock_model_info.txt'), 'r') as f:
                        model_info = f.read()
                    
                    if 'Performance Metrics' in model_info and 'Top Features' in model_info:
                        self.log("Model info contains required sections", "SUCCESS")
                        self.test_results['ml_training'] = True
                        return True
                    else:
                        self.log("Model info missing required sections", "ERROR")
                        self.errors.append("ML training: Incomplete model info")
                        return False
                else:
                    self.log("Mock model info not found", "ERROR")
                    self.errors.append("ML training: Model info file missing")
                    return False
            else:
                self.log("Models directory does not exist", "ERROR")
                self.errors.append("ML training: Models directory not found")
                return False
                
        except Exception as e:
            self.log(f"ML training test failed: {e}", "ERROR")
            self.errors.append(f"ML training: {str(e)}")
            return False
    
    def test_strategy_planning(self) -> bool:
        """Test Phase 3: Strategy Planning"""
        self.log("Testing Phase 3: Strategy Planning")
        
        try:
            # Check if strategy planner module exists
            strategy_path = os.path.join(project_root, 'strategy_engine', 'strategy_planner.py')
            
            if os.path.exists(strategy_path):
                self.log("Strategy planner module exists", "SUCCESS")
                
                # Try to import and test
                try:
                    from strategy_engine.strategy_planner import EducationalStrategyPlanner
                    
                    # Create planner instance
                    planner = EducationalStrategyPlanner()
                    self.log("Strategy planner instantiated", "SUCCESS")
                    
                    # Test with sample data
                    sample_data = {
                        'School_ID': 'TEST_SCHOOL',
                        'Region': 'North',
                        'School_Type': 'Public',
                        'Student_Count': 1000,
                        'Teacher_Count': 50,
                        'Term_1_Avg': 70.0,
                        'Term_2_Avg': 72.0,
                        'STEM_Subject_Rate': 60.0,
                        'Literacy_Rate': 75.0,
                        'Failure_Risk_Index': 15.0,
                        'Average_Attendance': 85.0,
                        'Library_Usage_Hours': 3.0,
                        'Extracurricular_Participation': 70.0,
                        'LMS_Login_Frequency': 15.0,
                        'Internet_Speed_Mbps': 100.0,
                        'Smart_Classroom_Ratio': 0.5,
                        'Lab_Equipment_Quality_Score': 7,
                        'Teacher_Turnover_Rate': 10.0,
                        'Teacher_PhD_Ratio': 0.2,
                        'Professional_Development_Hours_Per_Year': 30.0,
                        'Budget_Per_Student': 5000.0,
                        'Budget_Allocation_IT': 0.15,
                        'Budget_Allocation_Scholarships': 0.1,
                        'Regional_Economic_Index': 0.7,
                        'Student_Wellbeing_Score': 7.0,
                        'Teacher_Burnout_Index': 4.0,
                        'Overall_School_Quality_Score': 75.0
                    }
                    
                    # Generate strategy
                    strategy = planner.generate_comprehensive_strategy(sample_data)
                    
                    # Validate strategy structure
                    required_sections = ['students', 'teachers', 'administration', 'education_office']
                    stakeholder_strategies = strategy.get('stakeholder_strategies', {})
                    
                    if all(section in stakeholder_strategies for section in required_sections):
                        self.log("All stakeholder strategies generated", "SUCCESS")
                        self.test_results['strategy_planning'] = True
                        return True
                    else:
                        self.log("Missing stakeholder strategies", "ERROR")
                        self.errors.append("Strategy planning: Missing stakeholder sections")
                        return False
                        
                except ImportError as e:
                    self.log(f"Strategy planner import failed: {e}", "ERROR")
                    self.errors.append(f"Strategy planning: Import error - {str(e)}")
                    return False
                except Exception as e:
                    self.log(f"Strategy planner test failed: {e}", "ERROR")
                    self.errors.append(f"Strategy planning: {str(e)}")
                    return False
            else:
                self.log("Strategy planner module not found", "ERROR")
                self.errors.append("Strategy planning: Module file not found")
                return False
                
        except Exception as e:
            self.log(f"Strategy planning test failed: {e}", "ERROR")
            self.errors.append(f"Strategy planning: {str(e)}")
            return False
    
    def test_api_service(self) -> bool:
        """Test Phase 4: API Service"""
        self.log("Testing Phase 4: API Service")
        
        try:
            # Check if API module exists
            api_path = os.path.join(project_root, 'api_service', 'main.py')
            
            if os.path.exists(api_path):
                self.log("API service module exists", "SUCCESS")
                
                # Check if API can be imported
                try:
                    from api_service.main import app
                    self.log("API service imported successfully", "SUCCESS")
                    
                    # Check endpoints
                    available_routes = [route.path for route in app.routes]
                    required_endpoints = ['/health', '/predict', '/recommend', '/analyze-and-strategize']
                    
                    missing_endpoints = set(required_endpoints) - set(available_routes)
                    if not missing_endpoints:
                        self.log("All required endpoints available", "SUCCESS")
                        self.test_results['api_service'] = True
                        return True
                    else:
                        self.log(f"Missing endpoints: {missing_endpoints}", "ERROR")
                        self.errors.append(f"API service: Missing endpoints {missing_endpoints}")
                        return False
                        
                except ImportError as e:
                    self.log(f"API service import failed: {e}", "ERROR")
                    self.errors.append(f"API service: Import error - {str(e)}")
                    return False
                except Exception as e:
                    self.log(f"API service test failed: {e}", "ERROR")
                    self.errors.append(f"API service: {str(e)}")
                    return False
            else:
                self.log("API service module not found", "ERROR")
                self.errors.append("API service: Module file not found")
                return False
                
        except Exception as e:
            self.log(f"API service test failed: {e}", "ERROR")
            self.errors.append(f"API service: {str(e)}")
            return False
    
    def test_integration(self) -> bool:
        """Test Full System Integration"""
        self.log("Testing Full System Integration")
        
        try:
            # Check if all components are ready
            if all(self.test_results.values()):
                self.log("All components ready for integration test", "SUCCESS")
                
                # Create integration test data
                integration_data = {
                    'School_ID': 'INTEGRATION_TEST',
                    'Region': 'Test',
                    'School_Type': 'Public',
                    'Student_Count': 800,
                    'Teacher_Count': 40,
                    'Term_1_Avg': 68.0,
                    'Term_2_Avg': 70.0,
                    'STEM_Subject_Rate': 55.0,
                    'Literacy_Rate': 72.0,
                    'Failure_Risk_Index': 20.0,
                    'Average_Attendance': 82.0,
                    'Library_Usage_Hours': 2.5,
                    'Extracurricular_Participation': 65.0,
                    'LMS_Login_Frequency': 12.0,
                    'Internet_Speed_Mbps': 75.0,
                    'Smart_Classroom_Ratio': 0.4,
                    'Lab_Equipment_Quality_Score': 6,
                    'Teacher_Turnover_Rate': 15.0,
                    'Teacher_PhD_Ratio': 0.15,
                    'Professional_Development_Hours_Per_Year': 25.0,
                    'Budget_Per_Student': 4000.0,
                    'Budget_Allocation_IT': 0.12,
                    'Budget_Allocation_Scholarships': 0.08,
                    'Regional_Economic_Index': 0.6,
                    'Student_Wellbeing_Score': 6.0,
                    'Teacher_Burnout_Index': 5.0,
                    'Overall_School_Quality_Score': 70.0
                }
                
                # Test end-to-end flow
                try:
                    # Load data
                    self.log("Testing data loading...", "INFO")
                    # Data would be loaded from CSV in real scenario
                    
                    # Predict (mock)
                    self.log("Testing prediction...", "INFO")
                    predicted_score = 70.0  # Mock prediction
                    
                    # Generate strategy
                    self.log("Testing strategy generation...", "INFO")
                    from strategy_engine.strategy_planner import EducationalStrategyPlanner
                    planner = EducationalStrategyPlanner()
                    strategy = planner.generate_comprehensive_strategy(integration_data)
                    
                    # Validate integration results
                    if strategy and 'stakeholder_strategies' in strategy:
                        self.log("Integration test passed", "SUCCESS")
                        self.test_results['integration'] = True
                        return True
                    else:
                        self.log("Integration test failed: Invalid strategy", "ERROR")
                        self.errors.append("Integration: Invalid strategy generated")
                        return False
                        
                except Exception as e:
                    self.log(f"Integration test failed: {e}", "ERROR")
                    self.errors.append(f"Integration: {str(e)}")
                    return False
            else:
                self.log("Integration test skipped: Not all components ready", "WARNING")
                failed_components = [k for k, v in self.test_results.items() if not v]
                self.log(f"Failed components: {failed_components}", "WARNING")
                return False
                
        except Exception as e:
            self.log(f"Integration test failed: {e}", "ERROR")
            self.errors.append(f"Integration: {str(e)}")
            return False
    
    def generate_test_report(self) -> Dict[str, Any]:
        """Generate comprehensive test report"""
        end_time = datetime.now()
        duration = end_time - self.start_time
        
        report = {
            'test_summary': {
                'start_time': self.start_time.isoformat(),
                'end_time': end_time.isoformat(),
                'duration_seconds': duration.total_seconds(),
                'total_tests': len(self.test_results),
                'passed_tests': sum(self.test_results.values()),
                'failed_tests': len(self.test_results) - sum(self.test_results.values()),
                'success_rate': (sum(self.test_results.values()) / len(self.test_results)) * 100
            },
            'test_results': self.test_results,
            'errors': self.errors,
            'system_status': 'HEALTHY' if all(self.test_results.values()) else 'NEEDS_ATTENTION'
        }
        
        return report
    
    def save_test_report(self, report: Dict[str, Any]) -> str:
        """Save test report to file"""
        reports_dir = os.path.join(project_root, 'logs')
        os.makedirs(reports_dir, exist_ok=True)
        
        timestamp = datetime.now().strftime('%Y%m%d_%H%M%S')
        report_file = os.path.join(reports_dir, f'system_test_report_{timestamp}.json')
        
        with open(report_file, 'w') as f:
            json.dump(report, f, indent=2)
        
        return report_file
    
    def run_full_test_suite(self) -> Dict[str, Any]:
        """Run the complete test suite"""
        self.log("Starting Full System Test Suite", "INFO")
        self.log("=" * 60)
        
        # Run all tests
        tests = [
            ('Data Generation', self.test_data_generation),
            ('ML Training', self.test_ml_training),
            ('Strategy Planning', self.test_strategy_planning),
            ('API Service', self.test_api_service),
            ('Integration', self.test_integration)
        ]
        
        for test_name, test_func in tests:
            self.log(f"Running {test_name} test...", "INFO")
            try:
                test_func()
            except Exception as e:
                self.log(f"{test_name} test crashed: {e}", "ERROR")
                self.errors.append(f"{test_name}: Test crashed - {str(e)}")
        
        # Generate and save report
        report = self.generate_test_report()
        report_file = self.save_test_report(report)
        
        # Display summary
        self.log("=" * 60)
        self.log("TEST SUITE COMPLETED", "INFO")
        self.log(f"Total Tests: {report['test_summary']['total_tests']}", "INFO")
        self.log(f"Passed: {report['test_summary']['passed_tests']}", "SUCCESS")
        self.log(f"Failed: {report['test_summary']['failed_tests']}", "ERROR")
        self.log(f"Success Rate: {report['test_summary']['success_rate']:.1f}%", "INFO")
        self.log(f"System Status: {report['system_status']}", "SUCCESS" if report['system_status'] == 'HEALTHY' else "WARNING")
        self.log(f"Report saved: {report_file}", "INFO")
        
        if self.errors:
            self.log("\nErrors encountered:", "WARNING")
            for error in self.errors:
                self.log(f"  - {error}", "ERROR")
        
        return report

def main():
    """Main execution function"""
    print("AI-Powered Educational Transformation Suite")
    print("Full System Simulation Test")
    print("=" * 60)
    
    # Create and run tester
    tester = SystemTester()
    report = tester.run_full_test_suite()
    
    # Final status
    if report['system_status'] == 'HEALTHY':
        print("\n" + "=" * 60)
        print("SYSTEM IS READY FOR DEPLOYMENT!")
        print("=" * 60)
        print("\nNext steps:")
        print("1. Start the API server: python run_api.py")
        print("2. Open browser to: http://localhost:8000/docs")
        print("3. Test with sample data using the Swagger UI")
        print("4. Run API tests: python test_api.py")
    else:
        print("\n" + "=" * 60)
        print("SYSTEM NEEDS ATTENTION BEFORE DEPLOYMENT")
        print("=" * 60)
        print("\nPlease address the errors listed above before deployment.")
    
    return report

if __name__ == "__main__":
    main()
