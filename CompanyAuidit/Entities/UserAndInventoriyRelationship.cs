using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Entities
{
    public class UserAndInventoriyRelationship
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int InventoriyId { get; set; }
    }
}
