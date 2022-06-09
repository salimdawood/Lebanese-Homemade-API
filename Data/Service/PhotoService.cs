using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class PhotoService:IPhotoService
    {
        private readonly AppDbContext _appDbContext;
        public PhotoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddPhoto(PhotoViewModel photoViewModel)
        {
            var _photo = new PhotoModel()
            {
                Name = photoViewModel.Name
            };
            _appDbContext.Photos.Add(_photo);
            _appDbContext.SaveChanges();
        }
        public void DeletePhoto(int cardId)
        {
            var _photo = new PhotoModel()
            {
                Id = cardId
            };
            _appDbContext.Photos.Remove(_photo);
            _appDbContext.SaveChanges();
        }

        public List<PhotoModel> GetPhotos(int cardId)
        {
            return _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
        }
    }
}
