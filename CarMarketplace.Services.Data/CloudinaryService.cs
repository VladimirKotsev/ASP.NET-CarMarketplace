namespace CarMarketplace.Services.Data
{
    using CloudinaryDotNet.Actions;
    using CloudinaryDotNet;

    public class CloudinaryService
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
