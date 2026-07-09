try:
    import pandas as pd
    print("✓ Pandas imported successfully")
    print(f"  Version: {pd.__version__}")
except ImportError as e:
    print(f"✗ Pandas import failed: {e}")

try:
    import numpy as np
    print("✓ NumPy imported successfully")
    print(f"  Version: {np.__version__}")
except ImportError as e:
    print(f"✗ NumPy import failed: {e}")

try:
    import sklearn
    print("✓ Scikit-learn imported successfully")
    print(f"  Version: {sklearn.__version__}")
except ImportError as e:
    print(f"✗ Scikit-learn import failed: {e}")

print("\nCreating a simple DataFrame...")
try:
    df = pd.DataFrame({'A': [1, 2, 3], 'B': [4, 5, 6]})
    print("✓ DataFrame created successfully")
    print(df)
except Exception as e:
    print(f"✗ DataFrame creation failed: {e}")
