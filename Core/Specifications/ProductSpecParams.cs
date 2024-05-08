using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        public string? sort { get; set; }
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public int pageIndex { get; set; } 
        public int pageSize { get; set; }
    }
}
