using CsvHelper.Configuration.Attributes;


namespace BookSorter
{
    // This class represents the books shown in the input file with their details
    public class BookModel
    {
        [Index(0)] // Mapping the fields of the CSV files to indexes
        public string? Name { get; set; } 

        [Index(1)]
        public string? Title { get; set; } 

        [Index(2)]
        public string? Place { get; set; } 

        [Index(3)]
        public string? Publisher { get; set; } 

        [Index(4)]
        public string? Date { get; set; }
        [Index(5)]
        public string? ID { get; set; } // Unique ID generated for the books
    }
}
