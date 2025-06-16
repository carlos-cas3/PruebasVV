using System;
using OpenQA.Selenium;
using LaboratorioPagina90.PageObjectPattern.Factories;

namespace LaboratorioPagina90.PageObjectPattern.Helpers
{
    public class UITestContext : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public UITestContext()
        {
            // Validar configuración cargada
            if (TestBase.TestSettings == null)
            {
                throw new InvalidOperationException("TestSettings no ha sido inicializado. Asegúrate de ejecutar TestBase.OneTimeSetup.");
            }

            if (string.IsNullOrWhiteSpace(TestBase.TestSettings.Browser))
            {
                throw new InvalidOperationException("El valor de 'Browser' en TestSettings no puede ser nulo o vacío.");
            }

            // Crear instancia del navegador
            Driver = WebDriverFactory.GetWebDriver(TestBase.TestSettings.Browser.ToLower());

            // Configuración general del navegador
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TestBase.TestSettings.WaitTimeout);
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
