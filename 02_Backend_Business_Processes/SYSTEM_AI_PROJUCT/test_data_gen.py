import sys
import os
sys.path.append('src')
from data_generator import generate_school_data, save_data, display_sample

# Generate data
school_data = generate_school_data(num_schools=500)

# Display sample
display_sample(school_data)

# Save data
save_data(school_data)
