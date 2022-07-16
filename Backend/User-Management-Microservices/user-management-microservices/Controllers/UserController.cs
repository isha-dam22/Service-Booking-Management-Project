using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using User_Management_Microservice.Model;
using System.Collections.Generic;
using User_Management_Microservice.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User_Management_Microservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRequestService _service;

        private List<AppUser> users = new List<AppUser>();
        private IDictionary<string, dynamic> response = new Dictionary<string, dynamic>();
        public UserController(IUserRequestService service)
        {
            _service = service;

            users.Add(new AppUser { Id = 1, Name = "Ritu", Password = "sqdk", Email = "ritu@123gmial.com", Mobile = 6789569, Registrationdate = DateTime.Now });
            users.Add(new AppUser { Id = 2, Name = "Ram", Password = "ngkh", Email = "ra345@gmail.com", Mobile = 5678967, Registrationdate = DateTime.Now });
            users.Add(new AppUser { Id = 3, Name = "Raju", Password = "jkhn", Email = "rituhk456@gmail.com", Mobile = 78960767, Registrationdate = DateTime.Now });
        }

        // GET: api/<ServiceReqController>
        [HttpGet]
        public string Get()
        {
            try
            {
                var data = _service.GetUserList();
                if (data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Users are fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no User");

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
                    response.Add("message", "Users Fetch");
                    response.Add("data", searchResult);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no user avilable");

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

                      
        [AllowAnonymous]
        [HttpPost]
        public string Post([FromBody] AppUser value)
        {
            try
            {
                var _temp = _service.SaveUser(value);
                if (_temp == "2")
                {
                    response.Add("error", false);
                    response.Add("message", "User Added");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else if (_temp == "3")
                {
                    response.Add("error", true);
                    response.Add("message", "User not Added");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "This email already exists");

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



        // POST api/<UserController>
        // PUT api/<UserController>/5
        [HttpPut]
        public string Put([FromBody] AppUser value)
        {
            try
            {
                var data = _service.UpdateUser(value);

                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "User Updated");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "User Not Updated");

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

       //pUT api/<UserController>/5
        // DELETE api/<ServiceReqController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                var data = _service.DeleteUser(id);

                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "User Deleted");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "User Deleted, Something Wrong");

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

        [HttpPut("ChangePassword")]
        public string ChangePassword([FromBody] AppUser value)
        {
            try
            {
                string tokenFromHeader = Request.Headers["Authorization"];
                var token = tokenFromHeader.Replace("Bearer ", string.Empty);

                var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadJwtToken(token);


                string id = decodedToken.Claims.First(claim => claim.Type == "Id").Value;
                int userId = int.Parse(id);

                var data = _service.ChangePassword(userId, value);

                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "Password changed successfully");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Password not changed");

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
