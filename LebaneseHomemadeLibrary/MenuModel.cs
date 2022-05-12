using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemadeLibrary
{
    public class MenuModel
    {
        public int Id { get; set; }


        //navigation
        public List<ItemModel> ItemList { get; set; }
        //navigation
        public int CardId { get; set; }
        public CardModel Card { get; set; }
    }
}
