namespace api.Entities
{
    public class Address : BaseEntitySoftDelete<long>
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required long PostalCode { get; set; }
        public required string Description { get; set; }

        public long UserId { get; set; }
        public required User User { get; set; }

        //TODO: A: Location property for address entity.
    }
}