@echo off
echo Installing required packages...
pip install pandas numpy scikit-learn

echo.
echo Running data generation...
python direct_data_gen.py

echo.
echo Checking if data file was created...
if exist data\school_data.csv (
    echo ✓ Data file created successfully!
    echo Displaying first few lines:
    type data\school_data.csv | more
) else (
    echo ✗ Data file was not created
)

pause
