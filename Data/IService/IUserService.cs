using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.IService
{
    public interface IUserService
    {
        int AddUser(UserViewModel userViewModel);
        int UpdateUser(int userId,UserViewModel userViewModel);
        UserProfileViewModel GetUserByName(string name, string password);
        string GetEmailOfUser(string name);
       
    }
}
