namespace api.Entities
{
    public class StoredFile : BaseEntity<long>
    {
        public required string Url { get; set; }
    }
}