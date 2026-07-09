"""
FastAPI Service for AI-Powered Educational Transformation Suite
Provides RESTful endpoints for school analysis and strategic recommendations
"""

from fastapi import FastAPI, HTTPException, BackgroundTasks
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel, Field
from typing import Dict, List, Any, Optional
import pandas as pd
import numpy as np
import json
import os
import sys
from datetime import datetime

# Add project root to path
sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

# Import modules
try:
    from strategy_engine.strategy_planner import EducationalStrategyPlanner
    from ml_core.model_trainer import EducationalModelTrainer
except ImportError as e:
    print(f"Warning: Could not import modules: {e}")
    # Fallback for testing without full modules
    EducationalStrategyPlanner = None
    EducationalModelTrainer = None

# Initialize FastAPI app
app = FastAPI(
    title="AI Educational Transformation API",
    description="Advanced AI-powered educational analysis and strategic recommendations",
    version="1.0.0",
    docs_url="/docs",
    redoc_url="/redoc"
)

# Add CORS middleware
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Pydantic models for request/response
class SchoolData(BaseModel):
    """School data model for analysis requests"""
    School_ID: str = Field(..., description="Unique school identifier")
    Region: str = Field(..., description="Geographic region")
    School_Type: str = Field(..., description="Type of school (Public/Private/Charter)")
    Student_Count: int = Field(..., ge=1, description="Number of students")
    Teacher_Count: int = Field(..., ge=1, description="Number of teachers")
    Term_1_Avg: float = Field(..., ge=0, le=100, description="Term 1 average grade")
    Term_2_Avg: float = Field(..., ge=0, le=100, description="Term 2 average grade")
    STEM_Subject_Rate: float = Field(..., ge=0, le=100, description="STEM subject success rate")
    Literacy_Rate: float = Field(..., ge=0, le=100, description="Literacy rate")
    Failure_Risk_Index: float = Field(..., ge=0, le=100, description="Failure risk index")
    Average_Attendance: float = Field(..., ge=0, le=100, description="Average attendance rate")
    Library_Usage_Hours: float = Field(..., ge=0, description="Average library usage hours")
    Extracurricular_Participation: float = Field(..., ge=0, le=100, description="Extracurricular participation rate")
    LMS_Login_Frequency: float = Field(..., ge=0, description="LMS login frequency per month")
    Internet_Speed_Mbps: float = Field(..., ge=0, description="Internet speed in Mbps")
    Smart_Classroom_Ratio: float = Field(..., ge=0, le=1, description="Smart classroom ratio")
    Lab_Equipment_Quality_Score: int = Field(..., ge=1, le=10, description="Lab equipment quality score")
    Teacher_Turnover_Rate: float = Field(..., ge=0, le=100, description="Teacher turnover rate percentage")
    Teacher_PhD_Ratio: float = Field(..., ge=0, le=1, description="Teacher PhD ratio")
    Professional_Development_Hours_Per_Year: float = Field(..., ge=0, description="Professional development hours per year")
    Budget_Per_Student: float = Field(..., ge=0, description="Budget per student")
    Budget_Allocation_IT: float = Field(..., ge=0, le=1, description="Budget allocation to IT")
    Budget_Allocation_Scholarships: float = Field(..., ge=0, le=1, description="Budget allocation to scholarships")
    Regional_Economic_Index: float = Field(..., ge=0, le=1, description="Regional economic index")
    Student_Wellbeing_Score: float = Field(..., ge=1, le=10, description="Student wellbeing score")
    Teacher_Burnout_Index: float = Field(..., ge=1, le=10, description="Teacher burnout index")

class AnalysisResponse(BaseModel):
    """Response model for school analysis"""
    success: bool
    timestamp: str
    school_id: str
    predicted_score: float
    confidence_interval: Dict[str, float]
    critical_factors: List[str]
    feature_importance: Dict[str, float]
    strategy_plan: Dict[str, Any]
    processing_time_ms: float

class HealthResponse(BaseModel):
    """Health check response model"""
    status: str
    timestamp: str
    version: str
    components: Dict[str, str]

# Initialize components
strategy_planner = EducationalStrategyPlanner() if EducationalStrategyPlanner else None
model_trainer = None

# Load pre-trained model if available
def load_model():
    """Load pre-trained model"""
    global model_trainer
    try:
        model_trainer = EducationalModelTrainer(model_type='xgboost')
        
        # Try to load saved model
        model_path = os.path.join(os.path.dirname(os.path.dirname(__file__)), 'models', 'xgboost_model.joblib')
        if os.path.exists(model_path):
            import joblib
            model_trainer.model = joblib.load(model_path)
            model_trainer.scaler = joblib.load(os.path.join(os.path.dirname(model_path), 'scaler.joblib'))
            model_trainer.label_encoders = joblib.load(os.path.join(os.path.dirname(model_path), 'label_encoders.joblib'))
            model_trainer.feature_names = joblib.load(os.path.join(os.path.dirname(model_path), 'feature_names.joblib'))
            model_trainer.feature_importance = joblib.load(os.path.join(os.path.dirname(model_path), 'feature_importance.joblib'))
            print("Model loaded successfully")
            return True
        else:
            print("Model file not found, using mock predictions")
            return False
    except Exception as e:
        print(f"Error loading model: {e}")
        return False

