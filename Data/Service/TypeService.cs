using LebaneseHomemade.Data.IService;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Service
{
    public class TypeService : ITypeService
    {
        private readonly AppDbContext _appDbContext;
        public TypeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddType(string typeName)
        {
            var _type = new TypeModel()
            {
                Name = typeName
            };
            _appDbContext.Types.Add(_type);
            _appDbContext.SaveChanges();
        }

        public void DeleteType(int typeId)
        {
            var _type = new TypeModel()
            {
                Id = typeId
            };
            _appDbContext.Types.Remove(_type);
            _appDbContext.SaveChanges();
        }

        public List<TypeModel> GetTypes()
        {
            var _type = _appDbContext.Types.ToList();
            return _type;
        }

        public void UpdateType(int typeId)
        {
            
        }
    }
}
