using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Console
{
    public class ProductService : IProductService
    {
        readonly HttpClient client;

        public ProductService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await client.GetAsync("products");
            string json = await response.Content.ReadAsStringAsync();

            List<Product>? products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products;
        }
    }
}
