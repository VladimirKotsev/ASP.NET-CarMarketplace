namespace CarMarketplace.Services.Data.Contracts
{
    using CloudinaryDotNet.Actions;

    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadAsync(ImageUploadParams parameters);
    }
}