# Initialize model on startup
@app.on_event("startup")
async def startup_event():
    """Initialize API components on startup"""
    print("Starting AI Educational Transformation API...")
    load_model()
    print("API startup complete")

@app.get("/", response_model=HealthResponse)
async def root():
    """Root endpoint with health check"""
    return HealthResponse(
        status="healthy",
        timestamp=datetime.now().isoformat(),
        version="1.0.0",
        components={
            "strategy_planner": "operational" if strategy_planner else "fallback",
            "ml_model": "loaded" if model_trainer and model_trainer.model else "mock",
            "data_engine": "ready"
        }
    )

@app.get("/health")
async def health_check():
    """Detailed health check endpoint"""
    return {
        "status": "healthy",
        "timestamp": datetime.now().isoformat(),
        "version": "1.0.0",
        "components": {
            "strategy_planner": "operational" if strategy_planner else "fallback",
            "ml_model": "loaded" if model_trainer and model_trainer.model else "mock",
            "data_engine": "ready"
        },
        "endpoints": {
            "analyze_and_strategize": "/analyze-and-strategize",
            "predict": "/predict",
            "recommend": "/recommend",
            "docs": "/docs"
        }
    }

@app.post("/predict", response_model=Dict[str, Any])
async def predict_school_performance(school_data: SchoolData):
    """Predict school performance score"""
    start_time = datetime.now()
    
    try:
        # Convert to dictionary
        data_dict = school_data.dict()
        
        if model_trainer and model_trainer.model:
            # Use real model prediction
            df = pd.DataFrame([data_dict])
            
            # Preprocess
            X = df.drop(['School_ID'], axis=1)
            
            # Handle categorical variables
            for col in X.select_dtypes(include=['object']).columns:
                if col in model_trainer.label_encoders:
                    X[col] = model_trainer.label_encoders[col].transform(X[col])
            
            # Ensure feature order matches training
            X = X[model_trainer.feature_names]
            
            # Scale features
            X_scaled = model_trainer.scaler.transform(X)
            
            # Predict
            prediction = model_trainer.model.predict(X_scaled)[0]
            
            # Calculate confidence interval (simplified)
            confidence = 5.0  # Placeholder confidence margin
            
        else:
            # Mock prediction based on key metrics
            prediction = (
                data_dict['Term_1_Avg'] * 0.3 +
                data_dict['Term_2_Avg'] * 0.3 +
                data_dict['STEM_Subject_Rate'] * 0.2 +
                data_dict['Average_Attendance'] * 0.1 +
                data_dict['Student_Wellbeing_Score'] * 2
            ) / 2
            prediction = max(0, min(100, prediction))
            confidence = 8.0
        
        processing_time = (datetime.now() - start_time).total_seconds() * 1000
        
        return {
            "success": True,
            "school_id": data_dict['School_ID'],
            "predicted_score": round(float(prediction), 2),
            "confidence_interval": {
                "lower": max(0, round(float(prediction - confidence), 2)),
                "upper": min(100, round(float(prediction + confidence), 2))
            },
            "processing_time_ms": round(processing_time, 2)
        }
        
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Prediction error: {str(e)}")

@app.post("/recommend", response_model=Dict[str, Any])
async def get_recommendations(school_data: SchoolData):
    """Get strategic recommendations for a school"""
    start_time = datetime.now()
    
    try:
        data_dict = school_data.dict()
        
        if strategy_planner:
            # Use real strategy planner
            strategy_plan = strategy_planner.generate_comprehensive_strategy(data_dict)
        else:
            # Mock strategy plan
            strategy_plan = create_mock_strategy(data_dict)
        
        processing_time = (datetime.now() - start_time).total_seconds() * 1000
        
        return {
            "success": True,
            "school_id": data_dict['School_ID'],
            "strategy_plan": strategy_plan,
            "processing_time_ms": round(processing_time, 2)
        }
        
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Recommendation error: {str(e)}")

