using CrudWebApiDBFirstMongo.Models;
using CrudWebApiDBFirstMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebApiDBFirstMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<Employee>> Get() => await _employeeService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Employee>> Get(string id)
        {
            var book = await _employeeService.GetAsync(id);
            return book is null ? NotFound() : book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee book)
        {
            await _employeeService.CreateAsync(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Employee book)
        {
            var existing = await _employeeService.GetAsync(id);
            if (existing is null) return NotFound();

            book.Id = id;
            await _employeeService.UpdateAsync(id, book);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _employeeService.GetAsync(id);
            if (book is null) return NotFound();

            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
