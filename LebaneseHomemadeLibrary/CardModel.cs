using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemadeLibrary
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string InstagramLink { get; set; }
        public string FaceBookLink { get; set; }
        public string WhatsAppLink { get; set; }
        public DateTime DateCreated { get; set; }


        //navigation
        public List<PhotoModel> PhotoList { get; set; }
        //navigation
        public int UserId { get; set; }
        public UserModel User { get; set; }
        //navigation
        public MenuModel Menu { get; set; }
        //navigation
        public int TypeId { get; set; }
        public TypeModel Type { get; set; }
    }
}
