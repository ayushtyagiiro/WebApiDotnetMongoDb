
using CrudWebApiCodeFirstMongo.Models;
using MongoDB.Driver;

namespace CrudWebApiCodeFirstMongo.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("LibraryDb");
            _books = database.GetCollection<Book>("Books");
        }

        public async Task<List<Book>> GetAsync() => await _books.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) => await _books.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) => await _books.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _books.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _books.DeleteOneAsync(x => x.Id == id);
    }
   
}
