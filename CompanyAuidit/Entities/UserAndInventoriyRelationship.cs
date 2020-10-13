namespace CompanyAuidit.Entities
{
    public class UserAndInventoriyRelationship
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int InventoriyId { get; set; }
        public Inventoriy Inventoriy { get; set; }
    }
}