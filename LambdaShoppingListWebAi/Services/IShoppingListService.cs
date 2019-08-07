using LambdaShoppingListWebAi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambdaShoppingListWebAi.Services
{
    public interface IShoppingListService
    {
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Guid itemId);
        Task<IEnumerable<Item>> FindAsync();
        Task<Item> GetByIdAsync(Guid id);
        Task<bool> AnyAsync(Func<Item, bool> predicate);
    }
}
