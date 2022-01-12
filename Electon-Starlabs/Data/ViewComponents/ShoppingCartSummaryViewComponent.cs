using Electon_Starlabs.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Data.ViewComponents
{

    public class ShoppingCartSummaryViewComponent : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummaryViewComponent(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);

        }
    }
}
