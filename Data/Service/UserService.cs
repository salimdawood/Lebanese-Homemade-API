using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.Validation;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Linq;

namespace LebaneseHomemade.Data.Service
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int AddUser(UserViewModel userViewModel)
        {
            if (!UserValidations.UserValidation(userViewModel)) return -2;
            var _username = _appDbContext.Users.Where(user => user.Name.ToLower() == userViewModel.Name.Trim().ToLower()).FirstOrDefault();
            if(_username != null)
            {
                return -1;
            }
            try
            {
                var _user = new UserModel()
                {
                    Name = userViewModel.Name.Trim(),
                    Location = userViewModel.Location.Trim().Length == 0 ? null : userViewModel.Location.Trim(),
                    Email = userViewModel.Email.Trim(),
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

        public string GetEmailOfUser(string name)
        {
            var _email = _appDbContext.Users.Where(user => user.Name.ToLower() == name.Trim().ToLower()).FirstOrDefault();
            if(_email != null)
            {
                return _email.Email;
            }
            return null;
        }

        public UserProfileViewModel GetUserByName(string name,string password)
        {
            var _user = _appDbContext.Users.Where(user => user.Name.ToLower() == name.Trim().ToLower() && user.Password == password).Select(user => new UserProfileViewModel() {
                Id = user.Id,
                Name = user.Name,
                Location = user.Location,
                Email = user.Email,
                Password = user.Password,
                CardList = _appDbContext.Cards.Where(card => card.UserId == user.Id).Select(card=>new CardGalleryViewModel() { 
                    Id = card.Id,
                    Title = card.Title,
                    Type = card.Type.Name,
                    DateCreated = card.DateCreated
                }).ToList()
            }).FirstOrDefault();
            return _user;
        }

        public int ResetPassword(string name, JsonPatchDocument password)
        {
            if (!UserValidations.PasswordResetValidation(name,password)) return -2;
            var _user = _appDbContext.Users.Where(user => user.Name.ToLower() == name.Trim().ToLower()).FirstOrDefault();
            if(_user != null)
            {
                password.ApplyTo(_user);
                _appDbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int UpdateUser(int userId,UserViewModel userViewModel)
        {
            if (!UserValidations.UserValidation(userViewModel)) return -2;
            var _username = _appDbContext.Users.Where(user => user.Name.ToLower() == userViewModel.Name.Trim().ToLower() && user.Id != userId).FirstOrDefault();
            if (_username != null)
            {
                return -1;
            }
            try
            {
                var _user = _appDbContext.Users.Where(user => user.Id == userId).FirstOrDefault();
                if (_user != null)
                {
                    _user.Name = userViewModel.Name.Trim();
                    _user.Email = userViewModel.Email.Trim();
                    _user.Location = userViewModel.Location.Trim().Length == 0 ? null : userViewModel.Location.Trim();
                    _user.Password = userViewModel.Password;
                    _appDbContext.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}