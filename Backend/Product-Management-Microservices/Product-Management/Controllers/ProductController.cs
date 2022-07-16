using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product_Management_Microservice.Services;
using Product_Management_Microservice.Model;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product_Management_Microservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IDictionary<string, dynamic> response = new Dictionary<string, dynamic>();

        private IProductService _product;

        public ProductController(IProductService product)
        {
            _product = product;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public string Get()
        {
            try
            {
                var data = _product.GetAllProducts();
                if(data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "All Products Fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "No Products are Available");

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

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var data = _product.GetProductById(id);
                if (data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Product Fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "No Product Available");

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

        // POST api/<ProductController>
        [HttpPost]
        public string Post([FromBody] AppProduct value)
        {
            try
            {
                var data = _product.SaveProduct(value);
                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "Product Added");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Something Went Wrong");

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

        // PUT api/<ProductController>/5
        [HttpPut]
        public string Put([FromBody] AppProduct value)
        {
            try
            {
                var data = _product.UpdateProduct(value);
                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "Product Updated");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Something Went Wrong");

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

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                var data = _product.DeleteProduct(id);
                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "Product Deleted");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Something Went Wrong");

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
