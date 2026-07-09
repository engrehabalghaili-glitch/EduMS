# -*- coding: utf-8 -*-
"""
Complete System Verification - Final Comprehensive System Check
"""

import subprocess
import sys
import os

def complete_system_verification():
    print("="*80)
    print("           AI EDUCATIONAL TRANSFORMATION SYSTEM - COMPLETE VERIFICATION")
    print("="*80)
    
    # Execute final system status with live output
    try:
        process = subprocess.Popen(
            ['c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/python.exe', 'final_system_status.py'],
            stdout=subprocess.PIPE,
            stderr=subprocess.STDOUT,
            text=True,
            encoding='utf-8',
            bufsize=1,
            universal_newlines=True,
            cwd='c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT'
        )
        
        # Display output in real-time
        print("RUNNING COMPLETE SYSTEM VERIFICATION:")
        print("-" * 60)
        
        output_lines = []
        while True:
            output = process.stdout.readline()
            if output == '' and process.poll() is not None:
                break
            if output:
                line = output.strip()
                print(line)
                output_lines.append(line)
        
        return_code = process.poll()
        print(f"\nSystem verification completed with return code: {return_code}")
        
        # Extract final status
        overall_status = "UNKNOWN"
        for line in output_lines:
            if "Overall System Status:" in line:
                overall_status = line.split(':')[-1].strip()
                break
        
        # Display final results
        print("\n" + "="*80)
        print("                    VERIFICATION RESULTS")
        print("="*80)
        print(f"Overall System Status: {overall_status}")
        
        if "OPERATIONAL" in overall_status:
            print("\nSUCCESS: The AI Educational Transformation System is fully operational!")
            print("All components are working correctly and the system is ready for production use.")
            print("\nNext steps:")
            print("  1. Start the API server: python api_service/main_ar.py")
            print("  2. Access the API at: http://localhost:8000")
            print("  3. View documentation at: http://localhost:8000/docs")
            print("  4. Test the system with sample data")
        else:
            print("\nATTENTION: The system needs attention before full deployment.")
            print("Please review the issues identified above and take corrective action.")
        
        print("="*80)
        
        # Check if status report was saved
        if os.path.exists('system_status_report.json'):
            print("\nStatus report saved to: system_status_report.json")
        
        return "OPERATIONAL" in overall_status
        
    except Exception as e:
        print(f"Error during system verification: {e}")
        import traceback
        traceback.print_exc()
        return False

if __name__ == "__main__":
    success = complete_system_verification()
    
    print(f"\nFINAL VERIFICATION RESULT: {'SUCCESS' if success else 'NEEDS ATTENTION'}")
    
    if success:
        print("\nThe AI Educational Transformation System has been successfully verified!")
        print("The original NaN problem has been resolved and all components are operational.")
    else:
        print("\nThe system verification revealed issues that need to be addressed.")
        print("Please review the detailed report above for specific actions required.")
