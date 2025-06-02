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
using LaboratorioPagina90.PageObjectPattern.Helpers;


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


        [Test]
        public void SearchTests()
        {
            var homepage = new HomePageObject(driver); // nos retorna la pagina

            var foundFruits = homepage.SearchBar
                .InputSearch("app")
                .ClickSearch()
                .DisplayedFruitModel();

            foundFruits.Count.Should().Be(2); //segun la condicion debe retornar solo 2 

            // para obtener los nombres
            var foundFruitsName = foundFruits.Select(fruit => fruit.Name).ToList();
            var expectFruitName = new[] { "Pineapple", "Apple" };
            foundFruitsName.Should().BeEquivalentTo(expectFruitName); // compara los valores


            //para el test2
            var foundFruits2 = homepage.SearchBar
                .InputSearch(string.Empty)
                .ClickSearch()
                .DisplayedFruitModel()
                .Count.Should().Be(12);


            //para el test3 que es similar al 1

            var foundFruits3 = homepage.SearchBar
                .InputSearch("ape")
                .ClickEnter()
                .DisplayedFruitModel();

            var expectFruitName2 = new[] { "Grape", "Grapefruit" };
            foundFruits3.Select(fruit => fruit.Name).Should().BeEquivalentTo(expectFruitName2);
        }

        [Test]
        public void ShoppingCartTest()
        {
            //tarea 1. verificar que el icono de arriba es 0
            var homePage = new HomePageObject(driver);
            homePage.IsShoppingCartIconNumberOfItems(0).Should().BeTrue();
            var expectedFruitsInCart = new List<FruitModel>();
            var DisplayedFruits = () => homePage.DisplayedFruitWebElements();


            // Tarea 2: + 10apple, 6 bananas, 5 Avocado 1 Pomegranete.. vericar el icon de shopping = 4
            expectedFruitsInCart.Add(AddItemToCart(DisplayedFruits(), "Apple", 10));
            expectedFruitsInCart.Add(AddItemToCart(DisplayedFruits(), "Banana", 6));
            homePage.PageNavegation.ClickButtonPage2(); //estamos en pagina 2
            expectedFruitsInCart.Add(AddItemToCart(DisplayedFruits(), "Avocado", 5));
            homePage.PageNavegation.ClickButtonPage3(); //estamos en pagina 3
            expectedFruitsInCart.Add(AddItemToCart(DisplayedFruits(), "Pomegranate", 1));
            //para verificar que el carro tiene numero 4
            homePage.IsShoppingCartIconNumberOfItems(4).Should().BeTrue();



            //Test 3: Abrir el carro, verificar que tiene 4 elementos y sus valores son correctos
            var cart = homePage.ClickShoppingCartIcon(); //abre el carrito
            cart.CartItemWebElements.Count().Should().Be(4);
            
            var item = () => cart.CartItemWebElements;
            
            for (var i = 0; i < 4; i++)
            {
                var fruit = expectedFruitsInCart[i];
                item().ElementAt(i).GetText().Should().Be($"{fruit.Name} {fruit.Price} €/Kg");
                fruit.Quantity.Should().Be(item().ElementAt(i).GetQuantity());
            }
            //para porbar que los totales son iguales
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());
           
            //modificar el carrito
            
            item().ElementAt(3).ClickButtonRemove();// borra pomegranete
            
            homePage.IsShoppingCartIconNumberOfItems(3).Should().BeTrue(); //el numero del icon de carro es 3

            
            item().ElementAt(1).InputQuantity(3); // se actualiza bananas a 3 

            var totalPrice = cart.GetTotalPrice();
            var totalPriceFromItems = cart.GetTotalPriceFromItems();
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());
            cart.ClickButtonClose(); // clic sobre boton Close.
        }
        private FruitModel AddItemToCart(IList<FruitWebElement> displayedFruits, string fruitName, int quantity)
        {
            var fruitWebElement =
            displayedFruits.Single(fruit => fruit.Name.Equals(fruitName));
            fruitWebElement
                .InputQuantity(quantity)
                .ClickAddToCart();
            var fruitModel = FruitHelper.Parse(fruitWebElement);
            fruitModel.Quantity = quantity;
            return fruitModel;
        }

    }
}

