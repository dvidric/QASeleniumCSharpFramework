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

            ProductsPage productsPage = loginPage.ValidLogin(username, password);
            productsPage.WaitForProductPageToDisplay();

            productsPage.AddProductsToCart(expectedProducts);
            Thread.Sleep(1500);
            CheckOutPage checkoutPage = productsPage.GoToCheckOut();

            for (int i = 0; i < checkoutPage.GetCheckOutCards().Count(); i++)
            {
                actualProducts[i] = checkoutPage.GetCheckOutCards()[i];

            }

            Assert.AreEqual(expectedProducts, actualProducts);
            PhotoCommercePage photoCommercePage = checkoutPage.ProceedCheckOut();
            photoCommercePage.ChooseCountry("India");
            photoCommercePage.ClickOnAgreeTerms();
            photoCommercePage.ClickOnPurchase();
            Assert.IsTrue(photoCommercePage.CheckAlertText("Success"));


        }
        [Test, Category("dragana")]
        public void TestSample()
        {
            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productsPage = loginPage.ValidLogin("rahulshettyacademy", "learning");
            productsPage.WaitForProductPageToDisplay();

            productsPage.AddProductsToCart(expectedProducts);
            CheckOutPage checkoutPage = productsPage.GoToCheckOut();

            for (int i = 0; i < checkoutPage.GetCheckOutCards().Count(); i++)
            {
                actualProducts[i] = checkoutPage.GetCheckOutCards()[i];

            }

            Assert.AreEqual(expectedProducts, actualProducts);
            PhotoCommercePage photoCommercePage = checkoutPage.ProceedCheckOut();
            photoCommercePage.ChooseCountry("India");
            photoCommercePage.ClickOnAgreeTerms();
            photoCommercePage.ClickOnPurchase();
            Assert.IsTrue(photoCommercePage.CheckAlertText("Success"));


        }

        public static IEnumerable<TestCaseData>AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("wrong_username"), getDataParser().extractData("wrong_password"), getDataParser().extractDataArray("products"));
  

        }
    }
}
