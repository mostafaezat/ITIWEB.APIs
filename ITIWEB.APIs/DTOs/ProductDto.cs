using Core.Entities;

namespace ITIWEB.APIs.DTOs
{
    // DTO :: Data Transfer Object
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public int ProductBrandId { get; set; } 
        public int ProductTypeId { get; set; }
        public string ProductBrand { get; set; }
        public string ProductType { get; set; }
    }
}
