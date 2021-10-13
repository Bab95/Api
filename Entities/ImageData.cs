using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace  Api.Entities
{
    public record ImageData
    {
        public string id{get;set;}
        public List<IFormFile> images;
    }
}