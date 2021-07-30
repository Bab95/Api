using System;

namespace Api.Dtos
{
    public record ItemDto
    {
        public string Id{ get; init; }
        public string StartTime { get; init; }
        public int Duration { get; set; }
        public string Note { get; set; }
    }
}