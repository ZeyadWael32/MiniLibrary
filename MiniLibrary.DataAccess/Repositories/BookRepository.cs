using Microsoft.EntityFrameworkCore;
using MiniLibrary.DataAccess.Data;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.Repositories
{
    public class BookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task TestCreateBookAsync(Book book, List<int> authorIds)
        {
            book.Authors = await _context.Authors
                .Where(author => authorIds.Contains(author.Id))
                .ToListAsync();

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> TestGetBookByIdAsync(int bookId)
        {
            return await _context.Books
                .Include(book => book.Authors)
                .FirstOrDefaultAsync(book => book.Id == bookId);
        }

        public async Task TestUpdateBookAsync(Book updatedBook, List<int> authorIds)
        {
            var book = await _context.Books
                .Include(book => book.Authors)
                .FirstOrDefaultAsync(b => b.Id == updatedBook.Id);

            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.ISBN = updatedBook.ISBN;
                book.Description = updatedBook.Description;
                book.Price = updatedBook.Price;
                book.CategoryId = updatedBook.CategoryId;
                book.PublisherId = updatedBook.PublisherId;
                book.Authors = await _context.Authors
                    .Where(author => authorIds.Contains(author.Id))
                    .ToListAsync();
            } else {               
                throw new Exception($"Book with ID {updatedBook.Id} not found.");
            }

            await _context.SaveChangesAsync();
        }

        public async Task TestDeleteBookByIdAsync(int bookId)
        {
            var book = await _context.Books
                .Include(book => book.Authors)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new Exception($"Book with ID {bookId} not found.");
            }
            
            book.Authors.Clear();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}