using CompanyAuidit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    public class RelationListViewModel
    {
        public List<Inventory> Inventory { get; set; }
        public User User { get; set; }
        public List<Inventory> Items { get; set; }
    }
}
