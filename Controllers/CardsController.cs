using LebaneseHomemade.Data.Pagination;
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
    public class CardsController : ControllerBase
    {
        private readonly CardService _cardService;
        public CardsController(CardService cardService)
        {
            _cardService = cardService;
        }
        // GET: api/<CardsController>
        [HttpGet]
        public IActionResult Get([FromQuery] PaginationParameter paginationParameter)
        {
            var _cards = _cardService.GetCards(paginationParameter);
            return Ok(_cards);
        }
        // GET api/<CardsController>/GetCards?typeid=5
        [HttpGet("GetCards")]
        public IActionResult GetCardsOfType([FromQuery]int typeId)
        {
            var _cards = _cardService.GetCardsByTypeId(typeId);
            return Ok(_cards);
        }
        // GET api/<CardsController>/GetCards/5
        [HttpGet("GetCards/{id}")]
        public IActionResult GetCardsOfUser([FromRoute]int id)
        {
            var _cards = _cardService.GetCardsOfUser(id);
            return Ok(_cards);
        }
        // GET api/<CardsController>/5
        [HttpGet("{id}")]
        public CardViewModel GetCardsById([FromRoute] int id)
        {
            return _cardService.GetCardById(id);
        }
        // POST api/<CardsController>
        [HttpPost]
        public int Post([FromBody] AddCardViewModel addCardViewModel)
        {
             return _cardService.AddCard(addCardViewModel);
        }

        // PUT api/<CardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CardsController>/5
        [HttpDelete("{id}")]
        public int Delete([FromRoute]int id)
        {
            return _cardService.DeleteCard(id);
        }
    }
}
