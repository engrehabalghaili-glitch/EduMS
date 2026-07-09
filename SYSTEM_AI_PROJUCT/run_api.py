"""
Runner script for FastAPI service
"""

import sys
import os
import uvicorn

# Add the project root to Python path
project_root = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, project_root)

def main():
    """Run the FastAPI service"""
    print("Starting AI Educational Transformation API...")
    print("API Documentation will be available at:")
    print("  - Swagger UI: http://localhost:8000/docs")
    print("  - ReDoc: http://localhost:8000/redoc")
    print("  - Health Check: http://localhost:8000/health")
    print("\nMain Endpoints:")
    print("  - POST /analyze-and-strategize - Full analysis and strategy")
    print("  - POST /predict - Performance prediction only")
    print("  - POST /recommend - Strategy recommendations only")
    
    try:
        import uvicorn
        from api_service.main import app
        
        uvicorn.run(app, host="0.0.0.0", port=8000, reload=True)
        
    except ImportError as e:
        print(f"Import error: {e}")
        print("Please ensure all dependencies are installed:")
        print("pip install fastapi uvicorn pydantic")
    except Exception as e:
        print(f"Error starting API: {e}")

if __name__ == "__main__":
    main()
