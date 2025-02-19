

using LibraryManagementSystem;

// WelcomeMessage
LibraryLogic.WelcomeMessage();

// CreateLibraryStock
Dictionary<string, string> books = LibraryLogic.CreateLibraryStock();

do
{
    // DisplayAvailableBooks
    LibraryLogic.DisplayAvailableBooks(books);

    LibraryLogic.CheckoutBook(books);

} while (books.Values.Contains("in")); // Loop until all books are borrowed











