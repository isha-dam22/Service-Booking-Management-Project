using System.ComponentModel.DataAnnotations;

namespace Service_Booking_Management_Microservice.Model
{
    public class AppService
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public int ProductId { get; set; }
        //[Required]
        public int UserId { get; set; }
        //[Required]
        public DateTime ReqDate { get; set; }
        //[Required]
        public string Problem { get; set; }
        public string Description { get; set; }
        //[Required]
        public string Status { get; set; } = "pending";
    }
}
