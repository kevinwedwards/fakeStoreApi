using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FakeStore.Console.Tests
{
    public class Tests
    {
        ProductService service;

        [SetUp]
        public void Setup()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"https://fakestoreapi.com/");

            service = new ProductService(client);

            
        }

        [Test]
        public async Task GetProducts()
        {
            var products = await service.GetProductsAsync();
            Assert.IsNotNull(products);
            Assert.IsNotEmpty(products);
            Assert.AreEqual(20, products.Count);
        }
    }
}