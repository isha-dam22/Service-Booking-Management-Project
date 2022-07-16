using Service_Booking_Management_Microservice.Model;

namespace Service_Booking_Management_Microservice.Services
{
    public interface IServiceRequestService
    {
        List<AppService> GetServicesList();
        List<AppService> GetServiceRequestDetailsByUserId(int userId);
        bool SaveService(int userId, AppService serviceReqModel);
        bool DeleteService(int id);
        bool UpdateService(AppService serviceReqModel);
        List<AppService> GetServiceRequestDetailsByStatus(string status);


        bool SaveServiceReport(AppServiceReport serviceReportModel);
        List<AppServiceReport> GetServicesReportList();
        List<AppServiceReport> GetServiceReportDetailsByUserId(int userId);
        List<AppServiceReport> GetServiceReportDetailsByReportId(int reportId);
    }
}
