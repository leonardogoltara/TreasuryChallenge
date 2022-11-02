using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TreasuryChallengeNew.Lib;

namespace TreasuryChallengeNew.Test
{
    [TestClass]
    public class RunnerTest
    {
        [TestCleanup]
        public void CleanUp()
        {
            File.Delete(Runner.FilePath);
        }

        [TestInitialize]
        public void Initialize()
        {
            CleanUp();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(33)]
        [DataRow(55)]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        [DataRow(100000)]
        [DataRow(300000)]
        [DataRow(1000000)]
        [DataRow(10000000)]
        public void Run(int quantity)
        {

            // Act
            Runner.Run(quantity);


            // Assert
            Assert.IsTrue(File.Exists(Runner.FilePath));
            var fileLines = File.ReadAllLines(Runner.FilePath);
            Assert.AreEqual(quantity, fileLines.Length);
            foreach (var line in fileLines)
            {
                Assert.AreEqual(Runner.CodeLength, line.Length);
            }
        }

    }
}
