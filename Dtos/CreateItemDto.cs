using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Id { get; init; }

        [Required]
        public string StartTime { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Note { set; get; }
    }
}