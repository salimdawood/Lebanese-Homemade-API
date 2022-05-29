using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.Pagination;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class CardService:ICardService
    {
        private readonly AppDbContext _appDbContext;
        public CardService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<CardViewModel> GetCards(PaginationParameter paginationParameter)
        {
            var _card = _appDbContext.Cards.Skip((paginationParameter.PageNumber-1)*paginationParameter.PageSize)
                .Take(paginationParameter.PageSize)
                .Select(card => new CardViewModel()
            {
                Id = card.Id,
                Title = card.Title,
                InstagramLink = card.InstagramLink,
                FaceBookLink = card.FaceBookLink,
                WhatsAppLink = card.WhatsAppLink,
                Type = card.Type.Name,
                PhotoList = card.PhotoList.Select(photo => new PhotoViewModel()
                {
                    Id = photo.Id,
                    Name = photo.Name,
                    Extension = photo.Extension
                }).ToList(),
                Menu = (card.Menu == null) ? null : new MenuViewModel()
                {
                    Id = card.Menu.Id,
                    ItemList = card.Menu.ItemList.Select(item => new ItemViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price
                    }).ToList()
                },
                DateCreated = card.DateCreated
                }).ToList();
            return _card;
        }
        public List<CardViewModel> GetCardsByTypeId(int typeId)
        {
            var _card = _appDbContext.Cards.Where(card => card.TypeId == typeId).Select(card => new CardViewModel()
            {
                Id = card.Id,
                Title = card.Title,
                InstagramLink = card.InstagramLink,
                FaceBookLink = card.FaceBookLink,
                WhatsAppLink = card.WhatsAppLink,
                Type = card.Type.Name,
                PhotoList = card.PhotoList.Select(photo => new PhotoViewModel()
                {
                    Id = photo.Id,
                    Name = photo.Name,
                    Extension = photo.Extension
                }).ToList(),
                Menu = (card.Menu == null) ? null : new MenuViewModel()
                {
                    Id = card.Menu.Id,
                    ItemList = card.Menu.ItemList.Select(item => new ItemViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price
                    }).ToList()
                },
                DateCreated = card.DateCreated
            }).ToList();
            return _card;
        }
        public List<CardViewModel> GetCardsOfUser(int userId)
        {
            var _card = _appDbContext.Cards.Where(card=>card.UserId==userId).Select(card => new CardViewModel()
            {
                Id = card.Id,
                Title = card.Title,
                InstagramLink = card.InstagramLink,
                FaceBookLink = card.FaceBookLink,
                WhatsAppLink = card.WhatsAppLink,
                Type = card.Type.Name,
                PhotoList = card.PhotoList.Select(photo => new PhotoViewModel()
                {
                    Id = photo.Id,
                    Name = photo.Name,
                    Extension = photo.Extension
                }).ToList(),
                Menu = (card.Menu == null) ? null : new MenuViewModel()
                {
                    Id = card.Menu.Id,
                    ItemList = card.Menu.ItemList.Select(item => new ItemViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price
                    }).ToList()
                },
                DateCreated = card.DateCreated
            }).ToList();
            return _card;
        }
        public void DeleteCard(int cardId)
        {
            var _card = new CardModel()
            {
                Id=cardId
            };
            _appDbContext.Cards.Remove(_card);
            _appDbContext.SaveChanges();
        }

        public int AddCard(AddCardViewModel addCardViewModel)
        {
            try
            {
                var _card = new CardModel()
                {
                    Title = addCardViewModel.Title,
                    FaceBookLink = addCardViewModel.FaceBookLink,
                    InstagramLink = addCardViewModel.InstagramLink,
                    WhatsAppLink = addCardViewModel.WhatsAppLink,
                    TypeId = addCardViewModel.TypeId,
                    UserId = addCardViewModel.UserId
                };
                _appDbContext.Cards.Add(_card);
                _appDbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            } 
        }
    }
}
