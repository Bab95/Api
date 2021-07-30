using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItemAsync(string id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreteItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(string id);
    }
}