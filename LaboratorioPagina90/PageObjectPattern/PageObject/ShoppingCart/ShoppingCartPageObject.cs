using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LaboratorioPagina90.PageObjectPattern.PageObject.ShoppingCart
{
    public class ShoppingCartPageObject
    {
        private readonly IWebDriver driver;

        private IWebElement TotalPrice => driver.FindElement(By.Id("totalPrice"));
        private IWebElement ButtonClose => driver.FindElement(By.Id("CloseCart"));
        private List<IWebElement> CartItems => driver.FindElements(By.ClassName("cart-item")).ToList();
        private IEnumerable<CartItemWebElement> CartItemWebElements => CartItems.Select(item => new CartItemWebElement(item));

        public ShoppingCartPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickButtonClose() => ButtonClose.Click();
        public decimal GetTotalPrice() => decimal.Parse(TotalPrice.Text);


    }
}
