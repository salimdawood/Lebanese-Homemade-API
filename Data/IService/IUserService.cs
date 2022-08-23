using LebaneseHomemade.Data.ViewModel;
using Microsoft.AspNetCore.JsonPatch;

namespace LebaneseHomemade.Data.IService
{
    public interface IUserService
    {
        int AddUser(UserViewModel userViewModel);
        int UpdateUser(int userId,UserViewModel userViewModel);
        UserProfileViewModel GetUserByName(string name, string password);
        string GetEmailOfUser(string name);
        int ResetPassword(string name, JsonPatchDocument password);  
    }
}
