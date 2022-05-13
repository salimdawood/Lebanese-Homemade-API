using LebaneseHomemade.Data.Service;
using LebaneseHomemade.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LebaneseHomemade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }
        // POST api/<ItemsController>
        //[HttpPost]
        //public void Post(List<ItemWithMenuIdViewModel> itemWithMenuIdViewModel, int menuId)
        //{
        //    _itemService.AddItems(itemWithMenuIdViewModel, menuId);
        //}

        //// PUT api/<ItemsController>/5
        //[HttpPut("{id}")]
        //public void Put([FromBody] List<ItemViewModel> itemViewModel, int id)
        //{
        //    _itemService.UpdateItems(itemViewModel, id);
        //}

        //DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _itemService.DeleteItem(id);
        }
    }
}
