# Quick test to verify everything works
import pandas as pd
import numpy as np
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder
from sklearn.metrics import r2_score
import warnings
warnings.filterwarnings('ignore')

print("QUICK TRAINING TEST")
print("="*40)

# Load data
df = pd.read_csv('data/comprehensive_school_data.csv')
print(f"Data: {len(df)} schools")

# Simple prep
X = df.drop(['School_ID', 'Overall_School_Quality_Score'], axis=1)
y = df['Overall_School_Quality_Score']

# Handle categoricals
for col in X.select_dtypes('object').columns:
    X[col] = LabelEncoder().fit_transform(X[col])

# Split and scale
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
X_train_scaled = StandardScaler().fit_transform(X_train)
X_test_scaled = StandardScaler().fit_transform(X_test)

# Quick train
rf = RandomForestRegressor(n_estimators=50, random_state=42)
rf.fit(X_train_scaled, y_train)
pred = rf.predict(X_test_scaled)
r2 = r2_score(y_test, pred)

print(f"R² Score: {r2:.4f}")
print(f"Status: {'SUCCESS' if not np.isnan(r2) else 'FAILED'}")
print("="*40)
