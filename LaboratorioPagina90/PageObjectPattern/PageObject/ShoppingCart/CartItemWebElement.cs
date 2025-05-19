﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace LaboratorioPagina90.PageObjectPattern.PageObject.ShoppingCart
{
    public class CartItemWebElement
    {
        private IWebElement element;
        private IWebElement ButtonRemove => element.FindElement(By.CssSelector("button"));
        private IWebElement InfoText => element.FindElement(By.CssSelector("span"));
        private IWebElement InputFieldQuantity => element.FindElement(By.CssSelector("input"));

        public CartItemWebElement(IWebElement element)
        {
            this.element = element;
        }

        public void ClickButtonRemove() => ButtonRemove.Click();
        public string GetText() => InfoText.Text;
        public void InputQuantity(int quantity)
        {
            InputFieldQuantity.Clear();
            InputFieldQuantity.SendKeys(quantity.ToString());
            InputFieldQuantity.SendKeys(Keys.Tab);
        }
        public int GetQuantity() => int.Parse(InputFieldQuantity.GetAttribute("value"));
    }
}
