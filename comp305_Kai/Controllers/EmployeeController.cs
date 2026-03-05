using Microsoft.AspNetCore.Mvc;
using comp305_Kai.Models;
using comp305_Kai.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace comp305_Kai.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly MyContext _db;

        public EmployeeController(MyContext db)
        {
            _db = db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var employees = await _db.employees.ToListAsync();
                return Ok(employees);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee value)
        {
            try
            {
                var person = new Employee
                {
                    Name = value.Name,
                    Email = value.Email
                };

                _db.employees.Add(person);
                await _db.SaveChangesAsync();

                return Ok(person);
            }
            catch (Exception e)
            {
                Console.WriteLine("I got an exception: " + e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteEmployee([FromBody] long id)
        {
            try
            {
                var person = await _db.employees.FindAsync(id);

                if (person == null)
                    return NotFound();

                _db.employees.Remove(person);
                await _db.SaveChangesAsync();

                return Ok(person);
            }
            catch (Exception e)
            {
                Console.WriteLine("I got an exception: " + e.Message);
                return BadRequest();
            }
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee value, long id)
        {

            try
            {
                var OldEmployee = await _db.employees.FindAsync(id);

                if (value != null && OldEmployee != null)
                    OldEmployee.Name = value.Name;
                    OldEmployee.Email = value.Email;
                    

                _db.employees.Update(OldEmployee);
                await _db.SaveChangesAsync();

                return Ok(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("I Got an Exception: " + e.Message);
                return BadRequest();
            }
        }
    }
}
