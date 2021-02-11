using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Service;

namespace TestAppUnitTest.Service
{
    [TestClass]
    public class IntervalServiceTest
    {
        private IntervalService intervalService;

        [TestInitialize]
        public void InitTest()
        {
            intervalService = new IntervalService();
        }

        [TestMethod]
        public void CheckInputStringIsEmptyNoExceptionTriggered()
        {           
            var retVal = intervalService.CheckInput(string.Empty);

            Assert.IsFalse(retVal);
        }

        [TestMethod]
        public void CheckInputStringIsNullNoExceptionTriggered()
        {
            var retVal = intervalService.CheckInput(null);

            Assert.IsFalse(retVal);
        }

        //[TestMethod]
        //public void CheckInputStringIsWrongNoExceptionTriggered()
        //{
        //    var retVal = intervalService.CheckInput("[z,9]");

        //    Assert.IsFalse(retVal);
        //}

        [TestMethod]
        public void CheckInputStringIsCorrect()
        {
            var retVal = intervalService.CheckInput("[1,9]");

            Assert.IsTrue(retVal);
        }

        [TestMethod]
        public void GetListOfIntervalsStringIsEmptyNoExceptionTriggered()
        {
            var retVal = intervalService.GetListOfIntervals(string.Empty).ToList();

            Assert.IsNotNull(retVal);
            Assert.AreEqual(0, retVal.Count);
        }

        [TestMethod]
        public void GetListOfIntervalsStringIsNullNoExceptionTriggered()
        {
            var retVal = intervalService.GetListOfIntervals(null).ToList();

            Assert.IsNotNull(retVal);
            Assert.AreEqual(0, retVal.Count);
        }

        [TestMethod]
        public void GetListOfIntervals()
        {
            var retVal = intervalService.GetListOfIntervals("[1,9]").ToList();

            Assert.IsNotNull(retVal);
            Assert.AreEqual(1, retVal.Count);
        }

        [TestMethod]
        public void GetListOfIntervals_2()
        {
            var retVal = intervalService.GetListOfIntervals("[1,9][10,19]").ToList();

            Assert.IsNotNull(retVal);
            Assert.AreEqual(2, retVal.Count);
        }

        [TestMethod]
        public void GetListOfIntervals_3()
        {
            var retVal = intervalService.GetListOfIntervals("[1,9][2,10]").ToList();

            Assert.IsNotNull(retVal);
            Assert.AreEqual(1, retVal.Count);
            Assert.AreEqual(1, retVal.First().NumberOne);
            Assert.AreEqual(10, retVal.First().NumberTwo);
        }
    }
}
