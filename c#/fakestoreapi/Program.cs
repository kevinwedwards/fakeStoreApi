// See https://aka.ms/new-console-template for more information

HttpClient client = new HttpClient();
client.BaseAddress = new Uri($"https://fakestoreapi.com/");

IProductService service = new ProductService(client);

var products = await service.GetProductsAsync();

List<Product>? highlyratedProducts = products?.Where(t => t.rating.rate > 3)
                                    .OrderByDescending(t => t.rating.rate)
                                    .ToList();



if (highlyratedProducts!=null && highlyratedProducts.Any())
{
    foreach (var product in highlyratedProducts)
    {
        Console.WriteLine($"{product.rating.rate}: {product.title}");
    }
}
else
{
    Console.WriteLine($"No highly rated items exist");
}
