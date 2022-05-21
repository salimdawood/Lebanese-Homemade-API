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
        public int AddUser(UserViewModel userViewModel)
        {
            var _username = _appDbContext.Users.Where(user => user.Name == userViewModel.Name.Trim().ToLower()).FirstOrDefault();
            if(_username != null)
            {
                return -1;
            }
            try
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
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool NameExist(string name)
        {
            var _user = _appDbContext.Users.Where(user => user.Name == name.Trim().ToLower()).FirstOrDefault();
            return _user != null;
        }
        public UserWithCardListViewModel GetUserByName(string name,string password)
        {
            var _user = _appDbContext.Users.Where(user => user.Name == name.Trim().ToLower() && user.Password==password).Select(user => new UserWithCardListViewModel() {
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
        public bool LogInValidation(string name, string password)
        {
            var _user = _appDbContext.Users.Where(user => user.Name == name.Trim().ToLower() && user.Password == password).FirstOrDefault();
            return _user != null;
        }

        public void UpdateUser(int userId,UserViewModel userViewModel)
        {
            var _user = _appDbContext.Users.Where(user => user.Id == userId).FirstOrDefault();
            if(_user != null)
            {
                _user.Name = userViewModel.Name.Trim().ToLower();
                _user.Email = userViewModel.Email.Trim().ToLower();
                _user.Location = userViewModel.Location.Trim().ToLower();
                _user.Password = userViewModel.Password.Trim();
                _appDbContext.SaveChanges();
            }
        }
    }
}