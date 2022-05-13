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
        public List<ItemModel> getMenuOfCard(int cardId)
        {
            List<ItemModel> _menuWithItemList = new List<ItemModel>();
            var _menu = _appDbContext.Menus.Where(menu=>menu.CardId==cardId).FirstOrDefault();
            if(_menu != null)
            {
                _menuWithItemList = _appDbContext.Items.Where(item => item.MenuId == _menu.Id).ToList();
            }
            return _menuWithItemList;
        }
    }
}
