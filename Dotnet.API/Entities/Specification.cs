namespace api.Entities
{
    public class Specification : BaseEntitySoftDelete<long>
    {
        public required string Title { get; set; }
    }
}