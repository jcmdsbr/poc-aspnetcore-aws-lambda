using LambdaShoppingListWebAi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingListWebAi.Services
{
    public class ShoppingListServiceHandler : IShoppingListService
    {
        private readonly List<Item> _repository = new List<Item>();
        public async Task AddAsync(Item item)
        {
            await Task.Run(() => _repository.Add(item));
        }

        public async Task<bool> AnyAsync(Func<Item, bool> predicate)
        {
            return await Task.FromResult(_repository.Any(predicate));
        }

        public async Task DeleteAsync(Guid itemId)
        {
            await Task.Run(() => _repository.RemoveAll(x => x.Id == itemId));
        }

        public async Task<IEnumerable<Item>> FindAsync()
        {
            return await Task.FromResult(_repository);
        }

        public async Task<Item> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_repository.SingleOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(Item item)
        {
            await Task.Run(() =>
            {
                var index = _repository.FindIndex(x => x.Id == item.Id);
                _repository[index] = item;
            });
        }
    }
}
