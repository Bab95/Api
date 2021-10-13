using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories
{
    public interface IImageRepository
    {
        Task<ImageData> GetImageAsyc(string id);
        Task<IEnumerable<ImageData>> GetImagesAsync();
        Task CreteImageAsync(ImageData item);
        Task UpdateImageAsync(ImageData item);
        Task DeleteImageAsync(string id);
    }
}