using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    class Program
    {
        ChromeDriver driver;
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://www.imgur.com");
        }
        [Test]
        public void MainPageTests()
        {
            MainPage MainPage = new MainPage(driver);
            MainPage.RunBaseTests();
        }

        [Test]
        public void NavBarTest()
        {
            NavBar NavBar = new NavBar(driver);
            NavBar.RunBaseTests();
        }
        [Test]
        public void UploadTests()
        {
            UploadPage NavBar = new UploadPage(driver);
            NavBar.RunBaseTests();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
