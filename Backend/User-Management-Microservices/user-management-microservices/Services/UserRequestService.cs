using Microsoft.EntityFrameworkCore;
using User_Management_Microservice.Model;

namespace User_Management_Microservice.Services
{
    public class UserRequestService : IUserRequestService
    {
        private ApplicationDbContex _context;

        public UserRequestService(ApplicationDbContex context)
        {
            _context = context;
        }
        public bool DeleteUser(int id)
        {
            try
            {
                var service = _context.AppUsers.Where(p => p.Id == id).FirstOrDefault();
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
       
        public List<AppUser> GetServiceRequestDetailsByUserId(int userId)
        {
            List<AppUser> services = new List<AppUser>();
            try
            {
                services = _context.AppUsers.Where(p => p.Id == userId).Select(p => new AppUser { Id = p.Id, Name = p.Name, Email = p.Email, Mobile = p.Mobile, Registrationdate = p.Registrationdate }).ToList();
                return services;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public List<AppUser> GetUserList()
        {
            List<AppUser> services = new List<AppUser>();
            try
            {
                
                services = _context.AppUsers.Select(p => new AppUser { Id = p.Id, Name = p.Name, Email = p.Email, Mobile = p.Mobile, Registrationdate = p.Registrationdate }).ToList();

                return services;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public string SaveUser(AppUser serviceReqModel)
        {
            try
            {
                var user = _context.AppUsers.Where(p => p.Email == serviceReqModel.Email).FirstOrDefault();

                if(user != null)
                {
                    return "1";
                }
                if (serviceReqModel != null)
                {
                    _context.AppUsers.Add(serviceReqModel);
                    _context.SaveChanges();
                    return "2";
                }
                else
                {
                    return "3";
                }
            }
            catch (Exception)
            {
                return "4";
            }
        }
        
        public bool UpdateUser(AppUser serviceReqModel)
        {
            try
            {
                var service = _context.AppUsers.Where(p => p.Id == serviceReqModel.Id).FirstOrDefault();
                if (service != null)
                {
                    service.Email = serviceReqModel.Email;
                    service.Name = serviceReqModel.Name;
                    service.Mobile = serviceReqModel.Mobile;
                    service.Registrationdate = serviceReqModel.Registrationdate;

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

        public bool ChangePassword(int id, AppUser serviceReqModel)
        {
            try
            {
                var service = _context.AppUsers.Where(p => p.Id == id).FirstOrDefault();
                if (service != null)
                {
                    service.Password = serviceReqModel.Password;

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

