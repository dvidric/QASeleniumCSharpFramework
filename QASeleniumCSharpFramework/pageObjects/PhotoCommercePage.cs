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
    public class PhotoCommercePage: BasePage
    {

        public PhotoCommercePage(IWebDriver driver) : base(driver) { }
        private readonly By _country = By.Id("country");
        private readonly By _agreeTermsAndCond = By.CssSelector("label[for*='checkbox2']");
        private readonly By _purchase = By.CssSelector("[value='Purchase']");
        private readonly By _alertText = By.CssSelector(".alert-success");
        private readonly By _photoCommerceHomeButton = By.XPath("//a[contains(text(),'ProtoCommerce Home')]");

        private By loc_country(string country)
        {
            return By.LinkText($"{country}");
        }

        public Boolean CheckAlertText(string checkValue)
        {
            return CheckElementText(_alertText, TimeSpan.MinValue, checkValue);
        }

        public void ChooseCountry(string country)
        {
            By loc = loc_country(country);
            Type(_country, TimeSpan.MinValue, country);
            Click(loc_country(country), TimeSpan.FromSeconds(12), false);
        }

        public void ClickOnAgreeTerms()
        {
            Click(_agreeTermsAndCond, TimeSpan.MinValue, false);
        }

        public void ClickOnPurchase()
        {
            Click(_purchase, TimeSpan.MinValue, false);
        }





        public AngularPracticePage ProceedToAngularPracticePage()
        {
            Click(_photoCommerceHomeButton, TimeSpan.MinValue, true);
            return new AngularPracticePage(driver);

        }

    }
    
}
