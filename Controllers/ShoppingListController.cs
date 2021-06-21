
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
        public async Task<List<Item>> GetItems()
        {
            return await _shoppingListService.GetItemsAsync();
        }

       
        //GET: api/ShoppingList/1
        [HttpGet("{id}")]

        public async Task<Item> GetItem(int id)
        {
            return await _shoppingListService.GetItemAsync(id);
        }

        //POST: api/ShoppingList
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<bool> PostItem(Item item)
        {
            return await _shoppingListService.AddItemAsync(item);
        }

        //PUT: api/ShoppingList/1
        [HttpPut("{id}")]
        public async Task<bool> PutItem(int id, Item item)
        {
           return await _shoppingListService.UpdateItem(id, item);
        }

        //DELETE api/ShoppingList/1
        [HttpDelete("{id}")]
        public async Task<bool> DeleteItem(int id)
        {
            return await _shoppingListService.DeleteItem(id);
        }
       
    }
}