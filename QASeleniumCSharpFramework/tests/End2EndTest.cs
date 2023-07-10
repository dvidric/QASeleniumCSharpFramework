using OpenQA.Selenium;
using QASeleniumCSharpFramework.pageObjects;
using QASeleniumCSharpFramework.utilities;
using NUnit.Framework;
using System.Collections;

namespace QASeleniumCSharpFramework.tests
{


    public class End2EndTest : Base
    {

        [Test, Property("Priority", 1), Category("CategoryA")]
        [TestCaseSource(nameof(AddTestDataConfig))]
        [Parallelizable(ParallelScope.All)]
        public void E2EFlow(string username, string password, string[] expectedProducts)
        {
            //string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productsPage = loginPage.validLogin(username, password);
            productsPage.waitForPageToDisplay();

            IList<IWebElement> products = productsPage.getCards();


            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productsPage.getCardTitle()).Text))
                {
                    product.FindElement(productsPage.getAddToCart()).Click();
                }

            }
            CheckOutPage checkoutPage = productsPage.checkOut();

            for (int i = 0; i < checkoutPage.getCheckOutCards().Count; i++)
            {
                actualProducts[i] = checkoutPage.getCheckOutCards()[i].Text;

            }

            Assert.AreEqual(expectedProducts, actualProducts);
            PhotoCommercePage photoCommercePage = checkoutPage.proceedCheckOut();
            photoCommercePage.getCountry().SendKeys("Ind");
            photoCommercePage.waitForFullNameCountry();
            photoCommercePage.getindiaOption().Click();
            photoCommercePage.getAgreeTermsAndCond().Click();
            photoCommercePage.getPurchase().Click();
            string confirmText = photoCommercePage.getAlertText().Text;
            StringAssert.Contains("Success", confirmText);


        }
        [Test, Category("Dragana")]
        public void TestSample()
        {
            string[] expectedProducts = { "Samsung Note 8", "Nokia Edge" };
            string[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productsPage = loginPage.validLogin("rahulshettyacademy", "learning");
            productsPage.waitForPageToDisplay();

            IList<IWebElement> products = productsPage.getCards();


            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productsPage.getCardTitle()).Text))
                {
                    product.FindElement(productsPage.getAddToCart()).Click();
                }

            }
            CheckOutPage checkoutPage = productsPage.checkOut();

            for (int i = 0; i < checkoutPage.getCheckOutCards().Count; i++)
            {
                actualProducts[i] = checkoutPage.getCheckOutCards()[i].Text;

            }

            Assert.AreEqual(expectedProducts, actualProducts);
            PhotoCommercePage photoCommercePage = checkoutPage.proceedCheckOut();
            photoCommercePage.getCountry().SendKeys("Ind");
            photoCommercePage.waitForFullNameCountry();
            photoCommercePage.getindiaOption().Click();
            photoCommercePage.getAgreeTermsAndCond().Click();
            photoCommercePage.getPurchase().Click();
            string confirmText = photoCommercePage.getAlertText().Text;
            StringAssert.Contains("Success", confirmText);


        }

        public static IEnumerable<TestCaseData>AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("wrong_username"), getDataParser().extractData("wrong_password"), getDataParser().extractDataArray("products"));
  

        }
    }
}
