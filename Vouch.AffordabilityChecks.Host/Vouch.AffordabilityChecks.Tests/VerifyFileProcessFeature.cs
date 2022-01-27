using System.IO;
using System.Linq;
using Vouch.AffordabilityChecks.Service;
using Xunit;

namespace Vouch.AffordabilityChecks.Tests
{
    public class VerifyFileProcessFeature
    {
        [Fact]
        public void RunFileProcessShouldReturnNullWhenThereAreNoFiles()
        {
            //Arrange
            IFileService  fileService = new FileService();

            //Act
            var feed = fileService.ReadFeed(Directory.GetCurrentDirectory());

            //Assert
            Assert.Null(feed);
        }

        [Fact]
        public void RunFileProcessShouldReturnProperties()
        {
            //Arrange
            IFileService fileService = new TestableFileService();

            //Act
            var feed = fileService.ReadFeed($"{Directory.GetCurrentDirectory()}/files");

            //Assert
            Assert.True(feed.BankStatements.Any());
            Assert.True(feed.Properties.Any());
        }

        [Fact]
        public void RunFileProcessShouldReturnNullWhenThereIsNoFilesDirectory()
        {
            //Arrange
            IFileService fileService = new FileService();

            //Act
            var feed = fileService.ReadFeed($"{Directory.GetCurrentDirectory()}/filestemp");

            //Assert
            Assert.Null(feed);
        }
    }
}
