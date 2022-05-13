using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.IService
{
    public interface IMenuService
    {
        List<ItemModel> getMenuOfCard(int cardId);
    }
}
