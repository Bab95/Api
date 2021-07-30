using System;

namespace Api.Entities
{
    public record Item
    {
        public string Id{ get; init; }
        public float StartTime { get; set; }
        public float Duration { get; set; }
        public string Note { get; set; }
    }
}