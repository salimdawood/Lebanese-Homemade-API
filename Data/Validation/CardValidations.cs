using LebaneseHomemade.Data.ViewModel;
using System.Text.RegularExpressions;

namespace LebaneseHomemade.Data.Validation
{
    public static class CardValidations
    {
        private static readonly Regex title_regex = new(@"^[a-zA-Z0-9\u0621-\u064A\u0660-\u0669 .'-]{3,30}$");
        private static readonly Regex facebook_regex = new(@"^[a-zA-Z0-9\u0621-\u064A\u0660-\u0669.]{5,50}$");
        private static readonly Regex instagram_regex = new(@"^[a-zA-Z0-9\u0621-\u064A\u0660-\u0669_.]{1,30}$");
        private static readonly Regex whatsapp_regex = new(@"^[0-9\u0660-\u0669]{8}$");
        public static bool AddCardValidation(AddCardViewModel addCardViewModel)
        {
            //Title
            if (string.IsNullOrWhiteSpace(addCardViewModel.Title) ||
                !title_regex.IsMatch(addCardViewModel.Title)
               ) return false;
            //FaceBook Link
            if (!string.IsNullOrWhiteSpace(addCardViewModel.FaceBookLink) &&
                !facebook_regex.IsMatch(addCardViewModel.FaceBookLink)
               ) return false;
            //Instagram Link
            if (!string.IsNullOrWhiteSpace(addCardViewModel.InstagramLink) &&
                !instagram_regex.IsMatch(addCardViewModel.InstagramLink)
               ) return false;
            //Whatsapp Link
            if (!string.IsNullOrWhiteSpace(addCardViewModel.WhatsAppLink) &&
                !whatsapp_regex.IsMatch(addCardViewModel.WhatsAppLink)
               ) return false;
            //if passed all validations
            return true;
        }
        public static bool UpdateCardValidation(UpdateCardViewModel updateCardViewModel)
        {
            //Title
            if (string.IsNullOrWhiteSpace(updateCardViewModel.Title) ||
                !title_regex.IsMatch(updateCardViewModel.Title)
               ) return false;
            //FaceBook Link
            if (!string.IsNullOrWhiteSpace(updateCardViewModel.FaceBookLink) &&
                !facebook_regex.IsMatch(updateCardViewModel.FaceBookLink)
               ) return false;
            //Instagram Link
            if (!string.IsNullOrWhiteSpace(updateCardViewModel.InstagramLink) &&
                !instagram_regex.IsMatch(updateCardViewModel.InstagramLink)
               ) return false;
            //Whatsapp Link
            if (!string.IsNullOrWhiteSpace(updateCardViewModel.WhatsAppLink) &&
                !whatsapp_regex.IsMatch(updateCardViewModel.WhatsAppLink)
               ) return false;
            //if passed all validations
            return true;
        }
    }
}
