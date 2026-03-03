using Microsoft.AspNetCore.Mvc;
using comp305_Kai.Models;
using comp305_Kai.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
