using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BookSorter
{
    class Program
    {
        static void Main()
        {
            // Path to the existing CSV file
            string existingCsvPath = @"CSVFiles\U16A2Task2Data.csv";
            // Path to the new CSV file
            string newCsvPath = @"CSVFiles\New_TaskData";

            try
            {
                // Configuration for CsvHelper to handle Csv parsing
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null, // Disable header validation
                    MissingFieldFound = null, // Disable missing field detection
                };

                // Read the existing CSV file
                using var reader = new StreamReader(existingCsvPath);
                using var csvIn = new CsvReader(reader, config);
                {
                    // Get the book records from the existing CSV file
                    var books = csvIn.GetRecords<BookModel>();
                    SerialNumberGenerator serialNumberGenerator = new();

                    // Write to the new CSV file
                    using var writer = new StreamWriter(newCsvPath);
                    using var CsvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    {
                        // Write a header to the new CSV file based on the properties of the BookModel class
                        CsvOut.WriteHeader<BookModel>();
                        CsvOut.NextRecord();

                        // Process each book and generate a unique serial number
                        foreach (var book in books)
                        {
                            book.ID = serialNumberGenerator.GenerateSerialNumber(book);
                            // Write the book record to the new CSV file
                            CsvOut.WriteRecord(book);
                            CsvOut.NextRecord();
                        }
                    }
                }
                // Inform the user that the process is complete
                Console.WriteLine("Book data has been sorted and written to new CSV file.");
            }
            catch (FileNotFoundException)
            {
                // Handle the case where the file is not found
                Console.WriteLine("Could not find file.");
            }
            catch (CsvHelperException)
            {
                // Handle errors from CsvHelper
                Console.WriteLine("Error occured in CsvHelper.");
            }
            catch (Exception)
            {
                // Handle any other errors
                Console.WriteLine("Error occured.");
            }
        }
    }
}