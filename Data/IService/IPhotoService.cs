using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.IService
{
    public interface IPhotoService
    {
        int DeletePhotos(int cardId);
        Task<List<PhotoViewModel>> UpdatePhotos(int cardId,UpdatePhotoViewModel updatePhotoViewModel);
    }
}
