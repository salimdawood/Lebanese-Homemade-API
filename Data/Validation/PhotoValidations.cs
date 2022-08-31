using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LebaneseHomemade.Data.Validation
{
    static public class PhotoValidations
    {
        //2 MB
        private static readonly long IMAGE_MAX_SIZE = 2097152;
        public static bool PhotoSizeValidation(List<IFormFile> imageFiles)
        {
            foreach (var imageFile in imageFiles)
            {
                long _size = imageFile.Length;
                if (_size > IMAGE_MAX_SIZE) return false;
            }
            return true;
        } 
    }
}
