using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.IService
{
    public interface IMenuService
    {
        MenuModel GetMenuOfCard(int cardId);
        int DeleteMenuOfCard(int menuId);
        int UpdateMenuOfCard(int cardId, List<ItemListViewModel> itemListViewModels);
    }
}
