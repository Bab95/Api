using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Api.Entities;

namespace Api.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string Id { get; init; }
        
        [Required]
        public List<Note> Notes{get;set;}
    }
}