using System;

namespace Api.Entities
{
    public record Item
    {
        public string Id{ get; init; }
        public string StartTime { get; init; }
        public int Duration { get; set; }
        public string Note { get; set; }
    }
}