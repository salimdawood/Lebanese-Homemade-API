using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class ItemService:IItemService
    {
        private readonly AppDbContext _appDbContext;
        public ItemService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddItems(ItemViewModel itemViewModel, int menuId)
        {
                var _item = new ItemModel()
                {
                    MenuId=menuId,
                    Name=itemViewModel.Name,
                    Price=itemViewModel.Price
                };
                _appDbContext.Items.Add(_item);
                _appDbContext.SaveChanges();
        }

        public void DeleteItem(int itemId)
        {
            var _item = new ItemModel()
            {
                Id = itemId
            };
            _appDbContext.Items.Remove(_item);
        }

        public void UpdateItems(List<ItemViewModel> itemViewModel,int menuId)
        {
            var _items = _appDbContext.Items.Where(item => item.MenuId == menuId).ToList();
            //remove deleted items
            var _itemsViewModelId = itemViewModel.Select(item => item.Id);
            foreach (var item in _items)
            {
                if (!_itemsViewModelId.Contains(item.Id))
                {
                    _appDbContext.Items.Remove(item);
                    _appDbContext.SaveChanges();
                }
            }
            //update items
            foreach (var itemVM in itemViewModel)
            {
                var _item = _items.Where(item => item.Id == itemVM.Id).FirstOrDefault();
                if(_item != null)
                {
                    _item.Name = itemVM.Name;
                    _item.Price = itemVM.Price;
                }
                else
                {
                    var _newItem = new ItemModel()
                    {
                        Name=itemVM.Name,
                        Price=itemVM.Price,
                        MenuId=menuId
                    };
                    _appDbContext.Items.Add(_newItem);
                }
                _appDbContext.SaveChanges();
            }
        }
    }
}
