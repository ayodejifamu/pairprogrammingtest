using Core.Service;
using Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestsXUnit.UnitTest
{
    public class productServiceTest
    {
        [Fact]

        async Task AddProductToCart() 
        {
            var product1 = new product()
            {
                productId = Guid.NewGuid().ToString(),
                productName = "A",
                price = 10,
            };

            var product2 = new product()
            {
                productId = Guid.NewGuid().ToString(),
                productName = "B",
                price = 20,
            };

            var productList = new List<product>();
            productList.Add(product1);
            productList.Add(product2);

            var productservice = new ProductService();

            var response = await productservice.AddProductToCart(productList);
            Assert.True(response.Item1);
        }

        [Fact]
        async Task GetTotalCartPrice()
        {
            var product1 = new product()
            {
                productId = Guid.NewGuid().ToString(),
                productName = "t-shirt",
                price = 10,
                quantity= 3
            };

            var product2 = new product()
            {
                productId = Guid.NewGuid().ToString(),
                productName = "Jeans",
                price = 20,
                quantity= 2
            };

            var productList = new List<product>();
            productList.Add(product1);
            productList.Add(product2);


            var productservice = new ProductService();

            var response = await productservice.AddProductToCart(productList);

            Assert.True(response.Item3 == 70);
        }

        [Fact]
        async Task GetCartPriceWithDiscoucnt()
        {
            var product1 = new product()
            {
                productId = Guid.NewGuid().ToString(),
                productName = "t-shirt",
                price = 10,
                quantity = 3
            };


            var product2 = new product()
            {
                productId = Guid.NewGuid().ToString(),
                productName = "Jeans",
                price = 20,
                quantity = 2
            };

            var productList = new List<product>();
            productList.Add(product1);
            productList.Add(product2);

            var productservice = new ProductService();

            var response = await productservice.AddProductToCart(productList);

            var cartTotalPrice = response.Item3;

            //Apply discount


        }
    }
}
