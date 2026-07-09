# AI Educational Transformation System - GUI Installation Guide

## Overview
This guide will help you install and run the GUI (Graphical User Interface) version of the AI Educational Transformation System using Streamlit.

## Prerequisites
- Python 3.8 or higher
- Virtual environment (recommended)
- All model files from the original system

## Installation Steps

### 1. Activate Virtual Environment
```bash
# If you already have the virtual environment from the original system
c:/Users/Elite/Desktop/SYSTEM_AI_PROJUCT/venv/Scripts/activate

# Or create a new one
python -m venv venv
venv/Scripts/activate  # Windows
# source venv/bin/activate  # Linux/Mac
```

### 2. Install GUI Dependencies
```bash
pip install -r requirements_gui.txt
```

### 3. Verify Model Files
Make sure the following files exist in your project:
- `models/random_forest_model.joblib`
- `models/xgboost_model.joblib`
- `models/scaler.joblib`
- `models/label_encoders.joblib`
- `models/feature_names.joblib`
- `models/feature_importance.joblib`
- `data/comprehensive_school_data.csv`

### 4. Run the GUI Application

#### Method 1: Using the Run Script (Recommended)
```bash
python run_gui.py
```

#### Method 2: Direct Streamlit Command
```bash
streamlit run gui_app.py
```

## Features

### 1. Data Entry Unit
- **Manual Input**: Form with Arabic labels for single school data entry
- **File Upload**: Excel/CSV file upload for batch processing

### 2. Results Display
- **Performance Gauge**: Visual score display with color coding
- **Factor Analysis**: Top 10 influencing factors chart
- **Strategic Plans**: Four strategic recommendations (Student, Teacher, Administration, Library)

### 3. Arabic Support
- Full Arabic interface
- Right-to-left text support
- Arabic text reshaping for proper display

## Data Requirements

### Required Fields for Single School Entry:
- **Basic Info**: School Name, Region, Type, Grades
- **Academic Data**: Student count, Teacher count, Test scores
- **Financial Data**: Budget, Spending per student, Teacher salaries
- **Infrastructure**: Classrooms, Area, Labs, Libraries
- **Engagement**: Attendance, Participation, Activities
- **Resources**: Teacher-student ratio, Training hours, Satisfaction

### File Upload Requirements:
- Excel (.xlsx, .xls) or CSV files
- Same column names as the manual form
- Consistent data formats
- No missing critical data

## Usage Instructions

### For Single School Analysis:
1. Navigate to "Analyse d'École" page
2. Fill in all required fields (marked with *)
3. Click "Analyser l'École"
4. View results and recommendations
5. Download results if needed

### For Batch Analysis:
1. Navigate to "Analyse de Fichier" page
2. Upload your Excel/CSV file
3. Click "Analyser toutes les écoles"
4. View batch results and statistics
5. Download complete results

## Troubleshooting

### Common Issues:
1. **Models not loading**: Verify all model files exist in `models/` directory
2. **Streamlit not found**: Install with `pip install streamlit`
3. **Arabic text not displaying**: Install `arabic-reshaper` and `python-bidi`
4. **File upload errors**: Check file format and column names
5. **Port already in use**: Streamlit will automatically use another port

### Error Messages:
- "Impossible de charger les modèles": Check model files
- "Erreur lors de la prédiction": Verify input data format
- "Erreur lors de la lecture du fichier": Check file format

## Browser Access
After starting the GUI, access it at:
- Primary URL: http://localhost:8501
- Alternative: Streamlit will show the URL in the terminal

## System Requirements
- **RAM**: Minimum 4GB, Recommended 8GB
- **Storage**: 500MB for models and data
- **Browser**: Chrome, Firefox, Safari, or Edge

## Support
For technical support:
1. Check the troubleshooting section above
2. Verify all prerequisites are met
3. Ensure all model files are present
4. Contact development team if issues persist

## Next Steps
1. Install dependencies
2. Verify model files
3. Run the GUI application
4. Test with sample data
5. Deploy for production use
