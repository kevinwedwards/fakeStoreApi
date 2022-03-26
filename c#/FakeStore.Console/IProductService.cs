namespace FakeStore.Console
{
    internal interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }
}