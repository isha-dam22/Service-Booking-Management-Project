using System.ComponentModel.DataAnnotations;

namespace Service_Booking_Management_Microservice.Model
{
    public class AppServiceReport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }
        public bool ActionTaken { get; set; }
        public string DiagnosisDetails { get; set; }
        public bool IsPaid { get; set; }
        public int VisitFees { get; set; }
        public string RepairDetails { get; set; }
        public int SerReqId { get; set; }
        public string ServiceType { get; set; }
        public AppService? AppService { get; set; }

    }
}
