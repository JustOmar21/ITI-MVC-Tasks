using Day_06.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Day_06.Models
{
    public enum Gender { Male , Female }
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNum { get; set; } = string.Empty;

        public IEnumerable<Order>? Orders { get; set; }
    }
}
