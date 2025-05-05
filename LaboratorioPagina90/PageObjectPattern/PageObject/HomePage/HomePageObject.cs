using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratorioPagina90.PageObjectPattern.Helpers;
using OpenQA.Selenium;
using LaboratorioPagina90.PageObjectPattern.Models;


namespace LaboratorioPagina90.PageObjectPattern.PageObject.HomePage
{
    public class HomePageObject
    {
        private readonly IWebDriver driver; //definiendo el driver para las frutas que seran una lista
        //definios el constructor
        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        //para las frutas que seran una lista
        private List<IWebElement> DisplayedFruits => driver.FindElements(By.ClassName("fruit")).Where(fruit => fruit.Displayed).ToList();
        //para mostrar la lista de frutas      
        public PageBarWebElement PageNavegation => new PageBarWebElement(driver);

        public IList<FruitWebElement> DisplayedFruitWebElements()
        {
            return FruitHelper.Parse(DisplayedFruits);
        }
        // metod que muestre la lista de frutas
        public IList<FruitModel> DisplayedFruitModel() => FruitHelper.Parse(DisplayedFruitWebElements());

    }
}
