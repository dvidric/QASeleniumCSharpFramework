using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumCSharpFramework.pageObjects
{   
    public class LoginPage: BasePage

    {
        
        public LoginPage(IWebDriver driver): base (driver) { }

        private readonly By _username = By.Id("username");
        private readonly By _password = By.Id("password");
        private readonly By _checkBox = By.XPath("//input[@id='terms']");
        private readonly By _signInButton = By.XPath("//input[@id='signInBtn']");

        public ProductsPage ValidLogin(string user, string pass)
        {
            Type(_username, TimeSpan.MinValue, user);
            Type(_password, TimeSpan.MinValue, pass);
            Click(_checkBox, TimeSpan.MinValue, false);
            Click(_signInButton, TimeSpan.MinValue, false);
            return new ProductsPage(driver);

        }
    }
    


    
}
