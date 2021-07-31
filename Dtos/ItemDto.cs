using System;
using System.Collections.Generic;
using Api.Entities;
namespace Api.Dtos
{
    public record ItemDto
    {
        public string Id{ get; init; }
        public List<Note> Notes{get;set;}
    }
}