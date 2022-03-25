// See https://aka.ms/new-console-template for more information

using FakeStore.Console;
using Newtonsoft.Json;


HttpClient client = new HttpClient();
client.BaseAddress = new Uri($"https://fakestoreapi.com/");

var response = await client.GetAsync("products");
string json = await response.Content.ReadAsStringAsync();

List<Product>? products = JsonConvert.DeserializeObject<List<Product>>(json);

List<Product>? highlyratedProducts = products?.Where(t => t.rating.rate > 3)
                                    .OrderByDescending(t => t.rating.rate)
                                    .ToList();

//highlyratedProducts = null;

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
