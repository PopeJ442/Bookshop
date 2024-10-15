using Microsoft.EntityFrameworkCore;
using PopePhransisBookStore.Data;
using PopePhransisBookStore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PopePhransisBookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBook(Book book)
        {
            
            await _context.PopePhransisBookStore.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> GetBook(int id)
        {
           

            return await _context.PopePhransisBookStore.FindAsync(id);
        }

        public async Task<List<Book>> ListOfBooks()
        {
            
            return await _context.PopePhransisBookStore.ToListAsync();
        }

        public async Task<Book> UpdateBook(Book updatedBook)
        {
            
            var existingBook = await _context.PopePhransisBookStore.FindAsync(updatedBook.Id);
            if (existingBook != null)
            {
                existingBook.BookName = updatedBook.BookName;
                existingBook.Category = updatedBook.Category;
                existingBook.Description = updatedBook.Description;
                existingBook.Price = updatedBook.Price;

                await _context.SaveChangesAsync();
                return existingBook;
            }

            return null; 
        }


       public async Task  <bool> DeleteBook(int id)
        {
            var existingBook = await _context.PopePhransisBookStore.FindAsync(id);
            if (existingBook != null)
            {
                _context.PopePhransisBookStore.Remove(existingBook);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
