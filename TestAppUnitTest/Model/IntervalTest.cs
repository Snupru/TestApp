using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Model;

namespace TestAppUnitTest.Model
{
    [TestClass]
    public class IntervalTest
    {
        [TestMethod]
        public void IntervalStrinIsEmptyNoExceptionTriggered()
        {
            var test = new Interval(string.Empty);

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void IntervalStrinIsNullNoExceptionTriggered()
        {
            var test = new Interval(null);

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void IntervalStrinIsWronNoExceptionTriggered()
        {
            var test = new Interval("b,3");

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void IntervalGenerated()
        {
            var test = new Interval("1,3");

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.NumberOne);
            Assert.AreEqual(3, test.NumberTwo);
        }

        [TestMethod]
        public void IntervalGenerated_2()
        {
            var test = new Interval(1, 3);

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.NumberOne);
            Assert.AreEqual(3, test.NumberTwo);
        }

        [TestMethod]
        public void GetIntervalAsString()
        {
            var test = new Interval("1,3");

            Assert.AreEqual("[1,3]", test.GetIntervalAsString());
        }
    }
}
