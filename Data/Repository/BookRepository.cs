using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;
using BookHaven.Business;

namespace BookHaven.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        // Add Book
        public void AddBook(BookModel book)
        {
            string query = "INSERT INTO Book (BookID, Title, Author, Genre, ISBN, Price, StockQuantity, SupplierID, UserID) " +
               "VALUES (@BookID, @Title, @Author, @Genre, @ISBN, @Price, @StockQuantity, @SupplierID, @UserID)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", book.BookID);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Genre", book.Genre);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", book.StockQuantity);
                cmd.Parameters.AddWithValue("@SupplierID", (object)book.SupplierID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UserID", book.UserID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get All Books
        public List<BookModel> GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();
            string query = "SELECT BookID, Title, Author, Genre, ISBN, Price, StockQuantity, SupplierID, UserID FROM Book";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Column 5 (Price) DataType: {reader.GetFieldType(5)}");
                        Console.WriteLine($"Column 5 (Price) Value: {reader[5]}");

                        books.Add(new BookModel
                        {
                            BookID = reader.GetGuid(0),
                            Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Author = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Genre = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            ISBN = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Price = reader.IsDBNull(5) ? 0 : Convert.ToDecimal(reader[5]),
                            StockQuantity = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            SupplierID = reader.IsDBNull(7) ? (Guid?)null : reader.GetGuid(7),
                            UserID = reader.IsDBNull(8) ? Guid.Empty : reader.GetGuid(8)
                        });
                    }
                }
            }
            return books;
        }

        // Get Book by ISBN
        public BookModel GetBookByISBN(string isbn)
        {
            BookModel book = null;
            string query = "SELECT * FROM Book WHERE ISBN = @ISBN";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = new BookModel
                        {
                            BookID = reader.GetGuid(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            ISBN = reader.GetString(4),
                            Price = reader.GetDecimal(5),
                            StockQuantity = reader.GetInt32(6),
                            SupplierID = reader.IsDBNull(7) ? (Guid?)null : reader.GetGuid(7),
                            UserID = reader.GetGuid(8)
                        };
                    }
                }
            }
            return book;
        }

        // Fetch Book by Name
        public BookModel GetBookByName(string title)
        {
            BookModel book = null;
            string query = "SELECT BookID, Title, Author, Genre, ISBN, Price, StockQuantity, SupplierID, UserID FROM Book WHERE Title = @Title";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Title", title);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Fetched Book: {reader.GetString(1)}, Price: {reader.GetDecimal(5)}, Stock: {reader.GetInt32(6)}");

                        book = new BookModel
                        {
                            BookID = reader.GetGuid(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            ISBN = reader.GetString(4),
                            Price = reader.GetDecimal(5),
                            StockQuantity = reader.GetInt32(6),
                            SupplierID = reader.IsDBNull(7) ? (Guid?)null : reader.GetGuid(7),
                            UserID = reader.GetGuid(8)
                        };
                    }
                }
            }
            return book;
        }

        // Update Book
        public void UpdateBook(BookModel book)
        {
            string query = "UPDATE Book SET Title=@Title, Author=@Author, Genre=@Genre, ISBN=@ISBN, Price=@Price, " +
               "StockQuantity=@StockQuantity, SupplierID=@SupplierID WHERE BookID=@BookID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", book.BookID);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Genre", book.Genre);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", book.StockQuantity);
                cmd.Parameters.AddWithValue("@SupplierID", (object)book.SupplierID ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Book
        public void DeleteBook(Guid bookID)
        {
            string query = "DELETE FROM Book WHERE BookID=@BookID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", bookID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<BookModel> GetLowStockBooks()
        {
            List<BookModel> lowStockBooks = new List<BookModel>();
            string query = "SELECT b.BookID, b.Title, b.Author, b.Genre, b.ISBN, b.Price, b.StockQuantity, s.Name AS SupplierName, b.UserID " +
               "FROM Book b " +
               "LEFT JOIN Supplier s ON b.SupplierID = s.SupplierID " +
               "WHERE b.StockQuantity < 5";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lowStockBooks.Add(new BookModel
                        {
                            BookID = reader.GetGuid(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            ISBN = reader.GetString(4),
                            Price = reader.GetDecimal(5), 
                            StockQuantity = reader.GetInt32(6),
                            SupplierName = reader.IsDBNull(7) ? "Unknown Supplier" : reader.GetString(7),
                            UserID = reader.IsDBNull(8) ? Guid.Empty : reader.GetGuid(8) 
                        });
                    }
                }
            }
            return lowStockBooks;
        }

        public BookModel GetBookById(Guid bookId)
        {
            BookModel book = null;
            string query = "SELECT * FROM Book WHERE BookID = @BookID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookID", bookId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = new BookModel
                        {
                            BookID = reader.GetGuid(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            ISBN = reader.GetString(4),
                            Price = reader.GetDecimal(5),
                            StockQuantity = reader.GetInt32(6),
                            SupplierID = reader.IsDBNull(7) ? (Guid?)null : reader.GetGuid(7),
                            UserID = reader.GetGuid(8)
                        };
                    }
                }
            }
            return book;
        }
    }
}
