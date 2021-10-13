using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Repositories;
using Api.Entities;
using System;
using Api.Dtos;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace Api.Controllers
{
    [ApiController]
    [Route("images")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository repository;
        public ImageController(IImageRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ImageDto>> GetImagesAsync()
        {
            var images = (await repository.GetImagesAsync()).Select( image => image.AsImageDto());
            return images;
        }

        [HttpGet]
        public async Task<ActionResult<ImageDto>> GetImageAsync(string id)
        {
            var images = await repository.GetImageAsyc(id);
            if (images is null)
            {
                return NotFound();
            }
            return images.AsImageDto();
        }
        [HttpPost]
        public async Task<ActionResult<string>> CreateImageAsync(CreateImageDto createImageDto)
        {
            string path = @"C:\Users\babnishvyas\Documents\Work_Space\fhl\Backend\Api";
            var existingImages = await repository.GetImageAsyc(createImageDto.id);
            if (existingImages is null)
            {
                try
                {
                    if (!Directory.Exists(Path.Combine(path, "uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(path, "uploads"));
                    }
                    for(int i=0;i < createImageDto.images.Count;i++){
                        using (FileStream fileStream = System.IO.File.Create(Path.Combine(path, "uploads",createImageDto.id)))
                        {
                            createImageDto.images[i].CopyTo(fileStream);
                            fileStream.Flush();
                            return Path.Combine(path, "upload", "aresfssac");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return "unsuccessful";
        }

    }
}