using System.Collections.Generic;

namespace LebaneseHomemade.Data.ViewModel
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserOfCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<CardGalleryViewModel> CardList { get; set; }
    }
}
