using System.ComponentModel.DataAnnotations;

namespace HW_6_2_website.Models
{
    public class Human
    {
        [Required]
        public int Passport { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
