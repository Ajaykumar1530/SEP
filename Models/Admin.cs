using System.ComponentModel.DataAnnotations;

namespace InterView.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public long? MobileNo { get; set; }
    }
}
