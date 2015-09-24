using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDemoApp.Controllers;
using System.Collections.Generic;
using System.Linq;
using MyDemoApp.Logic.Models;
using System.Web.Mvc;
using MyDemoApp.Entities;
using PagedList;
using MyDemoApp.Models.Views;

namespace MyDemoApp.Test
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrenge
            var fakeRepository  = new FakeRespository();
            fakeRepository.AddSet(TestData.GetEmployees());

            // Act
            EmployeeController obj = new EmployeeController(new FakeServiceFactory(fakeRepository));
            var result = obj.Index() as ViewResult;
            var model = result.Model as IPagedList<EmployeeViewModel>;

            // Assert
            Assert.AreEqual(model.PageSize, 20);
        }
    }
}
