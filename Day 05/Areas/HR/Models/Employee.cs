using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day_05.Areas.HR.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DateTime JoinDate { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNum { get; set; } = string.Empty;

        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public Department? Department { get; set; }
    }
}
