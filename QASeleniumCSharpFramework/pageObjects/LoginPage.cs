using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumCSharpFramework.pageObjects
{   
    public class LoginPage

    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // PageObject Factory design pattern
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@id='terms']")]
        private IWebElement checkBox;

        [FindsBy(How = How.XPath, Using = "//input[@id='signInBtn']")]
        private IWebElement signInButton;

        public ProductsPage validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();
            return new ProductsPage(driver);

        }

        public IWebElement getUserName()
        {
            return username;
        }
    }
    


    
}
