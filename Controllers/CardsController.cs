using LebaneseHomemade.Data.Pagination;
using LebaneseHomemade.Data.Service;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public CardModel GetCardsById([FromRoute] int id)
        {
            return _cardService.GetCardById(id);
        }
        // POST api/<CardsController>
        [HttpPost]
        public async Task<int> Post([FromForm] AddCardViewModel addCardViewModel)
        {
            //return addCardViewModel;
            return await _cardService.AddCard(addCardViewModel);
        }
        // PUT api/<CardsController>/5
        [HttpPut("{id}")]
        public int Put([FromRoute]int id,[FromBody] UpdateCardViewModel updateCardViewModel)
        {
            return _cardService.UpdateCardById(id, updateCardViewModel);
        }
        // DELETE api/<CardsController>/5
        [HttpDelete("{id}")]
        public int Delete([FromRoute]int id)
        {
            return _cardService.DeleteCard(id);
        }
        
    }
}
