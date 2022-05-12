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
    public class PhotosController : ControllerBase
    {
        private readonly PhotoService _photoService;

        public PhotosController(PhotoService photoService)
        {
            _photoService = photoService;
        }
        // GET: api/<PhotosController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PhotosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            List<PhotoModel> _photos = _photoService.GetPhotos(id);
            return Ok(_photos);
        }

        // POST api/<PhotosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<PhotosController>/5
        [HttpPut("{id}")]
        public void Put([FromBody]List<PhotoViewModel> photoViewModel,int id)
        {
            _photoService.UpdatePhotos(photoViewModel,id);
        }

        // DELETE api/<PhotosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
