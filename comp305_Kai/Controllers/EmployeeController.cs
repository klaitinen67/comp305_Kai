using Microsoft.AspNetCore.Mvc;

namespace comp305_Kai.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly MyContext _db;

        public IActionResult Index()
        {
            return View();
        }
    }
}
