using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.ViewModel
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string InstagramLink { get; set; }
        public string FaceBookLink { get; set; }
        public string WhatsAppLink { get; set; }
        public List<PhotoViewModel> PhotoList { get; set; }
        public MenuViewModel Menu { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class CardGalleryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class AddCardViewModel
    {
        public string Title { get; set; }
        public string InstagramLink { get; set; }
        public string FaceBookLink { get; set; }
        public string WhatsAppLink { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public List<IFormFile> PhotoList { get; set; }
        public List<string> ItemList { get; set; }
    }
}
