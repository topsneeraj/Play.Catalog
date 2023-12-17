using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using play.Catalog.Service.Dtos;
using play.Catalog.Service.Entities;
using play.Common.Repository;

namespace play.Catalog.Service.Controllers {

[ApiController]
[Route("items")]
  public class ItemsController :ControllerBase {

  private readonly IRepositroy<Item> itemsRepositroy;

  public ItemsController(IRepositroy<Item> itemsRepositroy){
            
            this.itemsRepositroy  = itemsRepositroy;
  }
   [HttpGet]
    public async Task <IEnumerable<ItemDto>> Get(){

        var items  =  (await itemsRepositroy.GetAllSync()).Select(item => item.asDto());
        return items;
    }


    [HttpGet("{id}")]

    public async Task <ActionResult<ItemDto>> GetByIdAsync(Guid id){

        var item =  await itemsRepositroy.GetAsync(id);
        if(item == null){
          return NotFound();
        }
        return item.asDto();
    }

    [HttpPost]
    public async Task< ActionResult> PostAsync(CreateItemDto createItem){
      
      var item = new Item{
        Name = createItem.Name,
        Descriptions = createItem.Descriptions,
        price  = createItem.Price,
        createdDate = DateTimeOffset.UtcNow
      };
          await itemsRepositroy.CreateAsync(item);
        return CreatedAtAction(nameof(GetByIdAsync), new {id = item.Id},item);
        
    }
    [HttpPut("{id}")]
    public async Task <IActionResult> PutAsync(Guid id,UpdateItemDto updatedItem){
     
       var existingItem  = await itemsRepositroy.GetAsync(id);

       if(existingItem == null)
       {
       
           return NotFound();
        
       }
     
      existingItem.Name = updatedItem.Name;
      existingItem.Descriptions  = updatedItem.Descriptions;
      existingItem.price  = updatedItem.price;

       await itemsRepositroy.UpdateAsync(existingItem);

      return NoContent();
    }
  
  [HttpDelete("{id}")]
  public async Task< IActionResult> Delete(Guid id){
    
   var item  = itemsRepositroy.GetAsync(id);
   if(item == null){
    return NotFound();
   }
    await itemsRepositroy.RemoveAync(id);
   return NoContent();

  }
 
  }

}