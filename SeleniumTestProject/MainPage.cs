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
    public class MainPage : Page
    {


        public MainPage(ChromeDriver driver) : base(driver){
            PageTitle = "Main Page";
            SelfAssertErrorMessage = "Not on " + PageTitle;
            PrintLoadingCurrent();
        }

        //Search. All elements related to searching
        public IWebElement SearchBar => Driver.FindElementByClassName("Searchbar-textInput");
        public IWebElement SearchSubmit => Driver.FindElementByClassName("Searchbar-submitInput");

        //Posts. All elements related to posts visible on the front page. including sorting
        public IEnumerable<IWebElement> Posts => Driver.FindElementsByClassName("Grid-column");
        public IWebElement PauseGifsButton => Driver.FindElementByClassName("pause");
        //Elements in sorting posts
        public IWebElement WatterFallSort => Driver.FindElementByClassName("waterfall");
        public IWebElement UniformSort => Driver.FindElementByClassName("uniform");
        //These elements are poorly identified
        public IWebElement SelectionTypeSpan => Driver.FindElementByClassName("NewCover-change-sort-wrapper section");
        public IEnumerable<IWebElement> SortBySpan => Driver.FindElementsByClassName("NewCover-change-sort-wrapper").
                                                    Where(span => span.GetAttribute("class").Contains("section"));
        public IWebElement TakeMeUpButton => Driver.FindElementByClassName("ButtonBackToTop");

        public override void RunBaseTests()
        {
            base.RunBaseTests();

        }

    }
}
