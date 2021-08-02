using System;

namespace Api.Entities
{
    public record Note
    {
        public string noteId{ get; init; }
        public float startTime{ get; set;}
        public float duration{get;set;}
        public string note {get;set;}

    }
}