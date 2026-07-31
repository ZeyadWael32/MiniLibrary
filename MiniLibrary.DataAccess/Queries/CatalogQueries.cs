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

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books
            .OrderBy(book => book.Title)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<List<Book>> GetBooksWithAuthors()
        {
            return await _context.Books
                .Include(book => book.Authors)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByCategory(int categoryId)
        {
            return await _context.Books
                .Where(book => book.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByAuthor(int authorId)
        {
            return await _context.Books
                .Where(book => book.Authors.Any(author => author.Id == authorId))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Book>> SearchBooks(string searchTerm)
        {
            return await _context.Books
                .Where(book => book.Title.Contains(searchTerm) || book.ISBN.Contains(searchTerm))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Book?> GetBookDetails(int bookId)
        {
            return await _context.Books
                .Include(book => book.Category)
                .Include(book => book.Publisher)
                .Include(book => book.Authors)
                .AsNoTracking()
                .SingleOrDefaultAsync(book => book.Id == bookId);
        }
    }
}