using CrudWebApiDBFirstMongo.Models;
using MongoDB.Driver;

namespace CrudWebApiDBFirstMongo.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;

        public EmployeeService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("LibraryDb");  // Existing DB
            _employee = database.GetCollection<Employee>("Employee");  // Existing Collection
        }

        public async Task<List<Employee>> GetAsync() =>
            await _employee.Find(_ => true).ToListAsync();

        public async Task<Employee?> GetAsync(string id) =>
            await _employee.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Employee book) =>
            await _employee.InsertOneAsync(book);

        public async Task UpdateAsync(string id, Employee updated) =>
            await _employee.ReplaceOneAsync(x => x.Id == id, updated);

        public async Task DeleteAsync(string id) =>
            await _employee.DeleteOneAsync(x => x.Id == id);
    }
}
