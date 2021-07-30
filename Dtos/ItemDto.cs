using System;

namespace Api.Dtos
{
    public record ItemDto
    {
        public string Id{ get; init; }
        public float StartTime { get; init; }
        public float Duration { get; set; }
        public string Note { get; set; }
    }
}