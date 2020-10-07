using CompanyAuidit.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Contexts
{
    public class AccessContext:DbContext
    {
        public AccessContext(DbContextOptions<AccessContext> options):base (options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Inventoriy> Inventories { get; set; }
        public DbSet<UserAndInventoriyRelationship> UserAndInventoriyRelationship { get; set; }
    }
}
