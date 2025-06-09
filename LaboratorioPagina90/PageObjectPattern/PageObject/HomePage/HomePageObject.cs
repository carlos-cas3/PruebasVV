using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratorioPagina90.PageObjectPattern.Helpers;
using OpenQA.Selenium;
using LaboratorioPagina90.PageObjectPattern.Models;
using LaboratorioPagina90.PageObjectPattern.PageObject.ShoppingCart;
using LaboratorioPagina90.PageObjectPattern.PageObject.ContactUs;

//Pagina principal
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
        //Lista de frutas visibles
        private List<IWebElement> DisplayedFruits => driver.FindElements(By.ClassName("fruit")).Where(fruit => fruit.Displayed).ToList();
        //Para mostrar la lista de frutas      
        public PageBarWebElement PageNavegation => new PageBarWebElement(driver);

        public IList<FruitWebElement> DisplayedFruitWebElements()
        {
            return FruitHelper.Parse(DisplayedFruits);
        }
        // metod que muestre la lista de frutas
        public IList<FruitModel> DisplayedFruitModel() => FruitHelper.Parse(DisplayedFruitWebElements());


        // metodo para el segundo test 
        public SearchBarWebElement SearchBar => new SearchBarWebElement(driver);

        // metodo para el carrito de compras: TEST3
        private IWebElement ShoppingCartIcon => driver.FindElement(By.Id("cart-icon"));
        public int GetShoppingCartIconNumberOfItems() => int.Parse(ShoppingCartIcon.Text);
        
        //para abrir el carro de compras TEST 4
        public ShoppingCartPageObject ClickShoppingCartIcon()
        {
            ShoppingCartIcon.Click();
            return new ShoppingCartPageObject(driver);

        }

        public bool IsShoppingCartIconNumberOfItems(int number)
        {
            try
            {
                WaitHelper.WaitForCondition(() =>
               int.Parse(ShoppingCartIcon.Text).Equals(number));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //para el 4to test
        private IWebElement ButtonContactUs => driver.FindElement(By.Id("openContactPopup"));

        public ContactUsPageObject clickContactUs()
        {
            ButtonContactUs.Click();
            return new ContactUsPageObject(driver);
        }



    }
}
