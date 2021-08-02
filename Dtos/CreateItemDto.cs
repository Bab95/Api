using System;
using System.ComponentModel.DataAnnotations;
using Api.Entities;
using System.Collections.Generic;
namespace Api.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Id { get; init; }

        [Required]
        public List<Note> Notes{get;set;}
    }
}