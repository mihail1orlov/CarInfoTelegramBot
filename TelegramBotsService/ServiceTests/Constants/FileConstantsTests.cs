﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Constants;

namespace ServiceTests.Constants
{
    [TestClass]
    public class FileConstantsTests
    {
        private FileConstants _target;

        [TestInitialize]
        public void Init()
        {
            _target = new FileConstants();
        }

        [TestMethod]
        public void ConfigJsonTest()
        {
            var actual = _target.ConfigJson;
            Assert.AreEqual("config.json", actual);
        }
    }
}