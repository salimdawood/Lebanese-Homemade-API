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
        List<CardViewModel> GetCardsByTypeId(int typeId, PaginationParameter paginationParameter);
        List<CardViewModel> GetCardsOfUser(string userName);
        int DeleteCard(int cardId);
        Task<int> AddCard(AddCardViewModel cardViewModel);

        CardViewModel GetCardById(int cardId);
        int UpdateCardById(int cardId,UpdateCardViewModel updateCardViewModel);
        int cardsCount(int typeId);
    }
}
