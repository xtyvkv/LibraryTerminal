﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace LibraryTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }
        public static Book[] buildLibrary()
        {
            var booksList = new List<Book>();
            Book newBook = null;

            newBook = new Book("Book 1", "Author 1", false, new DateTime(2015,12,10));
            booksList.Add(newBook);
            newBook = new Book("Book 2", "Author 2", false, new DateTime(2015, 12, 10)););
            booksList.Add(newBook);
            newBook = new Book("Book 3", "Author 3", false, new DateTime(2015, 12, 10)); 
            booksList.Add(newBook);
            newBook = new Book("Book 4", "Author 4", false, new DateTime(2015, 12, 10));
            booksList.Add(newBook);

            return booksList.ToArray();
        }
        public class Book
        {
            public string Title { get; private set; }
            public string Author { get; private set; }
            public bool CheckedOutStatus { get; private set; }
            public DateTime DueDate { get; private set; }  //need to figure out how to handle dates
            
            public Book(string newTitle, string newAuthor, bool newStatus, DateTime newDate)
            {
                Title = newTitle;
                Author = newAuthor;
                CheckedOutStatus = newStatus;
                DueDate = newDate;
            }
        }
    }
}

