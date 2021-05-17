using GetTheBook.DAL.Models;
using System;
using System.Collections.Generic;

namespace GetTheBook
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UserBL userBl = new UserBL();
                UserService userService = new UserService();

                Console.WriteLine("Please login with only your username");
                var username = Console.ReadLine();

                userBl = userService.GetUserByUsername(username);
                if (userBl != null)
                {
                    Console.WriteLine("Welcome " + userBl.Username);

                    BookBL bookBL = new BookBL();
                    BookService bookService = new BookService();
                    bool open = true;
                    int choice = 0;
                    do
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("-1- View available books");
                        Console.WriteLine("-2- Search by ISBN");
                        Console.WriteLine("-3- Borrow book");
                        Console.WriteLine("-4- Return book");
                        Console.WriteLine("-5- View available books");
                        Console.WriteLine("-6- View returned books");
                        Console.WriteLine("-9- Exit");
                        Console.WriteLine("---------------------------------------");

                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Incorrect value, please try again.");
                            Console.WriteLine(ex.Message);
                        }

                        switch (choice)
                        {
                            case 1:

                                Console.WriteLine("Books at the storage: ");
                                List<BookBL> books = bookService.GetAllBooks(20);
                                foreach (var b in books)
                                {
                                    Console.WriteLine(b.Title + "\t" + b.Isbn);
                                }
                                break;
                            case 2:
                                Console.WriteLine("ISBN: ");
                                string isbn = Console.ReadLine();
                                isbn.ToString();
                                bookBL = bookService.GetBookByISBN(isbn);
                                try
                                {
                                
                                    if (bookBL == null)
                                    {
                                        Console.WriteLine("Wrong ISBN!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Title: " + bookBL.Title);
                                    }
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine("Please try again!");
                                }

                               

                                break;

                            case 3:
                                Console.WriteLine("BORROW BOOK:\n ===================== \n Please enter valid ISBN code: ");
                                isbn = Console.ReadLine();

                                bookBL = bookService.BorrowSelectedBook(isbn);
                                Console.WriteLine(bookService.Msg);

                                if (bookBL != null)
                                    Console.WriteLine("You borrowed book " + bookBL.Title);
                                break;
                            case 4:
                                Console.WriteLine("RETURN BOOK:\n ===================== \n Please enter valid ISBN code: ");
                                isbn = Console.ReadLine();

                                bookBL = bookService.ReturnSelectedBook(isbn);
                                Console.WriteLine(bookService.Msg);
                                Console.WriteLine("You returned book " + bookBL.Title);
                                break;
                            case 5:
                                Console.WriteLine("LIST OF BORROWED BOOKS:\n ===================== \n ");

                                List<BookBL> list = bookService.GetAllBorrowedBooks();
                                foreach (var b in list)
                                {
                                    Console.WriteLine(b.Title + "\t" + b.Isbn);
                                }
                                Console.WriteLine(bookService.Msg);
                                break;
                            case 6:
                                Console.WriteLine("LIST OF RETURNED BOOKS:\n ===================== \n ");

                                List<BookBL> list2 = bookService.GetAllReturnedBooks();
                                foreach (var b in list2)
                                {
                                    Console.WriteLine(b.Title + "\t" + b.Isbn);
                                }
                                Console.WriteLine(bookService.Msg);
                                break;
                            case 9:
                                Console.WriteLine("Exiting application, press Enter to continue.");
                                open = false;
                                Console.ReadLine();
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Please enter valid number(1-5) or 9 for exit");
                                break;
                        }


                    } while (open);
                }
                else
                {
                    Console.WriteLine("User does not exist, Try again!");
                }
            }
 
        }
    }
}
