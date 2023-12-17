using System;
using System.ComponentModel.DataAnnotations;

namespace play.Catalog.Service.Dtos {

  public record  ItemDto(Guid Id,string Name,string Descriptions, decimal Price, DateTimeOffset CreatedDate);
  public record CreateItemDto([Required] string Name, string Descriptions,[Range(0,1000)] decimal Price);

  public record UpdateItemDto([Required] string Name,string Descriptions, [Range(0,1000)] decimal price); 
}