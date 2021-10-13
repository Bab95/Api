using System;
using System.Collections.Generic;
using Api.Entities;
using Microsoft.AspNetCore.Http;

namespace Api.Dtos
{
    public record ImageDto
    {
        public string id{ get; set; }
        public List<IFormFile> images{get;set;}
    }
}