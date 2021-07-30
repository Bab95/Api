using Api.Dtos;
using Api.Entities;
namespace Api
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                StartTime = item.StartTime,
                Duration = item.Duration,
                Note = item.Note
            };
        }
    }
}