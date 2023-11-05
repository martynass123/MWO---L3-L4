using WeatherApp.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Controllers
{
    public class BookService : IBookService
    {
        private readonly DataContext _dataContext;
        public BookService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<ServiceResponse<Book>> CreateBookAsync(Book book)
        {
            try
            {
                _dataContext.Books.Add(book);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book>() { Data = book, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = null,
                    Success = false,
                    Message = "Cannot create product"
                };
            }

        }

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {
            var book = new Book() { Id = id };
            _dataContext.Books.Attach(book);
            _dataContext.Books.Remove(book);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true, Success = true };
        }

        public async Task<ServiceResponse<List<Book>>> GetBookAsync()
        {
            var books = await _dataContext.Books.ToListAsync();

            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = books,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }

        }

        public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
        {
            try
            {
                var bookToEdit = new Book() { Id = book.Id };
                _dataContext.Books.Attach(bookToEdit);

                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;
                bookToEdit.Price = book.Price;
                bookToEdit.ReleaseDate = book.ReleaseDate;

                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book> { Data = bookToEdit, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occured while updating product"
                };
            }



        }
    }
}
