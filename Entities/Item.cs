using System;
using System.Collections.Generic;
namespace Api.Entities
{
    public record Item
    {
        public string Id{ get; init; }

        public List<Note> Notes{get;set;}
    }
}