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
                Notes = item.Notes
            };
        }
    }
}