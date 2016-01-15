using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JustEatWeb.SystemTest
{
    [TestFixture]
    public class HomePage
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private const int Delay = 2;
       
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = ConfigurationManager.AppSettings["NavigateUrl"]; ;
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void InsertValidPostCode()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Delay));
            driver.FindElement(By.Id("OutCode")).Clear();
            driver.FindElement(By.Id("OutCode")).SendKeys("Ig1 2pa");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Delay));
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Delay));
            Assert.AreEqual("Just Eat - My ASP.NET Application", driver.Title);
            Assert.IsTrue(IsElementPresent(By.CssSelector("strong")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-rounded")));
        }
        [Test]
        public void FindaTakeAwayaWithoutInsertingPostCode()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            Assert.AreEqual("Please enter a postcode", driver.FindElement(By.CssSelector("span.text-danger.field-validation-error > span")).Text);

        }
        [Test]
        public void FindaTakeAwayWithInvalidPostCode()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("OutCode")).Clear();
            driver.FindElement(By.Id("OutCode")).SendKeys("Ig11 234e");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            Assert.AreEqual("Please enter a full, valid postcode", driver.FindElement(By.CssSelector("span.text-danger.field-validation-error > span")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        
    }

   

}