@app.post("/analyze-and-strategize", response_model=AnalysisResponse)
async def analyze_and_strategize(school_data: SchoolData):
    """
    Main endpoint: Analyze school data and generate comprehensive strategic plan
    Returns predicted score, critical factors, and 4 stakeholder action plans
    """
    start_time = datetime.now()
    
    try:
        data_dict = school_data.dict()
        
        # Step 1: Predict performance score
        if model_trainer and model_trainer.model:
            df = pd.DataFrame([data_dict])
            X = df.drop(['School_ID'], axis=1)
            
            # Handle categorical variables
            for col in X.select_dtypes(include=['object']).columns:
                if col in model_trainer.label_encoders:
                    X[col] = model_trainer.label_encoders[col].transform(X[col])
            
            X = X[model_trainer.feature_names]
            X_scaled = model_trainer.scaler.transform(X)
            prediction = model_trainer.model.predict(X_scaled)[0]
            feature_importance = model_trainer.feature_importance
        else:
            # Mock prediction
            prediction = (
                data_dict['Term_1_Avg'] * 0.3 +
                data_dict['Term_2_Avg'] * 0.3 +
                data_dict['STEM_Subject_Rate'] * 0.2 +
                data_dict['Average_Attendance'] * 0.1 +
                data_dict['Student_Wellbeing_Score'] * 2
            ) / 2
            prediction = max(0, min(100, prediction))
            
            # Mock feature importance
            feature_importance = {
                'Term_1_Avg': 0.15,
                'Term_2_Avg': 0.14,
                'STEM_Subject_Rate': 0.12,
                'Average_Attendance': 0.11,
                'Student_Wellbeing_Score': 0.10,
                'Budget_Per_Student': 0.09,
                'Teacher_PhD_Ratio': 0.08,
                'Internet_Speed_Mbps': 0.07,
                'Lab_Equipment_Quality_Score': 0.06,
                'Teacher_Burnout_Index': 0.05
            }
        
        # Step 2: Identify critical factors
        critical_factors = identify_critical_factors(data_dict)
        
        # Step 3: Generate strategy plan
        if strategy_planner:
            strategy_plan = strategy_planner.generate_comprehensive_strategy(data_dict)
        else:
            strategy_plan = create_mock_strategy(data_dict)
        
        # Step 4: Calculate confidence interval
        confidence = 5.0 if model_trainer and model_trainer.model else 8.0
        
        processing_time = (datetime.now() - start_time).total_seconds() * 1000
        
        return AnalysisResponse(
            success=True,
            timestamp=datetime.now().isoformat(),
            school_id=data_dict['School_ID'],
            predicted_score=round(float(prediction), 2),
            confidence_interval={
                "lower": max(0, round(float(prediction - confidence), 2)),
                "upper": min(100, round(float(prediction + confidence), 2))
            },
            critical_factors=critical_factors,
            feature_importance=feature_importance,
            strategy_plan=strategy_plan,
            processing_time_ms=round(processing_time, 2)
        )
        
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Analysis error: {str(e)}")

def identify_critical_factors(data_dict: Dict[str, Any]) -> List[str]:
    """Identify critical factors affecting school performance"""
    factors = []
    
    # Academic factors
    if data_dict['STEM_Subject_Rate'] < 50:
        factors.append("Low STEM performance")
    if data_dict['Literacy_Rate'] < 60:
        factors.append("Literacy concerns")
    if data_dict['Failure_Risk_Index'] > 25:
        factors.append("High failure risk")
    
    # Engagement factors
    if data_dict['Average_Attendance'] < 80:
        factors.append("Low attendance")
    if data_dict['Student_Wellbeing_Score'] < 5:
        factors.append("Student wellbeing issues")
    
    # Infrastructure factors
    if data_dict['Internet_Speed_Mbps'] < 50:
        factors.append("Inadequate internet")
    if data_dict['Lab_Equipment_Quality_Score'] < 5:
        factors.append("Poor lab equipment")
    
    # Human capital factors
    if data_dict['Teacher_Turnover_Rate'] > 20:
        factors.append("High teacher turnover")
    if data_dict['Teacher_Burnout_Index'] > 6:
        factors.append("Teacher burnout")
    
    # Financial factors
    if data_dict['Budget_Per_Student'] < 3000:
        factors.append("Low per-student budget")
    
    return factors

def create_mock_strategy(data_dict: Dict[str, Any]) -> Dict[str, Any]:
    """Create mock strategy plan when strategy planner is not available"""
    return {
        'school_id': data_dict['School_ID'],
        'analysis_timestamp': datetime.now().isoformat(),
        'overall_quality_score': data_dict.get('Overall_School_Quality_Score', 75),
        'urgency_level': 'MEDIUM',
        'total_issues_identified': 4,
        'stakeholder_strategies': {
            'students': {
                'priority_issues': ['Academic performance needs improvement'],
                'action_plans': ['Personalized learning interventions'],
                'resources': ['Educational software licenses'],
                'timeline': ['3-6 months'],
                'expected_outcomes': ['10-15% improvement in grades']
            },
            'teachers': {
                'priority_issues': ['Professional development needed'],
                'professional_development': ['Technology integration training'],
                'technology_support': ['Digital classroom tools'],
                'expected_outcomes': ['Improved teaching effectiveness']
            },
            'administration': {
                'critical_issues': ['Infrastructure upgrades needed'],
                'infrastructure_investments': ['Network improvements'],
                'resource_allocation': ['Technology budget increase'],
                'implementation_timeline': ['6-12 months']
            },
            'education_office': {
                'policy_recommendations': ['Review funding allocation'],
                'funding_strategies': ['Grant applications'],
                'systemic_improvements': ['Regional collaboration'],
                'implementation_roadmap': ['12-18 months']
            }
        },
        'priority_ranking': {
            'students': 1,
            'teachers': 1,
            'administration': 1,
            'education_office': 1
        }
    }

if __name__ == "__main__":
    import uvicorn
    print("Starting AI Educational Transformation API...")
    uvicorn.run(app, host="0.0.0.0", port=8000, reload=True)
