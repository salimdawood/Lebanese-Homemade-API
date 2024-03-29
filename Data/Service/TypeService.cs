﻿using LebaneseHomemade.Data.IService;
using LebaneseHomemadeLibrary;
using System.Collections.Generic;
using System.Linq;

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
                Name = typeName.Trim().ToLower()
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
            var _types = _appDbContext.Types.ToList();
            return _types;
        }

        public void UpdateType(int typeId,string typeName)
        {
            var _type = _appDbContext.Types.Where(type => type.Id == typeId).FirstOrDefault();
            if (_type != null)
            {
                _type.Name = typeName.Trim().ToLower();
                _appDbContext.SaveChanges();
            }
        }
    }
}
