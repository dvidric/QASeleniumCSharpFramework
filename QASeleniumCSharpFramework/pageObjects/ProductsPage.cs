using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QASeleniumCSharpFramework.utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumCSharpFramework.pageObjects
{
    public class ProductsPage: Base
    {
        IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        By addToCart = By.CssSelector(".card-footer button");

        public ProductsPage(IWebDriver driver) 
        { 
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;


        //By.PartialLinkText("Checkout")

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkOutButton;

        public void waitForPageToDisplay()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'ProtoCommerce Home')]")));
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getCardTitle()
        {
            return cardTitle;
        }
        public By getAddToCart()
        {
            return addToCart;
        }
        public CheckOutPage checkOut()
        {
            checkOutButton.Click();
            return new CheckOutPage(driver);
        }

    }
}
