namespace CarMarketplace.Services.Data.Contracts
{
    using Microsoft.AspNetCore.Http;

    public interface IMediaService
    {
        public Task<string> UploadPictureAsync(IFormFile file, Guid name);
    }
}