using Bogus;
using WeatherApp.Shop;

namespace WeatherApp.ViewModel
{
    internal class ProductSeeder
    {
        public static List<Book> GenerateProductData()
        {
            int productId = 1;
            var bookFaker = new Faker<Book>("pl")
                .UseSeed(123456)
                .RuleFor(x => x.Title, x => x.Lorem.Sentence(3))
                .RuleFor(x => x.Author, x => x.Name.FullName())
                .RuleFor(x => x.Id, x => productId++)
                .RuleFor(x => x.Price, x => x.Random.Double(1, 1000))
                .RuleFor(x => x.ReleaseDate, x => x.Date.Past());

            return bookFaker.Generate(50).ToList();

        }

    }
}
