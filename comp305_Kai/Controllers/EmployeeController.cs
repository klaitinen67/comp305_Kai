using Microsoft.AspNetCore.Mvc;
using comp305_Kai.Models;
using comp305_Kai.Data;

namespace comp305_Kai.Controllers
{
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

        }
    }
}
