﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratorioPagina90.PageObjectPattern.Helpers;
using OpenQA.Selenium;

//Barra de navegacion
namespace LaboratorioPagina90.PageObjectPattern.PageObject.HomePage
{
    public class PageBarWebElement
    {
        private readonly IWebDriver driver;
        //el constructor de la clase
        public PageBarWebElement(IWebDriver driver)
        {
            this.driver = driver;
        }

        //necesitamos definir los botones de navegacion entre paginas
        private IWebElement ButtonPage1 => driver.FindElement(By.Id("page1Button"));
        private IWebElement ButtonPage2 => driver.FindElement(By.Id("page2Button"));
        private IWebElement ButtonPage3 => driver.FindElement(By.Id("page3Button"));

        // Acciones sobre los botones
        public HomePageObject ClickButtonPage1()
        {
            ButtonPage1.Click();
            return new HomePageObject(driver);
        }
        public HomePageObject ClickButtonPage2()
        {
            ButtonPage2.Click();
            return new HomePageObject(driver);
        }
        public HomePageObject ClickButtonPage3()
        {
            ButtonPage3.Click();
            return new HomePageObject(driver);
        }
    }
}
