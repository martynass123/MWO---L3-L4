using WeatherApp.Controllers;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using WeatherApp.Model;
using WeatherApp.View;

namespace WeatherApp.ViewModel
{
    public partial class BooksViewModel : ObservableObject
    {
        private readonly IBookService _bookService;
        private readonly IMessageDialogService _messageDialogService;
        private readonly BookDetailsView _bookDetailsView;
        public ObservableCollection<Book> Books { get; set; }

        private Book selectedBook;



        public BooksViewModel(IBookService bookService, BookDetailsView bookDetailsView, IMessageDialogService messageDialogService)
        {
            _messageDialogService = messageDialogService;
            _bookDetailsView = bookDetailsView;
            _bookService = bookService;
            Books = new ObservableCollection<Book>();
        }

        public async Task GetBooks()
        {
            Books.Clear();
            var booksResult = await _bookService.GetBookAsync();
            if (booksResult.Success)
            {
                foreach (var p in booksResult.Data)
                {
                    Books.Add(p);
                }
            }
        }

        public async Task CreateBook()
        {
            var newBook = new Book()
            {
                Title = selectedBook.Title,
                Author = selectedBook.Author,
                Price = selectedBook.Price,
                ReleaseDate = selectedBook.ReleaseDate,
            };

            var result = await _bookService.CreateBookAsync(newBook);
            if (result.Success)
                await GetBooks();
            else
                _messageDialogService.ShowMessage(result.Message);
        }

        public async Task UpdateBook()
        {
            var bookToUpdate = new Book()
            {
                Id = selectedBook.Id,
                Title = selectedBook.Title,
                Author = selectedBook.Author,
                Price = selectedBook.Price,
                ReleaseDate = selectedBook.ReleaseDate,
            };

            await _bookService.UpdateBookAsync(bookToUpdate);
            GetBooks();
        }

        public async Task DeleteBook()
        {
            await _bookService.DeleteBookAsync(selectedBook.Id);
            await GetBooks();
        }
    }
}
