using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.ViewModel
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PhotoWithCardIdViewModel
    {
        public string Name { get; set; }
    }
    public class UpdatePhotoViewModel
    {
        public List<IFormFile> FilePhotoList { get; set; }
        public List<string> StringPhotoList { get; set; }
    }
}
