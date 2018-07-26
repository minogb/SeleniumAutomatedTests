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
        IWebElement SearchBar => Driver.FindElementByClassName("Searchbar-textInput");
        IWebElement SearchSubmit => Driver.FindElementByClassName("Searchbar-submitInput");

        //Posts. All elements related to posts visible on the front page. including sorting
        IEnumerable<IWebElement> Posts => Driver.FindElementsByClassName("Grid-column");
        IWebElement PauseGifsButton => Driver.FindElementByClassName("pause");
            //Elements in sorting posts
        IWebElement WatterFallSort => Driver.FindElementByClassName("waterfall");
        IWebElement UniformSort => Driver.FindElementByClassName("uniform");
            //These elements are poorly identified
        IWebElement SelectionTypeSpan => Driver.FindElementByClassName("NewCover-change-sort-wrapper section");
        IEnumerable<IWebElement> SortBySpan => Driver.FindElementsByClassName("NewCover-change-sort-wrapper").
                                                    Where(span => span.GetAttribute("class").Contains("section"));


    }
}
