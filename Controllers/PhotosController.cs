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
        // GET api/<PhotosController>/5
        [HttpGet("{id}")]
        public void Get(int cardId)
        {
            _photoService.GetPhotos(cardId);
        }
        // POST api/<PhotosController>
        [HttpPost]
        public void Post([FromBody] PhotoViewModel photoViewModel)
        {
            _photoService.AddPhoto(photoViewModel);
        }
        // POST api/<PhotosController>
        [HttpPut("{id}")]
        public Task<List<PhotoModel>> Put([FromRoute] int id,[FromForm] UpdatePhotoViewModel updatePhotoViewModel)
        {
            return _photoService.UpdatePhotos(id, updatePhotoViewModel);
        }
        // DELETE api/<PhotosController>/5
        [HttpDelete("{id}")]
        public int Delete([FromRoute]int id)
        {
            return _photoService.DeletePhoto(id);
        }
    }
}
