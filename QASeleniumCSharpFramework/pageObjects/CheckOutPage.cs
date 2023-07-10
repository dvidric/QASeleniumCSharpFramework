using OpenQA.Selenium;
using QASeleniumCSharpFramework.utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumCSharpFramework.pageObjects
{
    public class CheckOutPage: Base
    {
        IWebDriver driver;
        public CheckOutPage(IWebDriver driver) 
        { 
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //IList<IWebElement> chechoutCards = driver.FindElements(By.CssSelector("h4 a"));

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkOutCards;

        //driver.FindElement(By.CssSelector(".btn-success")).Click();

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkOut;

        public IList<IWebElement> getCheckOutCards()
        {
            return checkOutCards;
        }

        public PhotoCommercePage proceedCheckOut()
        {
            checkOut.Click();
            return new PhotoCommercePage(driver);
        }
    }
}
