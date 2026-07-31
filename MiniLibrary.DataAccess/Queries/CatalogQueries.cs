using Microsoft.EntityFrameworkCore;
using MiniLibrary.DataAccess.Data;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.Queries
{
    public class CatalogQueries
    {
        private readonly ApplicationDbContext _context;

        public CatalogQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books
            .OrderBy(book => book.Title)
            .ToList();
        }

        public List<Book> GetBooksWithAuthors()
        {
            return _context.Books
                .Include(book => book.Authors)
                .ToList();
        }

        public List<Book> GetBooksByCategory(int categoryId)
        {
            return _context.Books
                .Where(book => book.CategoryId == categoryId)
                .ToList();
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _context.Books
                .Where(book => book.Authors.Any(author => author.Id == authorId))
                .ToList();
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            return _context.Books
                .Where(book => book.Title.Contains(searchTerm) || book.ISBN.Contains(searchTerm))
                .ToList();
        }

        public Book? GetBookDetails(int bookId)
        {
            return _context.Books
                .Include(book => book.Category)
                .Include(book => book.Publisher)
                .Include(book => book.Authors)
                .SingleOrDefault(book => book.Id == bookId);
        }
    }
}