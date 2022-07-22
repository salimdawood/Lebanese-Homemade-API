using LebaneseHomemade.Data.Service;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
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
    public class MenusController : ControllerBase
    {
        private readonly MenuService _menuService;
        public MenusController(MenuService menuService)
        {
            _menuService = menuService;
        }
        //// GET api/<MenusController>/5
        //[HttpGet("{id}")]
        //public MenuModel Get([FromRoute] int id)
        //{
        //    return _menuService.GetMenuOfCard(id);
        //}
        // Update api/<MenusController>/5
        [HttpPut("{id}")]
        public int Put([FromRoute]int id,[FromBody] List<ItemListViewModel> itemListViewModels)
        {
            return _menuService.UpdateMenuOfCard(id, itemListViewModels);
        }
        // Delete api/<MenusController>/5
        [HttpDelete("{id}")]
        public int Delete([FromRoute]int id)
        {
            return _menuService.DeleteMenuOfCard(id);
        }
    }
}
