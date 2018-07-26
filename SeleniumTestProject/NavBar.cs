using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class NavBar : Page
    {

        public NavBar(ChromeDriver driver) : base(driver){
            PageTitle = "navigation bar";
            SelfAssertErrorMessage = "Not on " + PageTitle;
            PrintLoadingCurrent();
        }

        //Always on
        public IWebElement NewPostButton => Driver.FindElementByClassName("upload");
        public IWebElement TopCommentsButton => Driver.FindElementByClassName("leaderboard");
        public IWebElement HomeButton => Driver.FindElementByClassName("Navbar-logo-container");

        //Logged out buttons
        public IWebElement LoginButton => Driver.FindElementByClassName("Navbar-signin");
        public IWebElement SignUpButton => Driver.FindElementByClassName("Navbar-signup");

        //Must be logged in
        public IWebElement MessagesButton => Driver.FindElementByClassName("NavbarMessageButton");
        public IWebElement NotificationsButton => Driver.FindElementByClassName("NotificationsDropdown");
        public IWebElement UserDropDown => Driver.FindElementByClassName("NavbarUserMenu");
            //User Menu options
        protected IEnumerable<IWebElement> UserDropDownOptions => Driver.FindElementByClassName("NavbarUserMenu").
                                                            FindElements(By.ClassName("Dropdown-option"));
        public IWebElement PostsButton => UserDropDownOptions.Where(option => option.Text.Contains("Posts")).First();
        public IWebElement FavoritesButton => UserDropDownOptions.Where(option => option.Text.Contains("Favorites")).First();
        public IWebElement CommentsButton => UserDropDownOptions.Where(option => option.Text.Contains("Comments")).First();
        public IWebElement AboutButton => UserDropDownOptions.Where(option => option.Text.Contains("About")).First();
        public IWebElement ImagesButton => UserDropDownOptions.Where(option => option.Text.Contains("Images")).First();
        public IWebElement AlbumsButton => UserDropDownOptions.Where(option => option.Text.Contains("Albums")).First();
        public IWebElement SettingsButton => UserDropDownOptions.Where(option => option.Text.Contains("Settings")).First();
        public IWebElement SignOutButton => UserDropDownOptions.Where(option => option.Text.Contains("Sign Out")).First();

        /// <summary>
        /// Attempts to log out
        /// </summary>
        /// <returns>false if failed to logout, not if already logged out</returns>
        public bool LogOut()
        {
            Console.WriteLine("Logging out  if can");
            try
            {
                if (IsLoggedIn())
                    return true;
                WebDriverWait wait = TestingConfig.GetWaitDriver(Driver);
                UserDropDown.Click();
                wait.Until(dr => SignOutButton);
                SignOutButton.Click();
                wait.Until(dr => HomeButton);
                HomeButton.Click();
                wait.Until(dr => LoginButton);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Cannot log out");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Attempts to log in
        /// </summary>
        /// <returns>false if failed to log in, not if already logged in</returns>
        public bool LogIn()
        {
            Console.WriteLine("Logging in  if can");
            WebDriverWait wait = TestingConfig.GetWaitDriver(Driver);
            try
            {
                //if we are logged in we are done
                if (IsLoggedOut())
                    return false;
                LoginButton.Click();

                LogInPage loginpage = new LogInPage(Driver);

                Console.WriteLine("Navigating to login page");
                wait.Until(dr => loginpage.LogoButton);
                loginpage.LogIn();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// tests to see if we are logged out
        /// </summary>
        /// <returns>test by if we can click message button, log out button is obfuscated</returns>
        public bool IsLoggedOut()
        {
            try
            {
                return MessagesButton.Displayed;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// tests to see if we are logged in
        /// </summary>
        /// <returns>test by if we can click log in</returns>
        public bool IsLoggedIn()
        {
            try
            {
                return LoginButton.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Unlike other pages NavBar can exist anywhere
        /// execpt in unique cases. so just test for if
        /// Our home button is displayed
        /// </summary>
        /// <returns></returns>
        public override bool IsThis(){
            return HomeButton.Displayed;
        }

        public override void AssertPage(){
            Assert.IsTrue(IsThis(), "No nav bar avaliable");
        }
        public override void RunBaseTests()
        {
            base.RunBaseTests();

            Console.WriteLine("nav bar base tests");

            Console.WriteLine("Allways on buttons");
            Assert.IsTrue(NewPostButton.Displayed, "New post button not visible");
            Assert.IsTrue(TopCommentsButton.Displayed, "top comments button not visible");
            Assert.IsTrue(HomeButton.Displayed, "Home button not visible");

            LogOut();
            Console.WriteLine("Is logged out buttons not visible");
            Assert.IsTrue(LoginButton.Displayed, "loggin button not visible");
            Assert.IsTrue(SignUpButton.Displayed, "signup button not visible");

            LogIn();

            Console.WriteLine("Is Logged in buttons not visible");
            Assert.IsTrue(MessagesButton.Displayed, "Messages button not visible");
            Assert.IsTrue(NotificationsButton.Displayed, "Notifications button not visible");
            Assert.IsTrue(UserDropDown.Displayed, "user options dropdown button not visible");

            WebDriverWait wait = TestingConfig.GetWaitDriver(Driver);
            UserDropDown.Click();
            wait.Until(dr => PostsButton.Displayed);
            Assert.IsTrue(PostsButton.Displayed, "User posts button not visible");
            Assert.IsTrue(FavoritesButton.Displayed, "User favorites button not visible");
            Assert.IsTrue(CommentsButton.Displayed, "Comments button not visible");
            Assert.IsTrue(AboutButton.Displayed, "About button not visible");
            Assert.IsTrue(ImagesButton.Displayed, "Images button not visible");
            Assert.IsTrue(AlbumsButton.Displayed, "Albums button not visible");
            Assert.IsTrue(SettingsButton.Displayed, "settings button not visible");
            Assert.IsTrue(SignOutButton.Displayed, "Signout button not visible");
        }
    }
}
