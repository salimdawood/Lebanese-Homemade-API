using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.Validation;
using LebaneseHomemade.Data.ViewModel;
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
        public int DeletePhotos(int cardId)
        {
            using var _transaction = _appDbContext.Database.BeginTransaction();
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
                _transaction.Commit();
                return 1;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                return 0;
            }
        }
        public async Task<List<PhotoViewModel>> UpdatePhotos(int cardId, UpdatePhotoViewModel updatePhotoViewModel)
        {
            if (!PhotoValidations.PhotoSizeValidation(updatePhotoViewModel.FilePhotoList)) return new List<PhotoViewModel>();
            using var _transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var _photoList = _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();

                //if string photolist is empty then the user wants to delete all his previous photos from db and server
                if (updatePhotoViewModel.StringPhotoList == null)
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
                            if (_photo != null)
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
                    var _photosAddedName = await _imageUploadService.ImageUpload(updatePhotoViewModel.FilePhotoList,cardId);
                    _appDbContext.Photos.AddRange(_photosAddedName);
                    _appDbContext.SaveChanges();
                }
                var _photos = _appDbContext.Photos.Where(photo => photo.CardId == cardId).Select(photo => new PhotoViewModel()
                {
                    Id = photo.Id,
                    Name = photo.Name
                }).ToList();
                _transaction.Commit();
                return _photos;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                return new List<PhotoViewModel>();
            }
        }
    }
}
