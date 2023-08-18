namespace CarMarketplace.Services.Data
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    using CarMarketplace.Services.Data.Contracts;
    using Microsoft.AspNetCore.Http;

    public class MediaService : IMediaService
    {
        private readonly ICloudinaryService cloudinary;

        public MediaService(ICloudinaryService cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadPictureAsync(IFormFile file, Guid name)
        {
            byte[] destinationImage;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            destinationImage = memoryStream.ToArray();

            using var destinationStream = new MemoryStream(destinationImage);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name.ToString(), destinationStream),
                PublicId = name.ToString(),
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);

            if (result.Error != null)
            {
                throw new InvalidOperationException("The file is too big. Choose a file which is less then 10.4 mb");
            }

            return result.Url.AbsoluteUri;
        }
    }
}
