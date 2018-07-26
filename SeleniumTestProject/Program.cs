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
            driver.Navigate().GoToUrl(TestingConfig.BaseUrl);
        }
        [Test]
        public void GenericMainPageTest()
        {
            MainPage MainPage = new MainPage(driver);
            MainPage.RunBaseTests();
        }

        [Test]
        public void GenericNavBarTest()
        {
            NavBar NavBar = new NavBar(driver);
            NavBar.RunBaseTests();
        }
        [Test]
        public void GenericUploadPageTests()
        {
            driver.Navigate().GoToUrl("https://imgur.com/upload");
            UploadPage NavBar = new UploadPage(driver);
            NavBar.RunBaseTests();
        }
        [Test]
        public void LogInAndOutTest()
        {
            NavBar navBar = new NavBar(driver);
            
            Assert.IsTrue(navBar.LogIn(), "Failed to log in");
            Assert.IsTrue(navBar.LogOut(), "Failed to log out");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
