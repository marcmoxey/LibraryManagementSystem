using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class LibraryLogic
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to The Library");
            Console.WriteLine("***********************\n");
        }

        public static Dictionary<string, string> CreateLibraryStock()
        {
            return new Dictionary<string, string>
            {
                { "100 Leads", "in" },
                { "100 Offers", "out" },
                { "Rich Dad Poor Dad", "in" }
            };
        }

        public static void DisplayAvailableBooks(Dictionary<string, string> books)
        {
            Console.WriteLine("\nHere are the books we have:\n");

            bool found = false;
            foreach (var book in books)
            {
                string status = book.Value == "in" ? "Available" : "Currently Borrowed";
                Console.WriteLine($"{book.Key} - {status}");

                if (book.Value == "in") found = true;
            }

            if (!found)
            {
                Console.WriteLine("No books are currently available.");
            }
        }

        public static string SearchForBookTitles(Dictionary<string, string> books)
        {
            Console.Write("\nEnter the book title you are searching for: ");
            string searchTitle = Console.ReadLine().Trim();

            if (books.ContainsKey(searchTitle))
            {
                string status = books[searchTitle] == "in" ? "Available" : "Currently Borrowed";
                Console.WriteLine($"{searchTitle} is found - {status}");
            }
            else
            {
                Console.WriteLine($"{searchTitle} was not found in our library.");
            }
            return searchTitle;
        }

        public static string BorrowBook(Dictionary<string, string> books)
        {
            Console.Write("\nEnter the title of the book you want to borrow: ");
            string bookTitle = Console.ReadLine().Trim();

            if (books.ContainsKey(bookTitle))
            {
                if (books[bookTitle] == "out")
                {
                    Console.WriteLine($"Sorry, {bookTitle} is already borrowed.");
                }
                else
                {
                    books[bookTitle] = "out";
                    Console.WriteLine($"You have borrowed {bookTitle}.");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, {bookTitle} is not in our library.");
            }

            return bookTitle;
        }

        public static string ReturnBook(Dictionary<string, string> books)
        {
            Console.Write("\nEnter the title of the book you want to return: ");
            string bookTitle = Console.ReadLine().Trim();

            if (books.ContainsKey(bookTitle) && books[bookTitle] == "out")
            {
                books[bookTitle] = "in";  // Fixed incorrect dictionary update
                Console.WriteLine($"You returned {bookTitle}. Thank you!");
            }
            else
            {
                Console.WriteLine($"Invalid return. {bookTitle} is either not in our library or was not borrowed.");
            }

            return bookTitle;
        }

        public static void CheckoutBook(Dictionary<string, string> books)
        {
            Console.Write("\nWould you like to (search / borrow / return) a book? ");
            string userInput = Console.ReadLine().Trim().ToLower();

            switch (userInput)
            {
                case "borrow":
                    BorrowBook(books);
                    break;
                case "return":
                    ReturnBook(books);
                    break;
                case "search":
                    SearchForBookTitles(books);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose 'search', 'borrow', or 'return'.");
                    break;
            }
        }
    }
}
