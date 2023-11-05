using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.Controllers
{
    public interface IBookService
    {
        Task<ServiceResponse<List<Book>>> GetBookAsync();

        Task<ServiceResponse<Book>> UpdateBookAsync(Book book);

        Task<ServiceResponse<bool>> DeleteBookAsync(int id);

        Task<ServiceResponse<Book>> CreateBookAsync(Book book);
    }
}
