using TechXpress.Data;
using TechXpress.Models; 

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);

}

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _unitOfWork.Products.GetAllAsync(true);
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _unitOfWork.Products.GetByIdAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        _unitOfWork.Products.Update(product);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product != null)
        {
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}