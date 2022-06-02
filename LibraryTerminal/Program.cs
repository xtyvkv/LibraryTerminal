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

namespace LibraryTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] libraryBooks = buildLibrary();
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
                    // method to search by title or author - Christy
                }
                else if (response == "3")
                {
                    // method to select a book - Brett
                    displayList(libraryBooks);
                    selectBook(libraryBooks);
                }
                else if (response == "4")
                {
                    // method to return a book - karen
                }
                else if (String.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Goodbye!");
                    continueRunning = false;
                    //return;
                }
            }
        }
        public static Book[] buildLibrary()
        {
            var booksList = new List<Book>();
            Book newBook = null;

            newBook = new Book(1, "A Time to Kill", "John Grisham", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(2, "East of Eden", "John Steinbeck", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(3, "Number the Stars", "Lois Lowry", true, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(4, "The Fault in our Stars", "John Green", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(5, "Green Eggs and Ham", "Dr. Seuss", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(6,"In Cold Blood", "Truman Capote", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(7, "Band of Brothers", "Stephen E. Ambrose", true, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(8,"The Dark Tower", "Stephen King", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(9,"Charlottes Web", "E.B. White", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(10,"Gone with the Wind", "Margaret Mitchel", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(11,"The Grapes of Wrath", "John Steinbeck", true, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(12,"A Farewell to Arms", "Ernest Hemingway", false, new DateTime());
            booksList.Add(newBook);

            return booksList.ToArray();
        }
        public class Book
        {
            //add book number 
            public int BookNum {get; private set; }
            public string Title { get; private set; }
            public string Author { get; private set; }
            public bool CheckedOutStatus { get; private set; }
            public DateTime DueDate { get; private set; }  //need to figure out how to handle dates

            public Book(int newBookNum, string newTitle, string newAuthor, bool newStatus, DateTime newDate)
            {
                Title = newTitle;
                Author = newAuthor;
                CheckedOutStatus = newStatus;
                DueDate = newDate;
            }
        }
        public static void displayList(Book[] myBooks)
        {
            for (int i = 0; i < myBooks.Length; i++)
            {
                var bookNum = i + 1;
                Console.WriteLine($"{bookNum}: {myBooks[i].Title} {myBooks[i].Author} {myBooks[i].CheckedOutStatus} {myBooks[i].DueDate}");
            }
        }
        public static void selectBook(Book[] myBooks)
        {
            Console.WriteLine("Enter Your Choice by Title:");
            string choice = Console.ReadLine();
            int choiceInt;

            bool isValidInt = int.TryParse(choice, out choiceInt);
                Console.WriteLine($"You Chose: {choice} ");
            
            /*
             * somehow find your boook and update info
            foreach(Book book in myBooks)
                if (book.BookNum = choiceInt)
                {
                    //update check out status and due date
                }

            */
            // validate choice - valid book number
            //search for book inside book list and return that book object
            // update due date and display also 
        }
    }
}

