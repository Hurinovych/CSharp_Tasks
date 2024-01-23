using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library1 = new Library("Riverside City Library", "Riverside, California, USA", 5000);
            Book[] books = new Book[]
            {
                new Book("The Adventures of Tom Sawyer", "Mark Twain", 1878),
                new Book("Murder on the Orient Express", "Agatha Christie", 1934)
            };

            foreach (Book book in books)
            {
                book.PrintDetailsBook();
                library1.AddBook(book);
            }

            Console.Write("Do u wanna add book from user input? (Y/N):");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                int numberOfCreatedBooks;
                while (true)
                {
                    try
                    {
                        Console.Write("Enter numbers of books to create: ");
                        numberOfCreatedBooks = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Enter ONLY numbers PLEASE!");
                    }
                }

                for (int i = 0; i < numberOfCreatedBooks; i++)
                {
                    Book newBook = Book.CreateBook();
                    /*newBook.PrintDetailsBook();*/
                    library1.AddBook(newBook);
                }
            }
            library1.PrintDetailsLibrary();
        }
    class Book
        {
            string title;
            string author;
            int year;
            public Book(string title, string author, int year)
            {
                this.title = title;
                this.author = author;
                this.year = year;
            }
            public void PrintDetailsBook()
            {
                Console.WriteLine($"Title: {title}\nAuthor: {author}\nPublication Year: {year}\n");
            }
            public static Book CreateBook()
            {
                Console.WriteLine("Enter Book Details:");

                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Author: ");
                string author = Console.ReadLine();

                int year;
                while (true)
                {
                    try
                    {
                        Console.Write("Publication Year: ");
                        year = Convert.ToInt32(Console.ReadLine());
                        break; 
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Enter ONLY numbers PLEASE!");
                    }
                }

                return new Book(title, author, year);
            }
        }
    class Library
        {
            string name;
            string location;
            Book[] books;
            public Library(string name, string location, int number)
            {
                this.name = name;
                this.location = location;
                books = new Book[number];
            }
            public void AddBook(params Book[] newBooks)
            {
                foreach (Book newBook in newBooks)
                {
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (books[i] == null)
                        {
                            books[i] = newBook;
                            break;
                        }
                    }
                }
            }
            public void PrintDetailsLibrary()
            {
                Console.WriteLine($"\n--------------------------\n\nName: {name}\nLocation: {location}");

                foreach (Book book in books)
                {
                    if (book != null)
                    {
                        book.PrintDetailsBook();
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
