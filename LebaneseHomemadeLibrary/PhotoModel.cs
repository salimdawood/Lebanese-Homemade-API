using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemadeLibrary
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }


        //navigation
        public int CardId { get; set; }
        public CardModel Card { get; set; }
    }
}
