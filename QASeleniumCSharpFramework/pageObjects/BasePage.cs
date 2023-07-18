using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QASeleniumCSharpFramework.pageObjects
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver) { this.driver = driver; }


        protected IWebElement WaitForElementToBecomeVisible(By locator, TimeSpan timeOut)
        {
            try
            {
                if (timeOut == TimeSpan.MinValue) { timeOut= TimeSpan.FromSeconds(10); }
                return  new WebDriverWait(driver, timeOut).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch
            {
                throw new Exception($"Couldn't find element with locator: {locator} , for time period of: {timeOut} seconds");
            }
        }
        
         protected IWebElement WaitForElementPresenceInDOM(By locator, TimeSpan timeOut)
        {
            try
            {
                if (timeOut == TimeSpan.MinValue) { timeOut = TimeSpan.FromSeconds(10); }
                return new WebDriverWait(driver, timeOut).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch
            {
                throw new Exception($"Couldn't find element with locator: {locator} , for time period of: {timeOut} seconds");
            }


        }

        protected void ScrollTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");
        }

        protected void ScrollBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        protected void Zoom(string zoom)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"document.body.style.zoom='{zoom}'");
        }

        protected IWebElement WaitForElementToBecomeClickable(By locator, TimeSpan timeOut)
        {
            try
            {
                if (timeOut == TimeSpan.MinValue) { timeOut = TimeSpan.FromSeconds(10); }
                return new WebDriverWait(driver, timeOut).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch
            {
                throw new Exception($"Couldn't find element with locator: {locator} , for time period of: {timeOut} seconds");
            }


        }

        protected Boolean CheckElementText(By locator, TimeSpan timeOut, String text)
        {
            try
            {
                if (timeOut == TimeSpan.MinValue) { timeOut = TimeSpan.FromSeconds(10); }
                Boolean temp =  new WebDriverWait(driver, timeOut).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text));
                return true;

            }
            catch
            {
                return false;
            }
        }

        protected string[] GetElementsText(By locator, TimeSpan timeOut) 
        {
            IList<IWebElement> elements = WaitForElementsToBeVisible(locator, timeOut);
            string[] texts = new string[elements.Count];
            int i = 0;
            foreach (IWebElement element in elements)
            {
                texts[i++]=element.Text;
                
            }
            return texts;
        
        }

        protected string GetElementText(By locator, TimeSpan timeOut)  
        {
            return WaitForElementToBecomeVisible(locator, timeOut).Text;
        }

        protected string GetElementAttribute(By locator, TimeSpan timeOut, String attribute)
        {
            return WaitForElementToBecomeVisible(locator, timeOut).GetAttribute(attribute);

        }

        protected void Click(By locator, TimeSpan timeOut, Boolean scroll) 
        {
            IWebElement element = WaitForElementPresenceInDOM(locator, timeOut);

            if (scroll ==  true) { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", element); }
            WaitForElementToBecomeClickable(locator, timeOut).Click();
        }

        protected void Type(By locator, TimeSpan timeOut, String text)
        {

            WaitForElementToBecomeVisible(locator, timeOut).Clear();
            WaitForElementToBecomeVisible(locator, timeOut).SendKeys(text);
        }

        protected Boolean ElementIsDisplayed(By locator, TimeSpan timeOut) 
        {
            try
            {
                return WaitForElementToBecomeVisible(locator, timeOut).Displayed;
            }
            catch { return false; }
        
        } 

        protected void Visit(String url) => driver.Url = url;

        protected IList<IWebElement> WaitForElementsToBeVisible(By locator, TimeSpan timeOut)
        {
            try
            {
                if (timeOut == TimeSpan.MinValue) { timeOut = TimeSpan.FromSeconds(10); }
                return new WebDriverWait(driver, timeOut).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
            }
            catch
            {
                throw new Exception($"Couldn't find elements with locator: {locator} , for time period of: {timeOut} seconds");
            }

        }


    }
    
}
