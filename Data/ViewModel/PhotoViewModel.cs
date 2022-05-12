using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.ViewModel
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
    public class PhotoNoIdViewModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
