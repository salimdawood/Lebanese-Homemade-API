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
        public List<PhotoModel> GetPhotos(int cardId)
        {
            return _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
        }
        public void UpdatePhotos(List<PhotoViewModel> photoViewModel, int cardId)
        {
            var _photos = _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
            //remove deleted items
            var _photosViewModelId = photoViewModel.Select(item => item.Id);
            foreach (var photo in _photos)
            {
                if (!_photosViewModelId.Contains(photo.Id))
                {
                    _appDbContext.Photos.Remove(photo);
                    _appDbContext.SaveChanges();
                }
            }
            //update items
            foreach (var photoVM in photoViewModel)
            {
                var _photo = _photos.Where(item => item.Id == photoVM.Id).FirstOrDefault();
                if (_photo != null)
                {
                    _photo.Name = photoVM.Name;
                    _photo.Extension = photoVM.Extension;
                }
                else
                {
                    var _newPhoto = new PhotoModel()
                    {
                        Name = photoVM.Name,
                        Extension=photoVM.Extension,
                        CardId=cardId
                    };
                    _appDbContext.Photos.Add(_newPhoto);
                }
                _appDbContext.SaveChanges();
            }
        }
    }
}
