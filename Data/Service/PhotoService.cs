using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class PhotoService:IPhotoService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ImageUploadService _imageUploadService;

        public PhotoService(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment,ImageUploadService imageUploadService)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
            _imageUploadService = imageUploadService;
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
        public int DeletePhoto(int cardId)
        {
            try
            {
                //delete image name from database
                var _photoList = _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
                _appDbContext.Photos.RemoveRange(_photoList);
                _appDbContext.SaveChanges();

                //delete image from server
                foreach (var photo in _photoList)
                {
                    var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", photo.Name);
                    FileInfo file = new(imagePath);
                    if (file.Exists)  
                    {
                        file.Delete();
                    }
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<PhotoModel> GetPhotos(int cardId)
        {
            return _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
        }

        public async Task<CardModel> UpdatePhotos(int cardId, UpdatePhotoViewModel updatePhotoViewModel)
        {
            /*
            try
            {
                var _photos = _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
                var _card = _appDbContext.Cards.Where(card => card.Id == cardId).FirstOrDefault();
                foreach (var photo in _photos)
                {
                    if (!updatePhotoViewModel.StringPhotoList.Contains(photo.Name))
                    {
                        //photo is in db and server and user wants to delete it
                        var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", photo.Name);
                        FileInfo file = new(imagePath);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                }
                //add new image files to db and server
                _card.PhotoList = await _imageUploadService.ImageUpload(updatePhotoViewModel.FilePhotoList);
                _appDbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            */
            var _photoList = _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
            var _card = _appDbContext.Cards.Where(card => card.Id == cardId).FirstOrDefault();

            //if string photolist is empty then the user wants to delete all his previous photos from db and server
            if(updatePhotoViewModel.StringPhotoList == null)
            {
                _appDbContext.Photos.RemoveRange(_photoList);
                _appDbContext.SaveChanges();

                //delete image from server
                foreach (var photo in _photoList)
                {
                    var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", photo.Name);
                    FileInfo file = new(imagePath);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
            }
            else
            {
                foreach (var photo in _photoList)
                {
                    if (!updatePhotoViewModel.StringPhotoList.Contains(photo.Name))
                    {
                        //photo is in db and server and user wants to delete it
                        var _photo = _appDbContext.Photos.Where(photoEntity => photoEntity.Name == photo.Name).FirstOrDefault();
                        if(_photo != null)
                        {
                            _appDbContext.Photos.Remove(_photo);

                        }
                        var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", photo.Name);
                        FileInfo file = new(imagePath);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    _appDbContext.SaveChanges();
                }
            }


            if (updatePhotoViewModel.FilePhotoList != null)
            {
                //add new image files to db and server
                var _photos = await _imageUploadService.ImageUpload(updatePhotoViewModel.FilePhotoList);
                _card.PhotoList =  _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
                _card.PhotoList.AddRange(_photos);
                _appDbContext.SaveChanges();
            }
            return _card;
        }
    }
}
