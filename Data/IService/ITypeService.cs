using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.IService
{
    public interface ITypeService
    {
        List<TypeModel> GetTypes();

        void DeleteType(int typeId);
        void AddType(string typeName);

        void UpdateType(int typeId);
    }
}
