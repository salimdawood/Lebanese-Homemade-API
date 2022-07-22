using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public List<ItemViewModel> ItemList { get; set; }
    }
}
