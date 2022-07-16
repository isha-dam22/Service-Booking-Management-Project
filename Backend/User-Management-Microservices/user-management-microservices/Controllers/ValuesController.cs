using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using User_Management_Microservice.Model;
namespace User_Management_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ApplicationDbContex _context;

        public ValuesController(ApplicationDbContex context)
        {
            _context = context;

            if (_context.AppUsers.Count() == 0)
            {
                _context.AppUsers.Add(new AppUser
                {
                    Id = 001,
                    Name = "Peter Wilson",
                    Password = "Mumbai",
                    Email = "ritu123@gmail.com",
                    Mobile = 617555 - 3267,
                    Registrationdate = DateTime.Now,
                });

                //_context.Suppliers.Add(new Supplier
                //{
                //CompanyName = "Exotic Liquids",
                //ContactName = "Peter Wilson",
                //City = "Boston",
                //Country = "USA",
                //Phone = "(617)555-3267",
                //ContactTitle = "Manager"
                //});
                _context.SaveChanges();
            }
        }
    
            [HttpGet]
             public IEnumerable<AppUser> Get()
            {
               return _context.AppUsers.ToList();
            }
            //api/valuescontroller
            [HttpGet("{id}", Name = "GetAppUsers")]
            private IActionResult GetById(int id)
            {
                var item = _context.AppUsers.FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }

        }
    }


    

