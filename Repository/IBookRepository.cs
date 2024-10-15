using PopePhransisBookStore.DTO;
using PopePhransisBookStore.Model;

namespace PopePhransisBookStore.Repository
{
    public interface IBookRepository
    {
        Task<Book> CreateBook(Book book);
        Task<Book> GetBook(int id);
        Task<List<Book>>ListOfBooks();
        Task<Book> UpdateBook(Book book);
       Task <bool> DeleteBook(int id);
        


    }
}
