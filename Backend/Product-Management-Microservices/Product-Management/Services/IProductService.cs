using Product_Management_Microservice.Model;

namespace Product_Management_Microservice.Services
{
    public interface IProductService
    {
        List<AppProduct> GetAllProducts();
        bool SaveProduct(AppProduct product);
        bool DeleteProduct(int id);
        bool UpdateProduct(AppProduct product);
        List<AppProduct> GetProductById(int id);
    }
}
