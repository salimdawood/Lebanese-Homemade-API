using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemadeLibrary
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }


        //navigation
        public int MenuId { get; set; }
        public MenuModel Menu { get; set; }
    }
}
