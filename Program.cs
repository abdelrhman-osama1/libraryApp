
class Program
{

    static void Main()
    {
        Library MyLibrary = new Library();
        while (true)
        {
            Console.WriteLine("Type Search or 'Borrow'if you want to borrow a book or'return' to return a book or 'exit' to close ");
            string? Input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Input))
            {
                Console.WriteLine("Invalid answer");
            }
            switch (Input?.ToLower())
            {
                case "search":
                    MyLibrary.SearchBook();
                    break;
                case "borrow":
                    MyLibrary.BorrowBook();
                    break;
                case "return":
                    MyLibrary.ReturnBooks();
                    break;
                case "exit":
                    return;
            }
        }
    }
}

class Library
{
    List<Book> books = new List<Book>();
    public int borrowedCount = 0;
    public Library()
    {
        books.Add(new Book("arabic", false));
        books.Add(new Book("English", false));
        books.Add(new Book("Math", false));
        books.Add(new Book("History", false));
        books.Add(new Book("Computer", false));
    }
    public void SearchBook()
    {
        Console.WriteLine("Enter book title to search");
        string? searchTitle = Console.ReadLine();
        bool found = false;
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Title?.ToLower() == searchTitle?.ToLower())
            {
                found = true;
                Console.WriteLine("The book is available in the collection");
                break;
            }
        }
        if (found == false)
        {
            Console.WriteLine("The book is not in the collection");
        }
    }
    public void BorrowBook()
    {
        if (borrowedCount < 3)
        {
            Console.WriteLine("Enter book u want to borrow");
            string? Borrow = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title?.ToLower() == Borrow?.ToLower())
                {
                    found = true;
                    if (books[i].IsChecked == false)
                    {
                        books[i].IsChecked = true;
                        borrowedCount += 1;
                        Console.WriteLine("book added successfully ");
                    }
                    else
                    {
                        Console.WriteLine("The book is already Borrowed");
                    }
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("The book is not in the collection");
            }

        }
        else
        {
            Console.WriteLine("sorry. you have reached the borrowing limit of 3 books");
        }
    }
    public void ReturnBooks()
    {
        if (borrowedCount > 0)
        {
            Console.WriteLine("Enter book u want to Return");
            string? Return = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title?.ToLower() == Return?.ToLower())
                {
                    found = true;
                    if (books[i].IsChecked == true)
                    {
                        books[i].IsChecked = false;
                        borrowedCount -= 1;
                        Console.WriteLine("book Returned successfully ");
                    }
                    else
                    {
                        Console.WriteLine("you didn't borrow this book");
                    }
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("The book is not in the collection");
            }

        }
        else
        {
            Console.WriteLine("you don't have any borrowed books");
        }
    }
}
class Book
{
    public string Title { get; set; }
    public bool IsChecked { get; set; }
    public Book(string BookTitle, bool IsCheckedOut)
    {
        Title = BookTitle;
        IsChecked = IsCheckedOut;
    }
}
