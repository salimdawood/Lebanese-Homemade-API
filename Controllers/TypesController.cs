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
    public class TypesController : ControllerBase
    {
        private readonly TypeService _typeService;
        public TypesController(TypeService typeService)
        {
            _typeService = typeService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TypeModel> Get()
        {
            return _typeService.GetTypes();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string typeName)
        {
            _typeService.AddType(typeName);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string typeName)
        {
            _typeService.UpdateType(id,typeName);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _typeService.DeleteType(id);
        }
    }
}
