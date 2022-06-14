using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.Pagination;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace LebaneseHomemade.Data.Service
{
    public class CardService:ICardService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CardService(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> ImageUpload(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
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
                DateCreated = card.DateCreated
            }).ToList();
            return _card;
        }
        public int DeleteCard(int cardId)
        {
            try
            {
                var _card = new CardModel()
                {
                    Id = cardId
                };
                _appDbContext.Cards.Remove(_card);
                _appDbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
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
                    foreach (var photoFile in addCardViewModel.PhotoList)
                    {
                        var _photo = new PhotoModel()
                        {
                            Name = await ImageUpload(photoFile)
                        };
                        _card.PhotoList.Add(_photo);
                    }
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
                return -1;
            }
        }

        public CardViewModel GetCardById(int cardId)
        {
            return _appDbContext.Cards.Where(card => card.Id == cardId).Select(card=>new CardViewModel()
            {
                Id=card.Id,
                Title=card.Title,
                Type=card.Type.Name,
                InstagramLink=card.InstagramLink,
                FaceBookLink=card.FaceBookLink,
                WhatsAppLink=card.WhatsAppLink,
                DateCreated=card.DateCreated
            }).FirstOrDefault();
        }
    }
}
