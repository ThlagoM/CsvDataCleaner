# CSV Data Cleaner & Validator

A lightweight .NET 8 console application that validates customer CSV data, detects duplicate email addresses, and exports cleaned records and a validation report.

## Features
- Reads customer data from a CSV file
- Validates missing names and email address formats
- Detects duplicate emails (case-insensitive)
- Exports valid records to `clean_customers.csv`
- Exports rejected records to `validation_report.csv`
- Handles empty input files

## Technologies
- C#
- .NET 8
- File I/O
- HashSet for duplicate detection

## Getting Started
1. Open the solution in Visual Studio 2022.
2. Build the project.
3. Run the application.
4. Check the generated CSV files in the application's working directory.

## Sample Input
```csv
Id,Name,Email
1,Ana Silva,ana@example.com
2,Bruno Costa,bruno@example.com
3,Ana Silva,ana@example.com
4,Carlos Santos,invalid-email
5,,maria@example.com
```

## Expected Results
- 2 valid customer records
- 3 rejected records

## Limitations
This demonstration uses basic comma splitting and does not support quoted CSV fields containing commas or multiline values. Email validation is basic and does not verify mailbox existence.

## Purpose
A portfolio demonstration of practical data validation, CSV processing, and workflow automation using C# and .NET.
