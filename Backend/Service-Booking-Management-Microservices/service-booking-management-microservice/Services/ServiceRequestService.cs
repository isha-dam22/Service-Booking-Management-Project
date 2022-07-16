using Microsoft.EntityFrameworkCore;
using Service_Booking_Management_Microservice.Model;

namespace Service_Booking_Management_Microservice.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private AppicationContext _context;

        public ServiceRequestService(AppicationContext context)
        {
            _context = context;
        }
        public bool DeleteService(int id)
        {
            try
            {
                var service = _context.AppServices.Where(p => p.Id == id).FirstOrDefault();
                if (service != null)
                {
                    _context.Entry(service).State = EntityState.Deleted;
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<AppServiceReport> GetServiceReportDetailsByReportId(int reportId)
        {
            List<AppServiceReport> serviceReport = new List<AppServiceReport>();
            try
            {
                serviceReport = _context.AppServiceReports.Where(p => p.Id == reportId).Include(p => p.AppService).ToList();
                return serviceReport;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public List<AppServiceReport> GetServiceReportDetailsByUserId(int userId)
        //public void GetServiceReportDetailsByUserId(int userId)
        {
            List<AppServiceReport> serviceReports = new List<AppServiceReport>();
            try
            {
               var services = _context.AppServices.Where(p => p.UserId == userId).ToList();

                foreach (var item in services)
                {
                    System.Diagnostics.Debug.WriteLine(item.Id);
                    var serviceReport = _context.AppServiceReports.Where(p => p.SerReqId == item.Id).Include(p => p.AppService).SingleOrDefault();
                    System.Diagnostics.Debug.WriteLine(serviceReport.Id);
                    serviceReports.Add(serviceReport);
                }

                return serviceReports;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AppService> GetServiceRequestDetailsByStatus(string status)
        {
            List<AppService> services = new List<AppService>();
            try
            {
                services = _context.AppServices.Where(p => p.Status == status).ToList();
                return services;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public List<AppService> GetServiceRequestDetailsByUserId(int userId)
        {
            List<AppService> services = new List<AppService>();
            try
            {
                services = _context.AppServices.Where(p => p.UserId == userId).ToList();
                return services;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public List<AppService> GetServicesList()
        {
            List<AppService> services = new List<AppService>();
            try
            {
                services = _context.AppServices.ToList();

                return services;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<AppServiceReport> GetServicesReportList()
        {
            List<AppServiceReport> servicesReport = new List<AppServiceReport>();
            try
            {
                servicesReport = _context.AppServiceReports.Include(p => p.AppService).ToList();
                return servicesReport;
            }
            catch (Exception)
            {

                return servicesReport;
            }
        }

        public bool SaveService(int userId, AppService serviceReqModel)
        {
            try
            {
                if(serviceReqModel != null)
                {
                    _context.AppServices.Add(new AppService { ProductId = serviceReqModel.ProductId, UserId = userId, ReqDate = serviceReqModel.ReqDate, Problem = serviceReqModel.Problem, Description = serviceReqModel.Description } );
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveServiceReport(AppServiceReport serviceReportModel)
        {
            try
            {
                if (serviceReportModel != null)
                {
                    _context.AppServiceReports.Add(serviceReportModel);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateService(AppService serviceReqModel)
        {
            try
            {
                var service = _context.AppServices.Where(p => p.Id == serviceReqModel.Id).FirstOrDefault();
                if(service != null)
                {
                    service.ReqDate = serviceReqModel.ReqDate;
                    service.Problem = serviceReqModel.Problem;
                    service.Description = serviceReqModel.Description;
                    service.Status = serviceReqModel.Status;

                    _context.Entry(service).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
