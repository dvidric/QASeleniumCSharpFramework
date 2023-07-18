using OpenQA.Selenium;
using QASeleniumCSharpFramework.helpers;
using QASeleniumCSharpFramework.utilities;
using RazorEngine.Templating;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace QASeleniumCSharpFramework.pageObjects
{
    public class CheckOutPage: BasePage
    {
        public CheckOutPage(IWebDriver driver): base(driver) { }

        private readonly By _checkOutCards = By.CssSelector("h4 a");
        private readonly By _table = By.ClassName("table");

        private readonly By _checkOut = By.XPath("//button[contains(text(),' Checkout ')]");

        public string [] GetCheckOutCards()
        {
            return GetElementsText(_checkOutCards, TimeSpan.MinValue);
        }

        public PhotoCommercePage ProceedCheckOut()
        {
            Click(_checkOut, TimeSpan.MinValue, true);
            return new PhotoCommercePage(driver);
        }

        public IWebElement GetTable()
        {
            return WaitForElementToBecomeVisible(_table, TimeSpan.MinValue);
        }

    }
}
