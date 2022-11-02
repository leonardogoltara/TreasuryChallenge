using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TreasuryChallengeNew.Lib;

namespace TreasuryChallengeNew.Test
{
    [TestClass]
    public class CodeGeneratorTest
    {

        [TestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(20)]
        public void GenerateCode(int length)
        {
            // Arrange
            string availableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Act
            var code = CodeGenerator.GenerateCode(length);

            // Assert
            Assert.AreEqual(length, code.Length);
            var codeCharArray = code.ToCharArray();
            foreach (var c in codeCharArray)
            {
                Assert.IsTrue(availableChars.Contains(c));
            }
        }
    }
}
