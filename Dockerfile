# Use the official Python image as the base image
FROM python:3.9

# Set the working directory inside the container
WORKDIR /app

# Copy all the files from the current directory into the container
COPY . /app/

# Install the Python dependencies from requirements.txt
RUN pip install --no-cache-dir -r requirements.txt

# Run the Python script
CMD ["python", "bills_calculator.py"]
