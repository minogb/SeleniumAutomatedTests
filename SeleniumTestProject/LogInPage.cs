using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
namespace SeleniumTestProject
{
    class LogInPage : Page
    {
        public LogInPage(ChromeDriver driver) : base(driver)
        {
            ExpectedUrl = "signin";
            PageTitle = "signin Page";
            SelfAssertErrorMessage = "Not on " + PageTitle;
            PrintLoadingCurrent();
        }
        //Navigation buttons
        public IWebElement BackToButton => Driver.FindElementById("backimgur");
        public IWebElement LogoButton => Driver.FindElementByClassName("signin-logo");

        //Alt loggin methods
        public IWebElement FacebookButton => Driver.FindElementByClassName("facebook");
        public IWebElement TwitterButton => Driver.FindElementByClassName("twitter");
        public IWebElement GooglePlusButton => Driver.FindElementByClassName("google");
        public IWebElement YahooButton => Driver.FindElementByClassName("yahoo");

        //Log in form
        public IWebElement UserNameField => Driver.FindElementByName("username");
        public IWebElement PasswordField => Driver.FindElementByName("password");
        public IWebElement ForgotButton => Driver.FindElementByClassName("forgot-password");
        public IWebElement CreateAccountButton => Driver.FindElementByClassName("signin-register-link");
        public IWebElement SignInButton => Driver.FindElementByName("submit");
        

        public NavBar LogIn()
        {
            Console.WriteLine("Performing login");
            NavBar retVal = new NavBar(Driver);

            Console.WriteLine("inputing user info");
            UserNameField.SendKeys(TestingConfig.Username);
            PasswordField.SendKeys(TestingConfig.Password);

            Console.WriteLine("submiting");
            SignInButton.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            //wait.Until(dr => retVal.MessagesButton);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("NavbarMessageButton")));
            return retVal;
        }
        public override void RunBaseTests()
        {
            base.RunBaseTests();

            Console.WriteLine("Log in page base checks");

            Console.WriteLine("Navigation button elements checks");
            Assert.IsTrue(BackToButton.Displayed, "back to imgur button not visible");
            Assert.IsTrue(LogoButton.Displayed, "Logo button not visible");


            Console.WriteLine("Alt login buttons elements checks");
            Assert.IsTrue(FacebookButton.Displayed, "Facebook button not visible");
            Assert.IsTrue(TwitterButton.Displayed, "Twitter button not visible");
            Assert.IsTrue(GooglePlusButton.Displayed, "Googleplus button not visible");
            Assert.IsTrue(YahooButton.Displayed, "Yahoo button not visible");

            Console.WriteLine("Normal login elements");
            Assert.IsTrue(UserNameField.Displayed, "username field not visible");
            Assert.IsTrue(PasswordField.Displayed, "password field not visible");
            Assert.IsTrue(CreateAccountButton.Displayed, "Create account button not visible");
            Assert.IsTrue(SignInButton.Displayed, "Sign in button not visible");
        }
    }
}
