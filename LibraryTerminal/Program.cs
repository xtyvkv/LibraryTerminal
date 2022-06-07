/*
do
{ 
1.Display the entire list of books.  Format it nicely. // display method
  a.Display Book Number, Book Title, Author, Status and Due Date 
2.	Search for a book //search method
  a.	By Author
  b.	By Title keyword
3.	Select a Book from the list //select method
  a.	If not a valid book, display error and prompt user for another choice or display the list.
  b.   If it’s already checked out, let them know.
  c.   If not, check it out to them and set the due date to 2 weeks from today.
4.	Return a book (we can decide how that works/questions to ask) //return a book method
  a.Ask which book they want to return
  b.	If book isn’t checked out, give error
  c.	If book is checked out: 
          i.update status 
          ii.	clear out due date. 

5.	Exit – Hit enter to exit
) while (continueRunning = true) 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> libraryBooks = buildLibrary();
            bool continueRunning = true;

            Console.WriteLine("Welcome to the C Sharts Library!");

            while (continueRunning)
            {
                Console.WriteLine("Please Enter Your Selection:\n");
                Console.WriteLine("1. Display The List of Books");
                Console.WriteLine("2. Search by Title or Author");
                Console.WriteLine("3. Select a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("or hit 'enter' to quit.");
                string response = Console.ReadLine();

                if (response == "1")
                {
                    displayList(libraryBooks);
                }
                else if (response == "2")
                {
                    searchBook(libraryBooks);
                }
                else if (response == "3")
                {
                    displayList(libraryBooks);
                    selectBook(libraryBooks);
                }
                else if (response == "4")
                {
                    returnBook(libraryBooks);
                }
                else if (String.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Goodbye!");
                    continueRunning = false;
                    //return;
                }
            }
        }
        public static List<Book> buildLibrary()
        {
            var booksList = new List<Book>();
            Book newBook = null;

            newBook = new Book(1, "A Time to Kill", "John Grisham", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(2, "East of Eden", "John Steinbeck", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(3, "Number the Stars", "Lois Lowry", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(4, "The Fault in our Stars", "John Green", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(5, "Green Eggs and Ham", "Dr. Seuss", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(6, "In Cold Blood", "Truman Capote", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(7, "Band of Brothers", "Stephen E. Ambrose", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(8, "The Dark Tower", "Stephen King", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(9, "Charlottes Web", "E.B. White", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(10, "Gone with the Wind", "Margaret Mitchel", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(11, "The Grapes of Wrath", "John Steinbeck", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(12, "A Farewell to Arms", "Ernest Hemingway", false, new DateTime());
            booksList.Add(newBook);

            return booksList;
        }
        public class Book
        {
            //add book number 
            public int BookNum { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool CheckedOutStatus { get; set; }
            public DateTime? DueDate { get; set; }

            public Book(int newBookNum, string newTitle, string newAuthor, bool newStatus, DateTime newDate)
            {
                BookNum = newBookNum;
                Title = newTitle;
                Author = newAuthor;
                CheckedOutStatus = newStatus;
                DueDate = newDate;
            }
        }
        public static void displayList(List<Book> myBooks)
        {
            for (int i = 0; i < myBooks.Count; i++)
            {
                int bookNum = i + 1;
                string status;

                if (myBooks[i].CheckedOutStatus == true)
                {
                    status = "Not Available";
                    Console.WriteLine($"{bookNum}: \t {myBooks[i].Title} \t Author: {myBooks[i].Author} \tStatus: {status} \t Expected Return Date: {myBooks[i].DueDate:MM/dd/yyyy}");

                }
                else
                {
                    status = "Available";
                    Console.WriteLine($"{bookNum}: \t {myBooks[i].Title} \t Author: {myBooks[i].Author} \t Status: {status} ");

                }
            }
        }

        public static void searchBook(List<Book> myBooks)
        {
            // Lookup w/ keyword by Title or Author?
            Console.WriteLine("Would you like to search Titles or Authors?");
            string titlesOrAuthors = Console.ReadLine();
            if (titlesOrAuthors == "Titles")
            {
                Console.WriteLine("Enter a keyword to lookup a title:");
                string keyword = Console.ReadLine();
                List<Book> searchResult = myBooks.Where(Book => Book.Title.Contains(keyword)).ToList();
                if (searchResult.Count > 0)
                {
                    Console.WriteLine("Results found:");
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        var bookNum = i + 1;
                        Console.WriteLine($"{bookNum}: {searchResult[i].Title} {searchResult[i].Author} {searchResult[i].CheckedOutStatus} {searchResult[i].DueDate}");
                    }
                }
                else
                {
                    Console.WriteLine("No matches found. Here is a list of our available books:");
                    List<Book> libraryBooks = buildLibrary();
                    displayList(libraryBooks);
                    // select book to check out?
                    // probably better if it takes them back to the main menu
                }
            }
            else if (titlesOrAuthors == "Authors")
            {
                Console.WriteLine("Enter a first, last, or full name to lookup an Author:");
                string keyword = Console.ReadLine();
                List<Book> searchResult = myBooks.Where(Book => Book.Author.Contains(keyword)).ToList();
                if (searchResult.Count > 0)
                {
                    Console.WriteLine("Results found:");
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        var bookNum = i + 1;
                        Console.WriteLine($"{bookNum}: {searchResult[i].Title} {searchResult[i].Author} {searchResult[i].CheckedOutStatus} {searchResult[i].DueDate}");
                    }
                    // selectBook(searchResult); <-- cant use this because it references the entire book list, not filtered results
                    // make checkout method?
                }
                else
                {
                    Console.WriteLine("No matches found.");
                    // select book to check out?
                    // probably better if it takes them back to the main menu
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                // re-run searchBook
            }
        }
        public static void selectBook(List<Book> myBooks)
        {
            bool continueSelection = true;
            while (continueSelection)
            {
                try
                {
                    Console.WriteLine("Enter your choice by book number:");
                    string choice = Console.ReadLine();
                    int choiceInt = int.Parse(choice);
                    Book selectedBook = myBooks.Where(Book => Book.BookNum == choiceInt).FirstOrDefault();
                    if (selectedBook != null)
                    {
                        Console.WriteLine($"You've selected {selectedBook.Title}. Would you like to check it out? (y/n)");
                        string userSelection = Console.ReadLine().ToUpper();
                        if (userSelection == "Y")
                        {
                            selectedBook.DueDate = DateTime.Today.AddDays(14);
                            Console.WriteLine($"Enjoy {selectedBook.Title} it is due back {selectedBook.DueDate}");
                            selectedBook.CheckedOutStatus = true;
                        }
                        else
                        {
                            Console.WriteLine("Book not checked out. \n");
                        }
                        Console.WriteLine("Would you like to check out another book? (y/n)");
                        string answer = Console.ReadLine().ToUpper();
                        if (answer != "Y")
                        {
                            continueSelection = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You did not select a valid book from our library.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return;
        }
        public static void returnBook(List<Book> myBooks)
        {
            bool continueReturns = true;
            while (continueReturns)
            {
                try
                {
                    Console.WriteLine("Enter the number of the book do you want to return?");
                    string choice = Console.ReadLine();
                    int choiceInt = int.Parse(choice);
                    //bool isValidInt = int.TryParse(choice, out choiceInt); 
                    Book selectedBook = myBooks.Where(Book => Book.BookNum == choiceInt).FirstOrDefault();
                    if (selectedBook != null)
                    {
                        Console.WriteLine($"You chose: {selectedBook.BookNum} {selectedBook.Title} Due Date: {selectedBook.DueDate:MM/dd/yyyy}");
                        Console.WriteLine("Would you like to return this book? (y/n)");
                        string ans = Console.ReadLine().ToUpper();
                        if (ans == "Y")
                        {
                            if (selectedBook.CheckedOutStatus == true)
                            {
                                selectedBook.CheckedOutStatus = false;
                                selectedBook.DueDate = null;
                                Console.WriteLine($" { selectedBook.BookNum}. { selectedBook.Title} - Successfully Returned.");
                            }
                            else { Console.WriteLine("This book isn't checked out so you can't return it."); }
                        }
                        Console.WriteLine("Would you like to return another book? (y/n)");
                        ans = Console.ReadLine().ToUpper();
                        if (ans == "N")
                        {
                            continueReturns = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

