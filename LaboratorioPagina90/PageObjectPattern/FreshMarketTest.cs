using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Framework.Constraints.Tolerance;
using NUnit.Framework.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using LaboratorioPagina90.PageObjectPattern.PageObject.HomePage;
using OpenQA.Selenium.BiDi.Modules.Input;
using FluentAssertions;
using LaboratorioPagina90.PageObjectPattern.Models;


namespace LaboratorioPagina90.PageObjectPattern
{
    public class FreshMarketTests
    {
#pragma warning disable NUnit1032
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Url = "https://curso.testautomation.es/FruitVegetablesShopWeb/index.html";
        }
        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }
        [Test]
        public void VerifyThatFruitsAreCorrectlyDisplayed()
        {
            var homePage = new HomePageObject(driver); // crea una instancia de la pagina principal
            
            var result = new List<FruitModel>();
            
            result.AddRange(homePage.DisplayedFruitModel()); //con esto se obtienen 12 frutas de la page y se inserta
            
            //para los otros rangos de frutas
            
            result.AddRange(homePage.PageNavegation.ClickButtonPage2().DisplayedFruitModel());
            
            result.AddRange(homePage.PageNavegation.ClickButtonPage3().DisplayedFruitModel());
            

            var expectedFruits = new List<FruitModel>
            {   //28 en total, repartidos 12-12-4 
                new FruitModel("Apple", 2.50M, "Crispy and delicious apples from the orchard."),
                new FruitModel("Banana", 1.00M, "Sweet and ripe bananas for a healthy snack."),
                new FruitModel("Orange", 1.50M, "Fresh and juicy oranges for a Vitamin C boost."),
                new FruitModel("Pear", 2.00M, "Sweet and juicy pears for a delightful taste."),
                new FruitModel("Strawberry", 3.00M, "Red and juicy strawberries for a sweet treat."),
                new FruitModel("Carrot", 1.20M, "Fresh and crunchy carrots for a healthy snack."),
                new FruitModel("Grape", 2.80M, "Sweet and delicious grapes for a refreshing taste."),
                new FruitModel("Watermelon", 0.80M, "Juicy and refreshing watermelon for hot days."),
                new FruitModel("Cherry", 2.70M, "Sweet and vibrant cherries for a delightful taste."),
                new FruitModel("Pumpkin", 1.80M, "Fresh and hearty pumpkin for a variety of recipes."),
                new FruitModel("Broccoli", 1.80M, "Fresh and nutritious broccoli for a healthy diet."),
                new FruitModel("Pineapple", 3.00M, "Sweet and tropical pineapples for a refreshing snack."), 
                new FruitModel("Cucumber", 0.80M, "Crisp and refreshing cucumbers for salads and snacks."),
                new FruitModel("Potato", 1.20M, "Versatile and delicious potatoes for various dishes."),
                new FruitModel("Lemon", 2.00M, "Zesty and tangy lemons for cooking and beverages."),
                new FruitModel("Onion", 1.50M, "Flavorful and aromatic onions for cooking."),
                new FruitModel("Peach", 2.20M, "Sweet and juicy peaches for a delightful summer treat."),
                new FruitModel("Cabbage", 1.30M, "Crisp and crunchy cabbage for salads and coleslaw."),
                new FruitModel("Grapefruit", 2.40M, "Tangy and refreshing grapefruits for a healthy start."),
                new FruitModel("Kiwi", 3.20M, "Green and tangy kiwis for a tropical twist."),
                new FruitModel("Tomato", 1.60M, "Plump and juicy tomatoes for salads and sauces."),
                new FruitModel("Cantaloupe", 1.90M, "Sweet and aromatic cantaloupes for a refreshing treat."),
                new FruitModel("Avocado", 2.80M, "Creamy and nutritious avocados for salads and guacamole."),
                new FruitModel("Mango", 2.70M, "Exotic and sweet mangoes for a tropical delight."), 
                new FruitModel("Raspberry", 3.50M, "Delicate and flavorful raspberries for desserts and snacking."),
                new FruitModel("Pomegranate", 4.00M, "Juicy and antioxidant-rich pomegranates for health-conscious individuals."),
                new FruitModel("Blackberry", 2.80M, "Sweet and juicy blackberries for desserts and smoothies."),
                new FruitModel("Cranberry", 3.20M, "Tart and antioxidant-packed cranberries for holiday dishes."), 
                };

            //para comprar los valores cargados de la pagina contra lo que tenemos:
            result.Should().BeEquivalentTo(expectedFruits);
        }
    }
}