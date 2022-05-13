using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.IService
{
    public interface IItemService
    {
        void AddItems(ItemViewModel itemViewModel, int menuId);
        void UpdateItems(List<ItemViewModel> itemViewModel, int itemId);
        void DeleteItem(int itemId);
       
    }
}
