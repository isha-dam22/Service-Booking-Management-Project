using Microsoft.AspNetCore.Mvc;
using Authorization_Microservice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authorization_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _config;
        private ApplicationContext _context;
        private IDictionary<string, dynamic> response = new Dictionary<string, dynamic>();
        public LoginController(IConfiguration config, ApplicationContext context)
        {
            _config = config;
            _context = context;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public string Post([FromBody] AppUser value)
        {
            try
            {
                if (value != null && value.Email != null && value.Password != null)
                {
                    var user = _context.AppUsers.Where(p => p.Email == value.Email && p.Password == value.Password).FirstOrDefault();

                    if (user != null)
                    {
                        
                        //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Name", user.Name),
                        new Claim("Mobile", user.Mobile.ToString()),
                        new Claim("Email", user.Email)
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _config["Jwt:Issuer"],
                            _config["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(30),
                            signingCredentials: signIn);

                        //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                        response.Add("error", false);
                        response.Add("message", "Login Successful");
                        response.Add("token", new JwtSecurityTokenHandler().WriteToken(token));


                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                    else
                    {
                        response.Add("error", true);
                        response.Add("message", "Invalid Email or Password");

                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Please Enter Email and Password");

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
