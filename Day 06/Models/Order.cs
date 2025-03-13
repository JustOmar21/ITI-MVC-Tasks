using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day_06.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        public Customer? Customer { get; set; }
    }
}
