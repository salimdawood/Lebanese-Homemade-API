using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.Pagination;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LebaneseHomemade.Data.Service
{
    public class CardService:ICardService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ImageUploadService _imageUploadService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CardService(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment,ImageUploadService imageUploadService)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
            _imageUploadService = imageUploadService;
        }

        
        public List<CardViewModel> GetCardsByTypeId(int typeId,PaginationParameter paginationParameter)
        {
            var _cardBase = _appDbContext.Cards.AsQueryable();

            if (typeId != -1)
            {
                _cardBase = _cardBase.Where(card => card.TypeId == typeId);
            }
          
            var _card = _cardBase.Skip((paginationParameter.PageNumber - 1) * paginationParameter.PageSize)
                .Take(paginationParameter.PageSize).
                Select(card => new CardViewModel()
            {
                Id = card.Id,
                Title = card.Title,
                InstagramLink = card.InstagramLink,
                FaceBookLink = card.FaceBookLink,
                WhatsAppLink = card.WhatsAppLink,
                Type = new TypeViewModel
                {
                    Id = card.Type.Id,
                    Name = card.Type.Name
                },
                PhotoList = card.PhotoList.Select(photo => new PhotoViewModel()
                {
                    Id = photo.Id,
                    Name = photo.Name
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
                DateCreated = card.DateCreated,
                User = new UserOfCardViewModel
                {
                    Id = card.UserId,
                    Name = card.User.Name
                }
            }).ToList();
            return _card;
        }
        public List<CardViewModel> GetCardsOfUser(string userName)
        {
            var _card = _appDbContext.Cards.Where(card=>card.User.Name==userName).Select(card => new CardViewModel()
            {
                Id = card.Id,
                Title = card.Title,
                InstagramLink = card.InstagramLink,
                FaceBookLink = card.FaceBookLink,
                WhatsAppLink = card.WhatsAppLink,
                Type = new TypeViewModel
                {
                    Id = card.Type.Id,
                    Name = card.Type.Name
                },
                PhotoList = card.PhotoList.Select(photo => new PhotoViewModel()
                {
                    Id = photo.Id,
                    Name = photo.Name
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
                DateCreated = card.DateCreated,
                User = new UserOfCardViewModel
                {
                    Id = card.UserId,
                    Name = card.User.Name
                }
            }).ToList();
            return _card;
        }
        public int DeleteCard(int cardId)
        {
            using var _transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var _card = new CardModel()
                {
                    Id = cardId
                };
                var _photoList = _appDbContext.Photos.Where(photo => photo.CardId == cardId).ToList();
                //delete image from server
                foreach (var photo in _photoList)
                {
                    var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", photo.Name);
                    FileInfo file = new(imagePath);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                _appDbContext.Cards.Remove(_card);
                _appDbContext.SaveChanges();
                _transaction.Commit();
                return 1;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                return 0;
            }
        }

        public async Task<int> AddCard(AddCardViewModel addCardViewModel)
        {
            using var _transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                //add card basic information
                var _card = new CardModel()
                {
                    Title = addCardViewModel.Title,
                    FaceBookLink = addCardViewModel.FaceBookLink,
                    InstagramLink = addCardViewModel.InstagramLink,
                    WhatsAppLink = addCardViewModel.WhatsAppLink,
                    TypeId = addCardViewModel.TypeId,
                    UserId = addCardViewModel.UserId
                };
                //add photolist to card object
                _card.PhotoList = new List<PhotoModel>();
                if (addCardViewModel.PhotoList != null)
                {
                    var _imageNames = await _imageUploadService.ImageUpload(addCardViewModel.PhotoList);
                    _card.PhotoList = _imageNames;
                }
                //add menu and add itemlist to it then add the menu to card object
                _card.Menu = new MenuModel
                {
                    ItemList = new List<ItemModel>()
                };
                if (addCardViewModel.ItemList != null)
                {
                    foreach (var item in addCardViewModel.ItemList)
                    {
                        ItemListViewModel itemListViewModel = JsonConvert.DeserializeObject<ItemListViewModel>(item);
                        var _item = new ItemModel()
                        {
                            Name = itemListViewModel.Name,
                            Price = itemListViewModel.Price
                        };
                        _card.Menu.ItemList.Add(_item);
                    }
                }
                //add new entity to db
                _appDbContext.Cards.Add(_card);
                _appDbContext.SaveChanges();
                _transaction.Commit();
                var _cardId = _card.Id;
                return _cardId;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                return 0;
            }
        }

        public CardViewModel GetCardById(int cardId)
        {
            var _card = _appDbContext.Cards.Where(card => card.Id == cardId).Select(card => new CardViewModel()
            {
                Id = card.Id,
                Title = card.Title,
                InstagramLink = card.InstagramLink,
                FaceBookLink = card.FaceBookLink,
                WhatsAppLink = card.WhatsAppLink,
                Type = new TypeViewModel
                {
                    Id = card.Type.Id,
                    Name = card.Type.Name
                },
                PhotoList = card.PhotoList.Select(photo => new PhotoViewModel()
                {
                    Id = photo.Id,
                    Name = photo.Name
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
                DateCreated = card.DateCreated,
                User = new UserOfCardViewModel
                {
                    Id = card.UserId,
                    Name = card.User.Name
                }
            }).FirstOrDefault();
            return _card;
        }

        public int UpdateCardById(int cardId, UpdateCardViewModel updateCardViewModel)
        {
            using var _transaction = _appDbContext.Database.BeginTransaction();
            var _card = _appDbContext.Cards.Where(card => card.Id == cardId).FirstOrDefault();
            try
            {
                if(_card != null)
                {
                    _card.Title = updateCardViewModel.Title;
                    _card.FaceBookLink = updateCardViewModel.FaceBookLink;
                    _card.InstagramLink = updateCardViewModel.InstagramLink;
                    _card.WhatsAppLink = updateCardViewModel.WhatsAppLink;
                    _card.TypeId = updateCardViewModel.TypeId;
                }
                
                _appDbContext.SaveChanges();
                _transaction.Commit();
                var _cardId = _card.Id;
                return _cardId;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                return 0;
            }
        }

        public int CardsCount(int typeId)
        {
            var _cardsCount = 0;
            if (typeId == -1)
            {
                _cardsCount = _appDbContext.Cards.Count();
            }
            else
            {
                _cardsCount = _appDbContext.Cards.Where(card => card.TypeId == typeId).Count();
            }
            return _cardsCount;
        }
    }
}
