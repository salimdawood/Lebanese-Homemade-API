using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LebaneseHomemade.Data.Validation
{
    static public class PhotoValidations
    {
        private static readonly Regex photo_regex = new Regex(@"^.(png|jpg|jpeg)$",RegexOptions.IgnoreCase);
        //2 MB  = 2097152
        public static bool PhotoSizeValidation(List<IFormFile> imageFiles)
        {
            foreach (var imageFile in imageFiles)
            {
                long _size = imageFile.Length;
                var  _extension = Path.GetExtension(imageFile.FileName);

                if (_size > 2097152 || !photo_regex.IsMatch(_extension)) return false;
            }
            return true;
        } 
    }
}
