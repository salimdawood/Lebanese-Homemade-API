﻿using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.Validation;
using LebaneseHomemade.Data.ViewModel;
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

        public int DeleteMenuOfCard(int menuId)
        { 
            try
            {
                var _itemList = _appDbContext.Items.Where(item => item.MenuId == menuId).ToList();
                if (_itemList.Count != 0)
                {
                    _appDbContext.Items.RemoveRange(_itemList);
                    _appDbContext.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int UpdateMenuOfCard(int cardId, List<ItemListViewModel> itemListViewModels)
        {
            if (!ItemValidations.ItemListValidation(itemListViewModels)) return -2;
            try
            {
                var _menu = _appDbContext.Menus.Where(menu => menu.CardId == cardId).FirstOrDefault();
                var _oldItems = _appDbContext.Items.Where(item => item.MenuId == _menu.Id).ToList();

                List<ItemModel> _newItems = new();
                foreach(var item in itemListViewModels)
                {
                    var _item = new ItemModel
                    {
                        Name = item.Name.Trim(),
                        Price = item.Price.Trim().Length == 0 ? null : item.Price.Trim()
                    };
                    _newItems.Add(_item);
                }
                //remove old menu items
                _appDbContext.Items.RemoveRange(_oldItems);
                //add the updated menu items
                _menu.ItemList = _newItems;
                _appDbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
