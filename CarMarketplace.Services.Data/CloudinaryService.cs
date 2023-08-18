namespace CarMarketplace.Services.Data
{
    using CloudinaryDotNet.Actions;
    using CloudinaryDotNet;

    using CarMarketplace.Services.Data.Contracts;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<ImageUploadResult> UploadAsync(ImageUploadParams parameters)
        {
            return await cloudinary.UploadAsync(parameters);
        }
    }
}
