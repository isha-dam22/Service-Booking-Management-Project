using Microsoft.AspNetCore.Mvc;
using Service_Booking_Management_Microservice.Model;
using System.Collections.Generic;
using Newtonsoft.Json;
using Service_Booking_Management_Microservice.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service_Booking_Management_Microservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceReqController : ControllerBase
    {
        private IServiceRequestService _service;

        private List<AppService> services = new List<AppService>();
        private IDictionary<string, dynamic> response = new Dictionary<string, dynamic>();
        public ServiceReqController(IServiceRequestService service)
        {
            _service = service;

            services.Add(new AppService { Id = 1, ProductId = 1, UserId = 1, Description = "Service Done", Problem = "Not working", ReqDate = DateTime.Now, Status = "pending" });
            services.Add(new AppService { Id = 2, ProductId = 2, UserId = 2, Description = "Service Done", Problem = "Not working", ReqDate = DateTime.Now, Status = "pending" });
            services.Add(new AppService { Id = 3, ProductId = 3, UserId = 2, Description = "Service Done", Problem = "Not working", ReqDate = DateTime.Now, Status = "resolved" });
        }

        // GET: api/<ServiceReqController>
        [HttpGet]
        public string Get()
        {
            try
            {
                var data = _service.GetServicesList();
                if (data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Services are fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no Service");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // GET api/<ServiceReqController>/5
        [HttpGet("{userId}")]
        public string Get(int userId)
        {
            try
            {
                var searchResult = _service.GetServiceRequestDetailsByUserId(userId);
                if (searchResult.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Servies Fetch");
                    response.Add("data", searchResult);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no service avilable");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }

            }
            catch (Exception ex)
            {
                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // GET api/<ServiceReqController>/5
        [HttpGet("GetByStatus/{status}")]
        public string GetByStatus(string status)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(status);
                System.Diagnostics.Debug.WriteLine("status");

                var searchResult = _service.GetServiceRequestDetailsByStatus(status);
                if (searchResult.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Servies Fetch");
                    response.Add("data", searchResult);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no service avilable");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }

            }
            catch (Exception ex)
            {
                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // POST api/<ServiceReqController>
        [HttpPost]
        public string Post([FromBody] AppService value)
        {
            try
            {
                string tokenFromHeader = Request.Headers["Authorization"];
                var token = tokenFromHeader.Replace("Bearer ", string.Empty);

                var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadJwtToken(token);


                string id = decodedToken.Claims.First(claim => claim.Type == "Id").Value;
                int userId = int.Parse(id);

                var _temp = _service.SaveService(userId, value);
                if(_temp)
                {
                    response.Add("error", false);
                    response.Add("message", "Data Added");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Some Thing Went Wrong");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }
        


        // PUT api/<ServiceReqController>/5
        [HttpPut]
        public string Put([FromBody] AppService value)
        {
            try
            {
                var data = _service.UpdateService(value);

                if(data)
                {
                    response.Add("error", false);
                    response.Add("message", "Data Updated");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Data Not Updated");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // DELETE api/<ServiceReqController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                var data = _service.DeleteService(id);

                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "Service Deleted");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Service Deleted, Something Wrong");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        [HttpPost("Report")]
        public string Report([FromBody] AppServiceReport value)
        {
            try
            {
                var _temp = _service.SaveServiceReport(value);
                if (_temp)
                {
                    response.Add("error", false);
                    response.Add("message", "Data Added");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Some Thing Went Wrong");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        [HttpGet("Report")]
        public string Report()
        {
            try
            {
                var data = _service.GetServicesReportList();
                if (data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Service Reports are fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no Service Reports");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
            
        }

        [HttpGet("Report/{userId}")]
        public string Report(int userId)
        {
            try
            {
                var searchResult = _service.GetServiceReportDetailsByUserId(userId);
                
                if (searchResult.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Servie Report Fetch");
                    response.Add("data", searchResult);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no Service Report avilable");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }

            }
            catch (Exception ex)
            {
                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        [HttpGet("Report/GetByReportId/{reportId}")]
        public string GetByReportId(int reportId)
        {
            try
            {
                var data = _service.GetServiceReportDetailsByReportId(reportId);
                if (data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Service Reports are fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no Service Reports");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }
    }
}
