using System.ComponentModel.DataAnnotations;

namespace Product_Management_Microservice.Model
{
    public class AppProduct
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Cost { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
