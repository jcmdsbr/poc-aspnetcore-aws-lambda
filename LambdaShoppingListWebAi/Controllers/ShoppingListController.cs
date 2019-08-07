using LambdaShoppingListWebAi.Models;
using LambdaShoppingListWebAi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambdaShoppingListWebAi.Controllers
{
    [Route("v1/shopping")]
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListService _service;

        public ShoppingListController(IShoppingListService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            return Ok(await _service.FindAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get([FromRoute]Guid id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> Post([FromBody]Item item)
        {
            await _service.AddAsync(item);
            return CreatedAtAction(nameof(Get), item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> Put([FromRoute]Guid id, [FromBody]Item item)
        {
            var isThereAnyItem = await _service.AnyAsync(x => x.Id == id);

            if (!isThereAnyItem)
            {
                return NotFound();
            }

            item.ChangeId(id);
            await _service.UpdateAsync(item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> Delete([FromRoute]Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

    }
}
