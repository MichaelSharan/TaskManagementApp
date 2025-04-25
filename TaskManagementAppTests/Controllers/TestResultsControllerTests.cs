using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagementApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using TaskManagementApp.Data;

namespace TaskManagementApp.Controllers.Tests
{
    [TestClass()]
    public class TestResultsControllerTests
    {
        private TestResultsController _controller;
        private Mock<ApplicationDbContext> _mockContext;
        private Mock<DbSet<TaskManagementApp.Models.TestResult>> _mockSet;

        [TestInitialize]
        public void Setup()
        {
            _mockSet = new Mock<DbSet<TaskManagementApp.Models.TestResult>>();
            _mockContext = new Mock<ApplicationDbContext>();

            _mockContext.Setup(c => c.TestResults).Returns(_mockSet.Object);

            _controller = new TestResultsController(_mockContext.Object, null);
        }

        [TestMethod]
        public async Task GetTestResult_ReturnsNotFound_WhenTestResultDoesNotExist()
        {
            // Arrange
            _mockSet.Setup(m => m.Find("notfound"))
                .Returns((TaskManagementApp.Models.TestResult)null);

            // Act
            var result = await _controller.GetTestResult("notfound");

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}