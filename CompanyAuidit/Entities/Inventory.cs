using System.Collections.Generic;

namespace CompanyAuidit.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public int StockAmount { get; set; }

        public List<UserAndInventoriyRelationship> UserAndInventoriyRelationships { get; set; }
    }
}