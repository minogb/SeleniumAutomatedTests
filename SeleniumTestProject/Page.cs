using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SeleniumTestProject
{
    public class Page
    {
        protected readonly ChromeDriver Driver;
        protected readonly string BaseUrl = "https://imgur.com/";

        public Page(ChromeDriver driver) {
            Driver = driver;
            ExpectedUrl = "";
            SelfAssertErrorMessage = "Not on " + PageTitle;
        }

        /// <summary>
        /// The epected url of the current page
        /// Sometimes used for IsThis()
        /// </summary>
        protected string ExpectedUrl;

        /// <summary>
        /// The unoffical title of the page. for debuging
        /// </summary>
        protected string PageTitle;

        /// <summary>
        /// Error message for not being on the right page
        /// </summary>
        protected string SelfAssertErrorMessage;

        /// <summary>
        /// Print to output that we are loading current
        /// </summary>
        public void PrintLoadingCurrent(){
            Console.WriteLine("Loading " + PageTitle);
        }

        /// <summary>
        /// Is the current page actually this page.
        /// Like home page, upload page ect.
        /// </summary>
        /// <returns>if we are the correct page</returns>
        public virtual bool IsThis() {
            return Driver.Url.Substring(BaseUrl.Length).Equals(ExpectedUrl);
        }

        /// <summary>
        /// Assert if we are not on the correct page
        /// </summary>
        public virtual void AssertPage() {
            Assert.IsTrue(IsThis(), SelfAssertErrorMessage);
        }
        /// <summary>
        /// Run generic tests for this page.
        /// Like are these features here?
        /// Features themeselves should be tested
        /// in isolation
        /// </summary>
        public virtual void RunBaseTests()
        {
            AssertPage();
            Console.WriteLine("Loaded page");
        }
    }
}
