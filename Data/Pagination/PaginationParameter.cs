using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LebaneseHomemade.Data.Pagination
{
    public class PaginationParameter
    {
        private const int maxPageSize = 20;
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        
        }
    }
}
