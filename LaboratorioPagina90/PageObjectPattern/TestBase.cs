using LaboratorioPagina90.PageObjectPattern.Models;
using Microsoft.Extensions.Configuration;

namespace LaboratorioPagina90.PageObjectPattern
{
    [Parallelizable(ParallelScope.All)]
    public class TestBase
    {
        public static TestSettings TestSettings { get; set; }
        //esto hace que el atributo se ejecute una solo ves antes q todos los test
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            TestSettings = new TestSettings();
            if (!File.Exists("appsettings.json"))
                throw new FileNotFoundException("No se encontró appsettings.json en el directorio de ejecución.");

            var settings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true) // Ensure the namespace is included  
                .Build();
            var automationSettings = settings.GetSection("AutomationSettings");
            automationSettings.Bind(TestSettings);
        }
    }
}
