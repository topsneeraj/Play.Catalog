using play.Catalog.Service.Dtos;
using play.Catalog.Service.Entities;
namespace  play.Catalog.Service 
{
    public static class Extentions
    {
        public static ItemDto asDto(this Item item)
        {
            return new ItemDto(item.Id,item.Name,item.Descriptions,item.price,item.createdDate);
        }
    }
}
