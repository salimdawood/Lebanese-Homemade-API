using LebaneseHomemade.Data.ViewModel;
using Microsoft.AspNetCore.JsonPatch;
using System.Text.RegularExpressions;

namespace LebaneseHomemade.Data.Validation
{
    public static class UserValidations
    {
        private static readonly Regex name_regex = new(@"^(?=(?:.*[a-zA-Z0-9\u0621-\u064A\u0660-\u0669]){3})[a-zA-Z0-9\u0621-\u064A\u0660-\u0669'._ ]{0,27}$");
        private static readonly Regex password_regex = new(@"^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,20}$");
        private static readonly Regex email_regex = new(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
        private static readonly Regex location_regex = new(@"^[a-zA-Z\u0621-\u064A,' -]{3,70}$");
        public static bool UserValidation(UserViewModel userViewModel)
        {
            //Name
            if (string.IsNullOrWhiteSpace(userViewModel.Name) ||
                !name_regex.IsMatch(userViewModel.Name)
               ) return false;
            //Email
            if (string.IsNullOrWhiteSpace(userViewModel.Email) ||
                !email_regex.IsMatch(userViewModel.Email)
               ) return false;
            //Password
            if (string.IsNullOrWhiteSpace(userViewModel.Password) ||
                !password_regex.IsMatch(userViewModel.Password)
               ) return false;
            //Location
            if (!string.IsNullOrWhiteSpace(userViewModel.Location) &&
                !location_regex.IsMatch(userViewModel.Location)
               ) return false;
            //if passed all validations
            return true;
        }
        public static bool PasswordResetValidation(string name, JsonPatchDocument password)
        {
            var _password = password.Operations[0].value.ToString();

            //Name
            if (string.IsNullOrWhiteSpace(name) ||
                !name_regex.IsMatch(name)
               ) return false;
            //Password
            if (string.IsNullOrWhiteSpace(_password) ||
                !password_regex.IsMatch(_password)
               ) return false;
            //if passed all validations
            return true;
        }
        public static bool NameAndPasswordValidation(string name, string password)
        {
            //Name
            if (string.IsNullOrWhiteSpace(name) ||
                !name_regex.IsMatch(name)
               ) return false;
            //Password
            if (string.IsNullOrWhiteSpace(password) ||
                !password_regex.IsMatch(password)
               ) return false;
            //if passed all validations
            return true;
        }
        public static bool NameValidation(string name)
        {
            //Name
            if (string.IsNullOrWhiteSpace(name) ||
                !name_regex.IsMatch(name)
               ) return false;
            //if passed all validations
            return true;
        }
    }
}
