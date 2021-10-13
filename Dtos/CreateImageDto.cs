using System;
using System.ComponentModel.DataAnnotations;
using Api.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Api.Dtos
{
    public class CreateImageDto
    {
        [Required]
        public string id {get;set;}

        [Required]
        public List<IFormFile> images{get;set;}
    }
}