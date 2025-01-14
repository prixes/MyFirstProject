using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MyApp.Logger;
string json = @"
{
    ""users"": [
        { ""id"": 1, ""name"": ""Alice"", ""age"": 25 },
        { ""id"": 2, ""name"": ""Bob"", ""age"": 30 }
    ]
}
";




// **** File Management ****
string content = File.ReadAllText("data.json");
Console.WriteLine(content);
File.WriteAllText("output.json", content);


File.Delete("output.json");

//****Combine File / Json manipulation operations ****
// Read JSON
//string fileContent = File.ReadAllText("data.json");
//JObject jsonContent = JObject.Parse(fileContent);

//// Manipulate JSON
//jsonContent["newKey"] = "newValue";
//jsonContent.Add("newKey2", "newValue");

//// Write back to file
//Console.WriteLine(jsonContent);
//File.WriteAllText("output.json", jsonContent.ToString());


// **** Read Token by Token -- Large file operations ****
//using (StreamReader file = File.OpenText("data.json"))
//{
//    using (JsonTextReader reader = new JsonTextReader(file))
//    {
//        while (reader.Read())
//        {
//            Console.WriteLine(reader.TokenType + " - " + reader.Value);
//        }
//    }
//}
//****JArray Example ****
//string jsonArray = @"
//[
//  { ""id"": 1, ""product"": ""Laptop"", ""price"": 1200 },
//  { ""id"": 2, ""product"": ""Tablet"", ""price"": 800 }
//]
//";

//JArray array = JArray.Parse(jsonArray);
//array.Add(new JObject { ["id"] = 3, ["product"] = "Phone", ["price"] = 600 });
//array[1]["price"] = 850;
//array[0].Remove();
//File.WriteAllText("products.json", array.ToString());

// **** Logger example ****
//var logger = new JsonLogger("logs.json");

// Add logs
//logger.AddLog("Application started.");
//logger.AddLog("User logged in.");
//logger.AddLog("Error: Invalid input.");
//await Task.Delay(2000);
//logger.AddLog("System shutting down.");

//// Read last 2 logs
//var lastLogs = logger.GetLastNLogs(2);
//Console.WriteLine("Last 2 logs:");
//foreach (var log in lastLogs)
//{
//    Console.WriteLine(log);
//}

// *** Open the file for appending ***
//string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//string newLogEntry = $"{{" +
//    $" \"timestamp\": \"{timestamp}\", " +
//    $"\"message\": \"Testing append!\" " +
//    $"}}";

//using (var stream = new FileStream("logs.json", FileMode.Open, FileAccess.Write))
//{
//    using (var writer = new StreamWriter(stream, Encoding.UTF8))
//    {
//        // Seek to the position before the closing ']' in json
//        stream.Seek(-1, SeekOrigin.End);

//        // Check if the file contains more than just "[]"
//        if (stream.Position > 1)
//        {
//            writer.Write(","); // Add a comma if the array is not empty
//        }

//        // Append the new object and close the JSON array
//        writer.Write(newLogEntry);
//        writer.Write("]");
//    }
//}


// **** Generate a list of JSON objects ****
//int elementCount = 250;

//var items = new List<Dictionary<string, object>>();
//for (int i = 1; i <= elementCount; i++)
//{
//    var item = new Dictionary<string, object>
//            {
//                { "id", i },
//                { "name", $"Item{i}" },
//                { "price", Math.Round(new Random().NextDouble() * 100, 2) },
//                { "inStock", i % 2 == 0 } // Alternate inStock status
//            };
//    items.Add(item);
//}

//// Serialize the list to a JSON string
//string jsonBig = JsonConvert.SerializeObject(items, Formatting.Indented);

//// Save the JSON string to a file
//File.WriteAllText("large.json", jsonBig);


/// **** File Splitter
//string inputFilePath = "large.json"; // Input file containing the large JSON array
//string outputDirectory = "output";  // Directory to store split files
//int batchSize = 100;                // Number of elements per file

//// Ensure output directory exists
//Directory.CreateDirectory(outputDirectory);

//// Read and parse the large JSON array
//var jsonArray = JArray.Parse(File.ReadAllText(inputFilePath));

//int totalParts = (int)Math.Ceiling(jsonArray.Count / (double)batchSize);
//for (int i = 0; i < totalParts; i++)
//{
//    var part = new JArray();

//    // Get elements for the current part
//    for (int j = i * batchSize; j < Math.Min((i + 1) * batchSize, jsonArray.Count); j++)
//    {
//        part.Add(jsonArray[j]);
//    }

//    // Write the current part to a file
//    string partFileName = Path.Combine(outputDirectory, $"part{i + 1}.json");
//    File.WriteAllText(partFileName, part.ToString());

//    Console.WriteLine($"Created: {partFileName}");
//}

//Console.WriteLine($"Splitting completed. Total parts: {totalParts}");
//File.Delete(inputFilePath);
//Console.WriteLine($"Deleted large file: {inputFilePath}");


// *** Read configuration ***
//--Need all these dependencies installed in order to work
//--using Microsoft.Extensions.Configuration;
//--using Microsoft.Extensions.Configuration.Json;
//--using Microsoft.Extensions.Configuration.EnvironmentVariables;
//var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
//    .AddJsonFile("appsettings.json")
//    .AddEnvironmentVariables();

//var configuration = builder.Build();

//string connectionString = configuration["ConnectionStrings:DefaultConnection"];
//Console.WriteLine(connectionString);

//// Win search >> Edit the system enviroment variables >> add >> MyEnvVar = MyValue
//string envValue = Environment.GetEnvironmentVariable("MyEnvVar", EnvironmentVariableTarget.Machine);
//Console.WriteLine($"Environment Variable Value: {envValue}");