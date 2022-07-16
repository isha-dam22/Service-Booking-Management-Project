using Microsoft.EntityFrameworkCore;
using Product_Management_Microservice.Model;

namespace Product_Management_Microservice.Services
{
    public class ProductService : IProductService
    {
        private ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                var product = _context.AppProducts.Where(p => p.Id == id).FirstOrDefault();
                if (product != null)
                {
                    _context.Entry(product).State = EntityState.Deleted;
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

        public List<AppProduct> GetAllProducts()
        {
            try
            {
                List<AppProduct> products = new List<AppProduct>();
                products = _context.AppProducts.ToList();

                return products;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<AppProduct> GetProductById(int id)
        {
            try
            {
                List<AppProduct> products = new List<AppProduct>();
                products = _context.AppProducts.Where(p => p.Id == id).ToList();

                return products;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool SaveProduct(AppProduct productModel)
        {
            try
            {
                if (productModel != null)
                {
                    _context.AppProducts.Add(productModel);
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

        public bool UpdateProduct(AppProduct productModel)
        {
            try
            {
                var product = _context.AppProducts.Where(p => p.Id == productModel.Id).FirstOrDefault();
                if(product != null)
                {
                    product.Name = productModel.Name;
                    product.Make = productModel.Make;
                    product.Model = productModel.Model;
                    product.Cost = productModel.Cost;

                    _context.Entry(product).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
