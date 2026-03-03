using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comp305_Kai.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        // IDENTICALLY TYPED -> (name and data type)
        public long EmployeeId { get; set; }
        public String? Name { get; set; }
        public string Email { get; set; }
    }
}
