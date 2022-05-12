using LebaneseHomemade.Data.Pagination;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.IService
{
    public interface ICardService
    {
        List<CardViewModel> GetCards(PaginationParameter paginationParameter);
        List<CardViewModel> GetCardsByTypeId(int typeId);
        List<CardViewModel> GetCardsOfUser(int userId);
        void DeleteCard(int cardId);
    }
}
