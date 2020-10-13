using System.Collections.Generic;

namespace CompanyAuidit.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Mission { get; set; }

        public virtual ICollection<UserAndInventoriyRelationship> UserAndInventoriyRelationships { get; set; }
    }
}