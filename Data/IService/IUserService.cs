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
        void AddUser(UserViewModel userViewModel);
        bool NameExist(string name);
        UserWithCardListViewModel GetUserByName(string name, string password);
       
    }
}
