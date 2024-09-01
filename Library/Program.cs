using System;
using System.Collections.Generic;

namespace LibrarySystem
{
     // Declare the program class to run console appication interface
    class Program
    {
        //Difine the main method
        static void Main(string[] args)
        {
            //Create new book object fro the book class
            List<Book> library = new List<Book>();
            bool running = true;
            //Whie loop use for appication main menu run in loop
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Library System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search Book by Title");
                Console.WriteLine("3. Display All Books");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");
                //get user choice 
                string choice = Console.ReadLine();
                //switch case use to seected option when user choice
                switch (choice)
                {
                    case "1":
                        AddBook(library);
                        break;
                    case "2":
                        SearchBookByTitle(library);
                        break;
                    case "3":
                        DisplayAllBooks(library);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
        //adding new book
        static void AddBook(List<Book> library)
        { 
            Console.Clear();
             // Prompt the user to enter the book details
            Console.Write("Enter book title: ");
            string title = Console.ReadLine() ?? "Default Title";

            Console.Write("Enter book author: ");
            string author = Console.ReadLine() ?? "Default Author";

            Console.Write("Enter book ISBN: ");
            string isbn = Console.ReadLine() ?? "0000000000000";

            Console.Write("Enter publication date: ");
            int yearPublished;
            //Check date in integer format
            while (!int.TryParse(Console.ReadLine(), out yearPublished))
            {
                Console.Write("Invalid input. Enter a valid Year Published: ");
            }
//assign new values to book object
            Book newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                YearPublished = yearPublished
            };

            library.Add(newBook);

            Console.WriteLine("Book Saved!");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        
        
      
        }
//search book by titile
        static void SearchBookByTitle(List<Book> library)
        {
            Console.Clear();
            Console.WriteLine("Search for a Book by Title");
             // Prompt the user to enter the book details to search
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Book foundBook = library.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            //dispay details for the found book
            if (foundBook != null)
            {
                Console.WriteLine("\nBook Found:");
                Console.WriteLine($"Title: {foundBook.Title}");
                Console.WriteLine($"Author: {foundBook.Author}");
                Console.WriteLine($"ISBN: {foundBook.ISBN}");
                Console.WriteLine($"Year Published: {foundBook.YearPublished}");
            }
            // if no book found display error message
            else
            {
                Console.WriteLine("Book not found.");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
//Dispay list of all available books
        static void DisplayAllBooks(List<Book> library)
        {
            Console.Clear();
            Console.WriteLine("All Books in the Library:");

            if (library.Count > 0)
            {
                foreach (var book in library)
                {
                    Console.WriteLine($"\nTitle: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"ISBN: {book.ISBN}");
                    Console.WriteLine($"Year Published: {book.YearPublished}");
                }
            }
            else
            {
                Console.WriteLine("No books in the library.");
            }

            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }
    }
// Difine book calss with there proporties
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublished { get; set; }
    }
}
