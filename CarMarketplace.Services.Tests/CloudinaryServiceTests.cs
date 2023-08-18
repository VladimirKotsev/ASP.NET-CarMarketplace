namespace CarMarketplace.Services.Tests
{
    using CarMarketplace.Services.Data;
    using CloudinaryDotNet.Actions;
    using CloudinaryDotNet;

    public class CloudinaryServiceTests
    {
        private const string TestCloudName = "carmarketplace";
        private const string TestApiKey = "346246877944179";
        private const string TestApiSecret = "OROAt0knDKaQI2OLLIr6Fikxi5I";

        [Test]
        public async Task UploadAsync_UploadSuccessful_ReturnsImageUrl()
        {
            var cloudinary = new Cloudinary(
                new Account(TestCloudName, TestApiKey, TestApiSecret)
            );

            var cloudinaryService = new CloudinaryService(cloudinary);

            using var testFile = File.OpenRead(@"C:\Users\Dekstop-8UU26MH\Pictures\Wallpapers\20513355.jpg");

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("test_image.jpg", testFile),
                PublicId = "testPublicId",
            };

            var result = await cloudinaryService.UploadAsync(uploadParams);

            Assert.NotNull(result.Url);
        }
    }
}
