using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public DateTime Created { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}
