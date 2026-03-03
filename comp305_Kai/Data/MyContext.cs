using Microsoft.EntityFrameworkCore;
using comp305_Kai.Models;

namespace comp305_Kai.Data
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) :base(options){ }

        public DbSet<Employee> employees { get; set; }
        // IDENTICAl to the table name
    }
}
