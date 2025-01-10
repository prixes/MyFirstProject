

using MyApp.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        //First
        //string jsonSimple = "{ 'name': 'John', 'age': 30 }";
        //var person = JsonConvert.DeserializeObject<Person>(jsonSimple);

        //Console.WriteLine(person.Name); // Output: John

        //Second
        //string json = @"
        //{
        //    'employees': [
        //        { 'name': 'Alice', 'age': 25 },
        //        { 'name': 'Bob', 'age': 30 }
        //    ]
        //}";
        ////string json = @"[1,2,3]"; // --- TEST for JObject

        //JObject jsonObject = JObject.Parse(json);
        ////string name = (string)jsonObject.SelectToken("$.employees[1].name");

        //var older = jsonObject.SelectToken("$.employees[?(@.age > 27)]");

        //Console.WriteLine($"{older["name"]} {older["age"]}"); // Output: Bob
        ////Console.WriteLine(name); // Output: Bob


        var jsonData = @"
        {
            'data': {
                        'items': [
                            { 'id': 1, 'value': 'A' },
                            { 'id': 2, 'value': 'B' }
                        ]
            }
        }
        }";

        JObject parsedData = JObject.Parse(jsonData);
        var requireData = (string)parsedData.SelectToken("$.data.items[1].value");
        Console.WriteLine(requireData);
        

        //string jsonBody = "{ 'name': 'John', 'skills': ['C#', 'JavaScript'] }";
        //JToken token = JToken.Parse(jsonBody);



        //Console.WriteLine(token["name"]); // Output: John

        ////Third
        //string jsonUser = @"
        //{
        //    'user_id': 1,
        //    'full_name': 'John Doe',
        //    'email_address': 'john.doe@example.com'
        //}";

        //User user = JsonConvert.DeserializeObject<User>(jsonUser);

        //Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}");




        //var older = jsonObject.SelectToken("$.employees[?(@.age > 27)]");
        //Console.WriteLine($"{older["name"]} {older["age"]}"); // Output: Bob
    }

}
