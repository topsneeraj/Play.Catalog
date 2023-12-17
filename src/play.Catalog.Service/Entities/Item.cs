using System;
using play.Common;
namespace play.Catalog.Service.Entities
 {
    public class  Item : IEntity
    {
        public Guid Id {get; set;}
        public string Name  {get; set;}

        public string Descriptions {get; set;}

        public decimal price {get; set;}

        public DateTimeOffset createdDate {get; set;}
    }
}