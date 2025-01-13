using MyApp;
using Microsoft.SqlServer.Server;
using Microsoft.Data.SqlClient;
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {


        // 1) ***DB connection example***
        //string connectionString = "connectionstring";
        //var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
        //connection.Open();
        //Console.WriteLine("Connected to the database.");
        //List<Employee> listOfEmployees = new List<Employee>();

        //string query = "SELECT * FROM Users";
        //using (var command = new SqlCommand(query, connection))
        //{
        //    using (var reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            Employee currentEmployee = new Employee();
        //            currentEmployee.Name = $"{reader["FirstName"]} {reader["LastName"]}";
        //            listOfEmployees.Add(currentEmployee);
        //        }
        //    }
        //}
        //listOfEmployees.
        //    ForEach(x => Console.WriteLine(x.Name));

        // 2) ***Mocked repository***
        var mockRepository = new Mock<IEmployeeRepository>();
        mockRepository
            .Setup(repo => repo.GetEmployeeById(9))
            .Returns(new Employee { Id = 1, Name = "XXX" });

        var service = new EmployeeService(mockRepository.Object);
        var result = service.GetEmployeeDetails(9);
        Console.WriteLine($"Employee Name: {result.Name}");
        Assert.That(result.Name, Is.EqualTo("John"));



        //3) ***Real repository***
        //var repository = new EmployeeRepository();
        // var service = new EmployeeService(repository);
        // var result = service.GetEmployeeDetails(5);

        // Assert.That(result.Name, Is.EqualTo("John"));



        //4) ***Dependency injection with service provider ***
        //var serviceProvider = new ServiceCollection()
        //    .AddSingleton<IEmployeeRepository, EmployeeRepository>()
        //    .AddTransient<EmployeeService>()
        //    .BuildServiceProvider();

        //var service = serviceProvider.GetService<EmployeeService>();

        //var result = service.GetEmployeeDetails(9);

        //Console.WriteLine($"Employee Name: {result.Name}");
        //Assert.That(result.Name, Is.EqualTo("John"));


        // 5) *** Usage of dependency injection: ***
        //IMessageService service = new EmailService();
        //Notification notification = new Notification(service);
        //notification.Notify("Hello, World!");


        //6)  ***Singleton example***
        //Singleton instance1 = Singleton.Instance;
        //instance1.ShowMessage("Hello, Singleton!");

        //Singleton instance2 = Singleton.Instance;
        //instance2.ShowMessage("This is the same instance.");

        //Console.WriteLine(ReferenceEquals(instance1, instance2)); 
        //// Output: True
    }
}

public interface IEmployeeRepository
{
    Employee GetEmployeeById(int v);
}
public class EmployeeRepository : IEmployeeRepository
{
    public Employee GetEmployeeById(int v)
    {

        string connectionString = "connectionString";
        var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Connected to the database.");

        string query = $"SELECT * FROM Users Where id={v}";
        using (var command = new SqlCommand(query, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Employee() { Id = v, Name = $"{reader["FirstName"]}{reader["LastName"]}" };
                }
            }

        }
        connection.Close();
        throw new Exception("User not found!");
    }
}
public class EmployeeService
{
    private IEmployeeRepository employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }
    public Employee GetEmployeeDetails(int id)
    {
        return employeeRepository.GetEmployeeById(id);
    }
}



public interface IMessageService
{
    void SendMessage(string message);
}
public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}
public class Notification
{
    private readonly IMessageService _messageService;
    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }
    public void Notify(string message)
    {
        _messageService.SendMessage(message);
    }
}




public class Singleton
{
    private static Singleton _instance;
    private Singleton()
    {
        Console.WriteLine("Singleton instance created.");
    }
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine($"Message from Singleton: {message}");
    }
}

