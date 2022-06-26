using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class ImageUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<PhotoModel>> ImageUpload(List<IFormFile> imageFiles)
        {
            List<PhotoModel> imageNames = new();
            if(imageFiles != null)
            {
                foreach (var imageFile in imageFiles)
                {
                    string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
                    var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    var _photo = new PhotoModel()
                    {
                        Name = imageName
                    };
                    imageNames.Add(_photo);
                }
            }
            return imageNames;
        }
    }
}
