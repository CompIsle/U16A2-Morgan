using System.Security.Cryptography;
using System.Text;


namespace BookSorter
{
    // Interface for generating serial numbers
    public interface ISerialNumberGenerator
    {
        string GenerateSerialNumber(BookModel book);
    }

    // Implementation of the serial number generator using SHA256
    public class SerialNumberGenerator : ISerialNumberGenerator
    {
        public string GenerateSerialNumber(BookModel book)
        {
            // Concatenate book details into a single string
            String toconvert = $"{book.Name}{book.Title}{book.Place}{book.Publisher}{book.Date}";
            using (var hashAlgorithm = SHA256.Create())
            {
                // Compute the hash of the concatenated string
                byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(toconvert));
                var sBuilder = new StringBuilder();
                // Convert the byte array to a hexadecimal string
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                var serialNumber = sBuilder.ToString();
                // Return the hexadecimal string as the serial number
                return serialNumber;

                //based on microsoft documentation https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=netcore-3.1#System_Security_Cryptography_HashAlgorithm_ComputeHash_System_Byte___
            }
        }
    }
}
