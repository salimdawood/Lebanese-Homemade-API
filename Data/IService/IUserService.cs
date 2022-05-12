﻿using LebaneseHomemade.Data.ViewModel;
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
        void UpdateUser(int userId,UserViewModel userViewModel);
        bool NameExist(string name);
        bool LogInValidation(string name, string password);
        //UserWithCardListViewModel GetUserByName(string name, string password);
       
    }
}
