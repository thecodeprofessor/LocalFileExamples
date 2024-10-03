namespace LocalFileExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }

        public static class SimulatedData
        {
            public static void GenerateFiles(string storesPath)
            {
                // Create directories for stores 201 and 202
                var store201Directory = Path.Combine(storesPath, "201");
                var store202Directory = Path.Combine(storesPath, "202");

                // Create directories if they don't exist
                Directory.CreateDirectory(store201Directory);
                Directory.CreateDirectory(store202Directory);

                // Files to create in each store's directory
                var filesIn201 = new string[]
                {
                "inventory-report-201.txt",
                "sales-summary-201.json",
                "customer-data-201.csv",
                "supplier-info-201.xml",
                "monthly-expenses-201.xlsx"
                };

                var filesIn202 = new string[]
                {
                "inventory-report-202.txt",
                "sales-summary-202.json",
                "customer-data-202.csv",
                "supplier-info-202.xml",
                "monthly-expenses-202.xlsx"
                };

                // Create and populate files in store 201 directory
                foreach (var file in filesIn201)
                {
                    var filePath = Path.Combine(store201Directory, file);
                    PopulateFileWithData(filePath);
                }

                // Create and populate files in store 202 directory
                foreach (var file in filesIn202)
                {
                    var filePath = Path.Combine(store202Directory, file);
                    PopulateFileWithData(filePath);
                }
            }

            private static void PopulateFileWithData(string filePath)
            {
                // Get file extension to determine file type
                var extension = Path.GetExtension(filePath).ToLower();

                switch (extension)
                {
                    case ".txt":
                        File.WriteAllLines(filePath, GenerateTextData());
                        break;
                    case ".json":
                        File.WriteAllText(filePath, GenerateJsonData());
                        break;
                    case ".csv":
                        File.WriteAllLines(filePath, GenerateCsvData());
                        break;
                    case ".xml":
                        File.WriteAllText(filePath, GenerateXmlData());
                        break;
                    case ".xlsx":
                        File.WriteAllLines(filePath, GenerateSpreadsheetData());
                        break;
                    default:
                        File.WriteAllLines(filePath, GenerateTextData());
                        break;
                }
            }

            private static string[] GenerateTextData()
            {
                return new string[]
                {
                "Store Inventory Report",
                "Date: " + DateTime.Now.ToString("yyyy-MM-dd"),
                "Total Items: 150",
                "Total Value: $45,000",
                "Prepared by: Manager"
                };
            }

            private static string GenerateJsonData()
            {
                return @"
            {
                ""date"": """ + DateTime.Now.ToString("yyyy-MM-dd") + @""",
                ""total_sales"": 23000,
                ""total_customers"": 200,
                ""top_selling_product"": ""Laptop"",
                ""top_selling_quantity"": 50
            }";
            }

            private static string[] GenerateCsvData()
            {
                return new string[]
                {
                "CustomerID,Name,Email,PurchaseAmount", // CSV header
                "1,John Doe,john.doe@example.com,150.00",
                "2,Jane Smith,jane.smith@example.com,200.50",
                "3,Robert Johnson,robert.johnson@example.com,175.75",
                "4,Emily Davis,emily.davis@example.com,300.00",
                "5,Michael Brown,michael.brown@example.com,250.00"
                };
            }

            private static string GenerateXmlData()
            {
                return @"
            <Suppliers>
                <Supplier>
                    <Name>Supplier A</Name>
                    <Contact>Email: supplierA@example.com</Contact>
                    <TotalOrders>120</TotalOrders>
                </Supplier>
                <Supplier>
                    <Name>Supplier B</Name>
                    <Contact>Email: supplierB@example.com</Contact>
                    <TotalOrders>80</TotalOrders>
                </Supplier>
            </Suppliers>";
            }

            private static string[] GenerateSpreadsheetData()
            {
                return new string[]
                {
                "Month,Expenses",
                "January,5000",
                "February,4500",
                "March,5200",
                "April,4700",
                "May,5100"
                };
            }
        }
    }
}
