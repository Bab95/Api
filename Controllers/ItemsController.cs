using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Repositories;
using Api.Entities;
using System;
using Api.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace Api.Controllers
{
    //GET /items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository repository;

        private readonly ILogger<ItemsController> logger;
        public ItemsController(IItemRepository repository, ILogger<ItemsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        // GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())
                                                .Select( item => item.AsDto());
            
            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {items.Count()} notes");

            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(string id)
        {
            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        // POST /items 
        [HttpPost]
        public async Task<ActionResult<ItemDto> > CreateItemAsync(CreateItemDto createItemDto)
        {
            var existingVideo = await repository.GetItemAsync(createItemDto.Id);

            if(existingVideo is null)
            {
                Item item1= new()
                {
                    Id = createItemDto.Id,
                    Notes = createItemDto.Notes
                };
                await repository.CreteItemAsync(item1);
                return CreatedAtAction(nameof(GetItemAsync), new {id = item1.Id}, item1.AsDto());
            }
            await repository.DeleteItemAsync(createItemDto.Id);
            List<Note> NotesList = existingVideo.Notes;
            NotesList.AddRange(createItemDto.Notes);
            Item updatedNotesObject = existingVideo with {
                Notes = NotesList
            };
            await repository.CreteItemAsync(updatedNotesObject);
            return CreatedAtAction(nameof(GetItemAsync), new {id = updatedNotesObject.Id}, updatedNotesObject.AsDto());
        }

        //PUT /items/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(string id, UpdateItemDto updateItemDto)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            /*
                todo:
                won't work properly need to write may be need to change routing as
                we want to update {id/noteid} or somehow pass note in the method and get and update
                in the list...
                            */
            Item updatedItem = existingItem with{
                Notes = updateItemDto.Notes
            };
            await repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }

        // DELETE /items/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(string id)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            await repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}