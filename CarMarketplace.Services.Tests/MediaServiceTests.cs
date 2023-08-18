namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Services.Data.Contracts;
    using CarMarketplace.Services.Data;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Moq;

    public class MediaServiceTests
    {
        [Test]
        public async Task UploadPictureAsync_Success()
        {

            var cloudinaryServiceMock = new Mock<ICloudinaryService>();
            cloudinaryServiceMock.Setup(service => service.UploadAsync(It.IsAny<ImageUploadParams>()))
                .ReturnsAsync(new ImageUploadResult() { Url = new Uri("https://example.com/image.jpg") });

            var mediaService = new MediaService(cloudinaryServiceMock.Object);

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(file => file.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            var result = await mediaService.UploadPictureAsync(formFileMock.Object, Guid.Parse("9fd9dd7c-cd8c-4775-ba07-073a4acfc3c3"));


            Assert.AreEqual("https://example.com/image.jpg", result);
        }

        [Test]
        public async Task UploadPictureAsync_FileTooBig_ThrowsException()
        {

            var cloudinaryServiceMock = new Mock<ICloudinaryService>();
            cloudinaryServiceMock.Setup(service => service.UploadAsync(It.IsAny<ImageUploadParams>()))
                .ReturnsAsync(new ImageUploadResult() { Error = new Error() });

            var mediaService = new MediaService(cloudinaryServiceMock.Object);

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(file => file.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            Assert.ThrowsAsync<InvalidOperationException>(
                () => mediaService.UploadPictureAsync(formFileMock.Object, Guid.Parse("9fd9dd7c-cd8c-4775-ba07-073a4acfc3c3")));
        }
    }
}
