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
    public class ProductsPage: BasePage
    {

        public ProductsPage(IWebDriver driver) : base(driver) { }

        private readonly By _productCards = By.XPath("//h4[@class='card-title']");
        private readonly By _checkOutButton = By.XPath("//a[contains(text(),'Checkout')]");
        private readonly By _photoCommerce = By.XPath("//a[contains(text(),'ProtoCommerce Home')]");
        private readonly By _html = By.XPath("//body");

        private By AddToCartSpecificProductLoc(string productName)
        {
            return By.XPath($"//a[contains(text(),'{productName}')]/ancestor::div[contains(@class,'card h')]/descendant::div/button[contains(text(),'Add')]");
        }

        public void WaitForProductPageToDisplay()
        {

            WaitForElementToBecomeVisible(_photoCommerce, TimeSpan.MinValue);
        }



        public string[] GetProductCards()
        {
            return GetElementsText(_productCards, TimeSpan.MinValue); 
        }

        public void AddProductsToCart(String[] expectedProducts)
        {

            string[] products = GetProductCards();


            foreach (string product in products)
            {
               
                if (expectedProducts.Contains(product))
                {
                    Click(AddToCartSpecificProductLoc(product), TimeSpan.MinValue, false);
                }

            }
        }

        public CheckOutPage GoToCheckOut()
        {
            Click(_checkOutButton, TimeSpan.FromSeconds(10), true);
            return new CheckOutPage(driver);
        }

    }
}
