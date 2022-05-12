using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
    public class ItemWithMenuIdViewModel
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

}
