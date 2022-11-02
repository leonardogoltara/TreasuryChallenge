using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TreasuryChallengeNew.Lib;

namespace TreasuryChallengeNew.Test
{
    [TestClass]
    public class IOServicesTest
    {
        const string WriteFileWhenSuccessFilePath = "WriteFile_when_success.txt";
        const string AppendAllTextWhenSuccessFilePath = "AppendAllText_when_success.txt";
        const string DeleteFileWhenSuccessFilePath = "DeleteFile_when_success.txt";
        const string ExistsFileWhenSuccessFilePath = "ExistsFile_when_success.txt";

        [TestCleanup]
        public void CleanUp()
        {
            if (File.Exists(WriteFileWhenSuccessFilePath))
                File.Delete(WriteFileWhenSuccessFilePath);

            if (File.Exists(AppendAllTextWhenSuccessFilePath))
                File.Delete(AppendAllTextWhenSuccessFilePath);

            if (File.Exists(DeleteFileWhenSuccessFilePath))
                File.Delete(DeleteFileWhenSuccessFilePath);

            if (File.Exists(ExistsFileWhenSuccessFilePath))
                File.Delete(ExistsFileWhenSuccessFilePath);
        }

        [TestInitialize]
        public void Initialize()
        {
            CleanUp();
        }

        [TestMethod]
        public void WriteFile_when_success()
        {
            // Arrange
            string content = "1234";

            // Act
            IOServices.WriteFile(content, WriteFileWhenSuccessFilePath);

            // Assert
            Assert.IsTrue(File.Exists(WriteFileWhenSuccessFilePath));
        }

        [TestMethod]
        public void AppendAllText_when_success()
        {
            // Arrange
            string content = "5678";

            // Act
            IOServices.AppendAllText(content, AppendAllTextWhenSuccessFilePath);

            // Assert
            Assert.IsTrue(File.Exists(AppendAllTextWhenSuccessFilePath));
            var fileContent = File.ReadAllText(AppendAllTextWhenSuccessFilePath);
            Assert.AreEqual(content, fileContent);
        }

        [TestMethod]
        public void DeleteFile_when_success()
        {
            // Arrange
            File.WriteAllText(DeleteFileWhenSuccessFilePath, "teste");

            // Act
            IOServices.DeleteFile(DeleteFileWhenSuccessFilePath);

            // Assert
            Assert.IsFalse(File.Exists(DeleteFileWhenSuccessFilePath));
        }

        [TestMethod]
        public void ExistsFile_when_success()
        {
            // Arrange
            File.WriteAllText(ExistsFileWhenSuccessFilePath, "teste");

            // Act
            bool exists = IOServices.ExistsFile(ExistsFileWhenSuccessFilePath);

            // Assert
            Assert.AreEqual(exists, File.Exists(ExistsFileWhenSuccessFilePath));
        }
    }
}
