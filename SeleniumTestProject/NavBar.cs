using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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
        public IWebElement TakeMeUpButton => Driver.FindElementByClassName("ButtonBackToTop");
        public IWebElement HomeButton => Driver.FindElementByClassName("Navbar-logo-container");

        //Logged out buttons
        public IWebElement LoginButton => Driver.FindElementByClassName("Navbar-signin");
        public IWebElement SignUpButton => Driver.FindElementByClassName("Navbar-signup");

        //Must be logged in
        public IWebElement MessagesButton => Driver.FindElementByClassName("NavbarMessageButton");
        public IWebElement NotificationsButton => Driver.FindElementByClassName("NotificationsDropdown");
        public IWebElement UserDropDown => Driver.FindElementByClassName("NavbarUserMenu");
            //User Menu options
        public IEnumerable<IWebElement> UserDropDownOptions => Driver.FindElementByClassName("NavbarUserMenu").
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

    }
}
