using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumCSharpFramework.pageObjects
{
    public class AngularPracticePage: BasePage
    {
        public AngularPracticePage(IWebDriver driver): base(driver) { }

        private readonly By _submit = By.XPath("//input[@type='submit']");

        public void ClickOnSubmitButton()
        {
            Click(_submit, TimeSpan.MinValue, true);

        }

    }
}
