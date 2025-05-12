using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LaboratorioPagina90.PageObjectPattern.PageObject.HomePage
{
    public class FruitWebElement
    {
   
        //trabajar sobre un IWebElement
        private readonly IWebElement fruitWebElement;
        public string Name => fruitWebElement.FindElement(By.TagName("h2")).Text;

        //ahora para el precio
        public string Price => fruitWebElement.FindElement(By.TagName("p")).Text;

        //para la descripcion
        public string Description => fruitWebElement.FindElements(By.TagName("p"))[1].Text;

        //definimos su constructor cuando se cree la variable fruitElement tenga un valor 
        public FruitWebElement(IWebElement fruitWebElement)
        {
            this.fruitWebElement = fruitWebElement;
        }

        // Selectores para el TEST 3: Quantity y Add to car
        private IWebElement InputFieldQuantity => fruitWebElement.FindElement(By.CssSelector("[id$='Quantity']"));
        //para el boton
        private IWebElement ButtonAddToCart => fruitWebElement.FindElement(By.CssSelector("button"));

        public void ClickAddToCart() => ButtonAddToCart.Click();

        public FruitWebElement InputQuantity(int quantity)
        {
            InputFieldQuantity.Clear();
            InputFieldQuantity.SendKeys(quantity.ToString());
            return this; 
        }
    }
}
