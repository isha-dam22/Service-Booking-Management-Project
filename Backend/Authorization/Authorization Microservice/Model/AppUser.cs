using System.ComponentModel.DataAnnotations;

namespace Authorization_Microservice.Model
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public long? Mobile { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
    }
}
