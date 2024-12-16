using MyApp.Abstractions;
using MyApp.Implementations;

public class Program
{
    public static void Main()
    {
        decimal g = 10;
        int i = (int)10d;

        List<Employee> employees = new List<Employee>
        {
            new HourlyEmployee("David", 12, 100),
            new HourlyEmployee("Georgi", 321, 12),
            new SalariedEmployee("Ivan", 13)
        };

        ((HourlyEmployee)employees[0]).Pay();
        ((HourlyEmployee)employees[1]).Pay();
        ((SalariedEmployee)employees[2]).Pay();
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;

//// Interface
//public interface IBorrowable
//{
//    void Borrow(string borrower, DateTime dueDate);
//    void Return();
//}

//// Abstract Class
//public abstract class LibraryItem : IBorrowable
//{
//    public string Title { get; set; }
//    public bool IsBorrowed { get; private set; }
//    public string Borrower { get; private set; }
//    public DateTime DueDate { get; private set; }

//    public void Borrow(string borrower, DateTime dueDate)
//    {
//        if (IsBorrowed)
//        {
//            Console.WriteLine($"'{Title}' is already borrowed.");
//            return;
//        }

//        Borrower = borrower;
//        DueDate = dueDate;
//        IsBorrowed = true;
//        OnBorrow();
//    }

//    public void Return()
//    {
//        if (!IsBorrowed)
//        {
//            Console.WriteLine($"'{Title}' is not borrowed.");
//            return;
//        }

//        Borrower = null;
//        DueDate = default;
//        IsBorrowed = false;
//        Console.WriteLine($"'{Title}' has been returned.");
//    }

//    public void CheckStatus()
//    {
//        if (IsBorrowed)
//        {
//            Console.WriteLine($"Title: {Title}, Borrowed by {Borrower}, Due on {DueDate:yyyy-MM-dd}");
//        }
//        else
//        {
//            Console.WriteLine($"Title: {Title}, Available for borrowing.");
//        }
//    }

//    public void ExtendDueDate(int days)
//    {
//        if (IsBorrowed)
//        {
//            DueDate = DueDate.AddDays(days);
//            Console.WriteLine($"Due date for '{Title}' has been extended to {DueDate:yyyy-MM-dd}.");
//        }
//        else
//        {
//            Console.WriteLine($"'{Title}' is not borrowed, cannot extend due date.");
//        }
//    }

//    protected abstract void OnBorrow();
//}

//// Concrete Class: Book
//public class Book : LibraryItem
//{
//    public string Author { get; set; }

//    protected override void OnBorrow()
//    {
//        Console.WriteLine($"Book '{Title}' by {Author} borrowed by {Borrower}, due on {DueDate:yyyy-MM-dd}.");
//    }
//}

//// Concrete Class: Magazine
//public class Magazine : LibraryItem
//{
//    public int IssueNumber { get; set; }

//    protected override void OnBorrow()
//    {
//        Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) borrowed by {Borrower}, due on {DueDate:yyyy-MM-dd}.");
//    }
//}

//// Main Program
//public class LibraryManagementSystem
//{
//    private List<LibraryItem> items = new List<LibraryItem>();
//    private Dictionary<string, int> borrowerLimits = new Dictionary<string, int>();
//    private const int BorrowingLimit = 3;

//    public void AddItem(LibraryItem item)
//    {
//        items.Add(item);
//    }

//    public void BorrowItem(string title, string borrower, DateTime dueDate)
//    {
//        var item = items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

//        if (item == null)
//        {
//            Console.WriteLine($"Item '{title}' not found.");
//            return;
//        }

//        if (!borrowerLimits.ContainsKey(borrower))
//        {
//            borrowerLimits[borrower] = 0;
//        }

//        if (borrowerLimits[borrower] >= BorrowingLimit)
//        {
//            Console.WriteLine($"Borrower '{borrower}' has reached the borrowing limit of {BorrowingLimit} items.");
//            return;
//        }

//        item.Borrow(borrower, dueDate);
//        if (item.IsBorrowed)
//        {
//            borrowerLimits[borrower]++;
//        }
//    }

//    public void ReturnItem(string title)
//    {
//        var item = items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

//        if (item == null)
//        {
//            Console.WriteLine($"Item '{title}' not found.");
//            return;
//        }

//        if (item.IsBorrowed)
//        {
//            borrowerLimits[item.Borrower]--;
//            item.Return();
//        }
//    }

//    public void DisplayStatus()
//    {
//        foreach (var item in items)
//        {
//            item.CheckStatus();
//            if (item.IsBorrowed && DateTime.Now > item.DueDate)
//            {
//                Console.WriteLine($"Warning: '{item.Title}' is overdue!");
//            }
//        }
//    }

//    public static void Main(string[] args)
//    {
//        var library = new LibraryManagementSystem();

//        // Adding items
//        library.AddItem(new Book { Title = "C# Programming", Author = "John Doe" });
//        library.AddItem(new Book { Title = "Design Patterns", Author = "Jane Smith" });
//        library.AddItem(new Magazine { Title = "Tech Today", IssueNumber = 42 });
//        library.AddItem(new Magazine { Title = "Science Monthly", IssueNumber = 15 });

//        // Borrowing items
//        library.BorrowItem("C# Programming", "Alice", DateTime.Now.AddDays(7));
//        library.BorrowItem("Tech Today", "Alice", DateTime.Now.AddDays(7));
//        library.BorrowItem("Design Patterns", "Alice", DateTime.Now.AddDays(7));
//        library.BorrowItem("Science Monthly", "Alice", DateTime.Now.AddDays(7)); // Exceeds borrowing limit

//        // Display status
//        Console.WriteLine("\nLibrary Status:");
//        library.DisplayStatus();

//        // Returning items
//        library.ReturnItem("C# Programming");

//        // Display status
//        Console.WriteLine("\nLibrary Status After Return:");
//        library.DisplayStatus();
//    }
//}



