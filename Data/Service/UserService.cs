using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly CardService _cardService;
        public UserService(AppDbContext appDbContext, CardService cardService)
        {
            _appDbContext = appDbContext;
            _cardService = cardService;
        }
        public void AddUser(UserViewModel userViewModel)
        {
            var _user = new UserModel()
            {
                Name = userViewModel.Name,
                Location = userViewModel.Location,
                Email = userViewModel.Email,
                Password = userViewModel.Password
            };
            _appDbContext.Users.Add(_user);
            _appDbContext.SaveChanges();
        }
        public bool NameExist(string name)
        {
            var _user = _appDbContext.Users.Where(user => user.Name == name).FirstOrDefault();
            return _user != null ? true : false;
        }
        public UserWithCardListViewModel GetUserByName(string name,string password)
        {
            var _user = _appDbContext.Users.Where(user => user.Name == name && user.Password==password).Select(user => new UserWithCardListViewModel() {
                Id = user.Id,
                Name = user.Name,
                Location = user.Location,
                Email = user.Email,
                Password = user.Password,
            }).FirstOrDefault();
            if(_user != null)
            {
                _user.CardList = _cardService.GetCardsOfUser(_user.Id);
            }
            return _user;
        }
    }
}
