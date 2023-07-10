using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumCSharpFramework.pageObjects
{
    public class PhotoCommercePage
    {
        IWebDriver driver;
        public PhotoCommercePage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        //driver.FindElement(By.Id("country")).SendKeys("ind");
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;

        //driver.FindElement(By.LinkText("India")).Click();
        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement indiaOption;

        //driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement agreeTermsAndCond;

        //driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement purchase;

        //driver.FindElement(By.CssSelector(".alert-success"))
        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement alertText;


        public void waitForFullNameCountry() 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

        public IWebElement getCountry()
        {
            return country;
        }
        public IWebElement getindiaOption()
        {
            return indiaOption;
        }

        public IWebElement getAgreeTermsAndCond()
        {
            return agreeTermsAndCond;
        }

        public IWebElement getPurchase()
        {
            return purchase;
        }

        public IWebElement getAlertText()
        {
            return alertText;
        }

    }
    
}
