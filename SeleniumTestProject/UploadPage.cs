using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SeleniumTestProject
{
    public class UploadPage : Page
    {
        public UploadPage(ChromeDriver driver) : base(driver){
            ExpectedUrl = "upload";
            PageTitle = "Upload Page";
            SelfAssertErrorMessage = "Not on " + PageTitle;
            PrintLoadingCurrent();
        }
        //Main Body
        public IWebElement BrowseButton => Driver.FindElementByClassName("browse-btn");
        public IWebElement DragAndDropArea => Driver.FindElementByClassName("drag-drop-box");
        public IWebElement PasteUrlTextArea => Driver.FindElementByClassName("paste-url");
        //Lower third
        public IWebElement OptionContainer => Driver.FindElementById("bottom-apps-container");
        public IWebElement MemeGenButton => OptionContainer.FindElement(By.XPath("//a[text()='Meme Gen']"));
        public IWebElement VidToGifButton => OptionContainer.FindElement(By.XPath("//a[text()='Video to Gif']"));
        public IWebElement BrowseUploadsButton => OptionContainer.FindElement(By.XPath("//a[text()='Browse my Imgur Uploads']"));
        //Other
        public IWebElement Module => Driver.FindElementById("upload-modal");
        public IWebElement CloseButton => Module.FindElement(By.ClassName("icon-x"));

        public override void RunBaseTests()
        {
            base.RunBaseTests();

            Console.WriteLine("Upload page base checks");

            Console.WriteLine("module/exit button elements checks");
            Assert.IsTrue(Module.Displayed, "Main module not visible");
            Assert.IsTrue(CloseButton.Displayed, "close button not visible");

            Assert.IsTrue(BrowseButton.Displayed, "Browse button not visible");
            Assert.IsTrue(DragAndDropArea.Displayed, "Drag and drop area not visible");
            Assert.IsTrue(PasteUrlTextArea.Displayed, "Paseturl text area not visible");

            Console.WriteLine("checking lower third elements");
            Assert.IsTrue(OptionContainer.Displayed, "Meme gen button not visible");
            Assert.IsTrue(VidToGifButton.Displayed, "Vid to gif button not visible");
            Assert.IsTrue(BrowseUploadsButton.Displayed, "Browse uploads not visible");
        }
    }
}
