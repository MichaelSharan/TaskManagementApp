using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass()]
    public class CountNumberServiceTests
    {
        private CountNumberService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new CountNumberService();
        }

        [TestMethod]
        [DataRow("1234", "4321")]
        [DataRow("4206", "NO")]
        [DataRow("", "NO")]
        [DataRow("   ", "NO")]
        [DataRow("111", "111")]
        [DataRow("100", "1")]
        [DataRow("9876543210", "9876543201")]
        [DataRow("0000", "NO")]
        [DataRow("7000", "7")]
        public void CalculateLargestOddNumberTest(string input, string expected)
        {
            // Act
            string result = _service.CalculateLargestOddNumber(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindLastOddDigitIndex_ReturnsCorrectIndex_WhenOddDigitExists()
        {
            // Arrange
            var digits = new List<char> { '2', '4', '7', '5', '8' };

            // Act
            var result = CountNumberService.FindLastOddDigitIndex(digits);

            // Assert
            Assert.AreEqual(3, result); // Последняя нечетная цифра '5' находится на индексе 3
        }

        [TestMethod]
        public void FindLastOddDigitIndex_ReturnsNegativeOne_WhenNoOddDigit()
        {
            // Arrange
            var digits = new List<char> { '2', '4', '6', '8' };

            // Act
            var result = CountNumberService.FindLastOddDigitIndex(digits);

            // Assert
            Assert.AreEqual(-1, result); // Нет нечетных цифр
        }
    }
}