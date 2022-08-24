using LebaneseHomemade.Data.ViewModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LebaneseHomemade.Data.Validation
{
    static public class ItemValidations
    {
        private static readonly Regex name_regex = new(@"^[a-zA-Z0-9\u0621-\u064A\u0660-\u0669 '.]{3,50}$");
        private static readonly Regex price_regex = new(@"^[lL0-9\u0660-\u0669,$.]{0,20}$");
        public static bool ItemListValidation(List<ItemListViewModel> itemListViewModels)
        {
            foreach (var itemViewModel in itemListViewModels)
            {
                //Name
                if (string.IsNullOrWhiteSpace(itemViewModel.Name) ||
                !name_regex.IsMatch(itemViewModel.Name)
                   ) return false;
                //Price
                if (!string.IsNullOrWhiteSpace(itemViewModel.Price) &&
                    !price_regex.IsMatch(itemViewModel.Price)
                   ) return false;
            }
            //passed all validations
            return true;
        }

    }
}
