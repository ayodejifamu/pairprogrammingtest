using Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ProductService
    {
        const string productOndiscount = "jeans";
        //Add product to cart
        public async Task<(bool, int, decimal)> AddProductToCart(List<product> value) 
        {
            decimal sumPrice = 0;
            if (value == null)
            {
                return (false, 0, 0);
            }

            var cart = new cart();

            var prodList = value;

            cart.products = prodList;

            foreach (var product in prodList) 
            {
                sumPrice = sumPrice + (product.price * product.quantity);
            }

            if (cart.products.Count() > 0)
            {
                return(true, cart.products.Count(), sumPrice);
            }
            return (false, 0, 0);
        }


        //apply discount
        public async Task<decimal> applyDiscount(cart value)
        {
            var newList = new List<product>();
            //select product on discount
            var productOnDiscount = value.products.Where(x => x.productName == productOndiscount).ToList();
            var remainingProduct = value.products.Where(x => x.productName != productOndiscount).ToList();

            //discount logic 
            for (int i = 0; i < productOnDiscount.Count(); i++)
            {
                if (productOnDiscount[i].quantity > 2)
                {
                    var rem = productOnDiscount[i].quantity % 2;
                    productOnDiscount[i].quantity = productOnDiscount[i].quantity - rem;
                    newList.Add(productOnDiscount[i]);
                }
                newList.Add(productOnDiscount[i]);
            }

            foreach (var item in newList)
            {
                remainingProduct.Add(item);
            }

            decimal newPrice = 0;
            foreach (var item in remainingProduct)
            {
                newPrice = newPrice * item.quantity;
            }
            
            return newPrice;
        }

        //Remove product fromm cart
    }
}
