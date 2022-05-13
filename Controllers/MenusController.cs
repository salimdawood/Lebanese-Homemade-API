using LebaneseHomemade.Data.Service;
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

        // GET api/<MenusController>/5
        [HttpGet("{id}")]
        public List<ItemModel> Get(int id)
        {
            return _menuService.getMenuOfCard(id);
        }
    }
}
