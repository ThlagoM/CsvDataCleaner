using System.Net.Mail;

namespace CsvDataCleaner;

public class CsvProcessor
{
    public void Process(string inputPath)
    {
        string[] lines = File.ReadAllLines(inputPath);

        if (lines.Length == 0)
        {
            Console.WriteLine("Error: The CSV file is empty.");
            return;
        }

        if (lines.Length == 1)
        {
            Console.WriteLine("No customer records found.");
            return;
        }

        List<string> cleanRows = new() { lines[0] };
        List<string> reportRows = new() { "Row,Reason" };

        HashSet<string> processedEmails =
            new(StringComparer.OrdinalIgnoreCase);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] columns = lines[i].Split(',');

            if (columns.Length != 3)
            {
                reportRows.Add($"{i},Invalid column count");
                continue;
            }

            string name = columns[1].Trim();
            string email = columns[2].Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                reportRows.Add($"{i},Missing name");
            }
            else if (!MailAddress.TryCreate(email, out var parsedEmail)
                     || parsedEmail.Address != email
                     || !email.Contains('.'))
            {
                reportRows.Add($"{i},Invalid email");
            }
            else if (!processedEmails.Add(email))
            {
                reportRows.Add($"{i},Duplicate email");
            }
            else
            {
                cleanRows.Add(string.Join(",", columns.Select(c => c.Trim())));
            }
        }

        File.WriteAllLines("clean_customers.csv", cleanRows);
        File.WriteAllLines("validation_report.csv", reportRows);

        Console.WriteLine($"Clean records: {cleanRows.Count - 1}");
        Console.WriteLine($"Rejected records: {reportRows.Count - 1}");
        Console.WriteLine("Files generated successfully!");
    }
}