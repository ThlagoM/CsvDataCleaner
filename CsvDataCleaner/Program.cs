using CsvDataCleaner;

Console.WriteLine("=== CSV Data Cleaner & Validator ===");

string filePath = "customers.csv";

if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found: {filePath}");
    return;
}

CsvProcessor processor = new();
processor.Process(filePath);