using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.Paging
{
    public class Paging<T>
    {
        public int? TotalEntities { get; set; }    
        public int? TotalPages { get; set; }
        public int? PageNumber { get; set; }    
        public int? PageSize { get; set; }
        public IEnumerable<T>? Results { get; set; }
    }
}
