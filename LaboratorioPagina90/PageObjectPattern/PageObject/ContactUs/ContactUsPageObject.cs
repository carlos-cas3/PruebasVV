using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace LaboratorioPagina90.PageObjectPattern.PageObject.ContactUs
{
    public class ContactUsPageObject
    {
        private IWebDriver driver;
        //pripiedades
        private IWebElement InputFieldContactTitle =>
       driver.FindElement(By.Id("contactTitle"));
        private IWebElement InputFieldContactEmail =>
       driver.FindElement(By.Id("contactEmail"));
        private SelectElement DropdownCategory => new
       SelectElement(driver.FindElement(By.Id("contactCategory")));
        private IWebElement InputFieldContactText =>
       driver.FindElement(By.Id("contactText"));
        private IWebElement ButtonSubmit =>
       driver.FindElement(By.CssSelector("#contactForm button"));
        private IWebElement ButtonClose =>
       driver.FindElement(By.Id("closeContactPopup"));
        
        
        //definimos el constructor
        public ContactUsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickSumit() => ButtonSubmit.Click();


        //para los msg de error
        private IWebElement TitleErrorMessage =>
       driver.FindElement(By.Id("contactTitleError"));
        private IWebElement EmailErrorMessage =>
       driver.FindElement(By.Id("contactEmailError"));
        private IWebElement TextErrorMessage =>
       driver.FindElement(By.Id("contactTextError"));


        public void ClickSubmit() => ButtonSubmit.Click();
        //es un if compacto si existe error entonces el text caso contrario null
        public string? GetDisplayedTitleErrorMessage() =>
        TitleErrorMessage.Displayed ? TitleErrorMessage.Text : null;
        public string? GetDisplayedEmailErrorMessage() =>
        EmailErrorMessage.Displayed ? EmailErrorMessage.Text : null;
        public string? GetDisplayedTextErrorMessage() =>
        TextErrorMessage.Displayed ? TextErrorMessage.Text : null;

        public IEnumerable<string> GetCategoryOptions() => DropdownCategory.Options.Select(category => category.Text);

        // metodos para aniadir datos validos
        public ContactUsPageObject InputTextContactTitle(string title)
        {
            InputFieldContactTitle.Clear();
            InputFieldContactTitle.SendKeys(title);
            return this;
        }
        public ContactUsPageObject InputTextContactEmail(string email)
        {
            InputFieldContactEmail.Clear();
            InputFieldContactEmail.SendKeys(email);
            return this;
        }
        public ContactUsPageObject InputTextContactMessage(string message)
        {
            InputFieldContactText.Clear();
            InputFieldContactText.SendKeys(message);
            return this;
        }
        public ContactUsPageObject SelectCategory(string category)
        {
            DropdownCategory.SelectByText(category);
            return this;
        }

    }
}