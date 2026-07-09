"""
Runner script for strategy planner testing
"""

import sys
import os

# Add the project root to Python path
project_root = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, project_root)

try:
    from strategy_engine.strategy_planner import test_strategy_planner
    
    print("🚀 Testing Strategy Planner...")
    
    # Run test
    strategy_plan = test_strategy_planner()
    
    print("\n✅ SUCCESS: Strategy planner test completed!")
    print("📋 Strategic recommendations generated for all stakeholders")
    
except Exception as e:
    print(f"❌ ERROR: {e}")
    import traceback
    traceback.print_exc()
