namespace CarMarketplace.Services.Data
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    using CarMarketplace.Services.Data.Contracts;

    public class MediaService : IMediaService
    {
        private Cloudinary cloudinary;

        public MediaService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadPicture(string path)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(path),

            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            string url = uploadResult.Url.ToString();

            return url;
        }
    }
}
