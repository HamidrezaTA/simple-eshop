namespace api.Entities
{
    public class Category : BaseEntitySoftDelete<long>
    {
        public long? ParentId { get; set; }
        public required string Title { get; set; }
        public StoredFile? Image { get; set; }
    }
}