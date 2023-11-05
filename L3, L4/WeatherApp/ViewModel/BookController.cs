using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web.Mvc;
using WeatherApp.Model;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            _logger.Log(LogLevel.Information, "Invoked GetBooks Method in controller");

            var result = await _bookService.GetBookAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Book>>> UpdateBook([FromBody] Book book)
        {

            var result = await _bookService.UpdateBookAsync(book);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Book>>> CreateProduct([FromBody] Book book)
        {
            var result = await _bookService.CreateBookAsync(book);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        // http:localhost/api/product/delete?id=4
        // http:localhost/api/product/4 dla api REST
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBook([FromRoute] int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }



    }
}
