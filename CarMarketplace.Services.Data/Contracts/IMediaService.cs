namespace CarMarketplace.Services.Data.Contracts
{
    using Microsoft.AspNetCore.Http;

    public interface IMediaService
    {
        public Task<string> UploadPicture(IFormFile file, Guid name);
    }
}