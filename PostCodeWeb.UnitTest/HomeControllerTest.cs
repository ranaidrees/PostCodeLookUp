using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using JustEatDataAccess;
using JustEatDataAccess.DataAccess;
using JustEatDataAccess.Models;
using JustEatWeb.Common;
using JustEatWeb.Controllers;
using JustEatWeb.ViewModels;
using Moq;
using NUnit.Framework;

namespace JustEatWeb.UnitTest
{
    [TestFixture]
    public class HomeControllerTest
    { 
        [Test]
        [TestCase("ig", "Please enter a full, valid postcode")]
        [TestCase("", "Please enter a postcode")]
        [TestCase(null, "Please enter a postcode")]
        [TestCase("12345678999999999999999999999999999999999999999", "Please enter a full, valid postcode")]
        public void InvalidPostCode(string input, string expectedResult)
        {
            var results = ValidationCheck(input);
            Assert.IsTrue(results.Any(vr => vr.ErrorMessage == expectedResult));
        }
        [Test]
        [TestCase("Ig1 2pa")]
        [TestCase("Ig11 8pg")]
        public void ValidPostCode(string input)
        {
            var results = ValidationCheck(input);
            Assert.AreEqual(0,results.Count);
        }

        [Test]
        public void IndexAction()
        {
            // Arrange
            AutoMapperWebConfiguration.ConfigureWebMapping();
            var mockDataReader = new Mock<IDataReader>();
         var vmMock = new Mock<PostCodeResultVm>();
            vmMock.Object.Postcode = "RM1 3RL";
            PostCodeResult postCodeData = new PostCodeResult {};
            postCodeData.result = new Result
            {
                admin_county = "Essex",
                admin_district = "Romford",
                admin_ward = "Loxford",
                codes = new Codes() {admin_district = "11"}
            };
            mockDataReader.Setup(x => x.GetPostCodeResults(It.IsAny<String>())).ReturnsAsync(postCodeData);

            //Act
            var homeController = new HomeController(mockDataReader.Object);
            var indexView = homeController.Index(vmMock.Object);

            // Assert
            var result = indexView.Result as ViewResult;
            Assert.IsNotNull(result);
            var model = (PostCodeResultVm)result.Model;
            Assert.AreEqual(model.Codes.admin_district, "11");
            Assert.AreEqual(model.Admin_Ward, "Loxford");

        }
        /// <summary>
        /// Data annotation validation check
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ValidationResult> ValidationCheck(string input)
        {
            var postCodeResultVm = new PostCodeResultVm();
            var context = new ValidationContext(postCodeResultVm, null, null);
            var results = new List<ValidationResult>();
            postCodeResultVm.Postcode = input;
            Validator.TryValidateObject(postCodeResultVm, context, results, true);
            return results;
           
        }
    }
}
