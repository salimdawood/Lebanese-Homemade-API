using LebaneseHomemade.Data.IService;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _appDbContext;
        public MenuService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int deleteMenuOfCard(int menuId)
        { 
            try
            {
                var _itemList = _appDbContext.Items.Where(item => item.MenuId == menuId).ToList();
                if (_itemList.Count == 0)
                {
                    return 1;
                }
                _appDbContext.Items.RemoveRange(_itemList);
                _appDbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return - 1;
            }
        }

        public MenuModel getMenuOfCard(int cardId)
        {
            //List<ItemModel> _menuWithItemList = new List<ItemModel>();
            var _menu = _appDbContext.Menus.Where(menu=>menu.CardId==cardId).FirstOrDefault();
            if(_menu != null)
            {
               _menu.ItemList = _appDbContext.Items.Where(item => item.MenuId == _menu.Id).ToList();
            }
            return _menu;
        }
    }
}
