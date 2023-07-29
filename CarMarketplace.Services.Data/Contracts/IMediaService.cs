namespace CarMarketplace.Services.Data.Contracts
{
    public interface IMediaService
    {
        public Task<string> UploadPicture(string path);
    }
}