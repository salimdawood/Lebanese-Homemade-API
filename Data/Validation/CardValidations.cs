using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LebaneseHomemade.Data.Validation
{
    public static class CardValidations
    {
        private static readonly Regex title_regex = new(@"^(?=(?:.*[a-zA-Z0-9\u0621-\u064A\u0660-\u0669]){3})[a-zA-Z0-9\u0621-\u064A\u0660-\u0669 .'-]{0,27}$");
        private static readonly Regex facebook_regex = new(@"^[a-zA-Z0-9\u0621-\u064A\u0660-\u0669.]{5,50}$");
        private static readonly Regex instagram_regex = new(@"^[a-zA-Z0-9\u0621-\u064A\u0660-\u0669_.]{1,30}$");
        private static readonly Regex whatsapp_regex = new(@"^[0-9\u0660-\u0669]{8}$");
        private static readonly Regex name_regex = new(@"^(?=(?:.*[a-zA-Z0-9\u0621-\u064A\u0660-\u0669]){3})[a-zA-Z0-9\u0621-\u064A\u0660-\u0669 '.]{0,47}$");
        private static readonly Regex price_regex = new(@"^[lL0-9\u0660-\u0669,$.]{0,20}$");

        public static bool AddCardValidation(AddCardViewModel addCardViewModel,List<ItemModel> itemModels)
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
            //Item List
            if (addCardViewModel.ItemList != null)
            {
                ItemListViewModel itemListViewModel;
                foreach (var item in addCardViewModel.ItemList)
                {
                    itemListViewModel = JsonConvert.DeserializeObject<ItemListViewModel>(item);
                    //Name
                    if (string.IsNullOrWhiteSpace(itemListViewModel.Name) ||
                    !name_regex.IsMatch(itemListViewModel.Name)
                       ) return false;
                    //Price
                    if (!string.IsNullOrWhiteSpace(itemListViewModel.Price) &&
                        !price_regex.IsMatch(itemListViewModel.Price)
                       ) return false;
                    var _item = new ItemModel()
                    {
                        Name = itemListViewModel.Name.Trim(),
                        Price = itemListViewModel.Price.Trim().Length == 0? null : itemListViewModel.Price.Trim()
                    };
                    itemModels.Add(_item);
                }
            }
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
