using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories
{
    public interface IItemRepository
    {
        //to get all the notes of one single video
        Task<Item> GetItemAsync(string id);
        // to get all the notes of all the videos ever added....
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreteItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(string id);
    }
}