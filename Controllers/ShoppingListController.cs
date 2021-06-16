
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private ShoppingListService _shoppingListService;

        public ShoppingListController(ShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        //GET: api/ShoppingList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _shoppingListService.GetItemsAsync();
        }

       
        //GET: api/ShoppingList/1
        [HttpGet("{id}")]

        public async Task<ActionResult<Item>> GetItem(int id)
        {
            return await _shoppingListService.GetItemAsync(id);
        }

        //POST: api/ShoppingList
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
           if(await _shoppingListService.AddItemAsync(item))
            {
                return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
            }
            return BadRequest();
        }

        //PUT: api/ShoppingList/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            await _shoppingListService.UpdateItem(id, item);
            return NoContent();
        }

        //DELETE api/ShoppingList/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (await _shoppingListService.DeleteItem(id))
                return NotFound();
            return NoContent();
        }
       
    }
}