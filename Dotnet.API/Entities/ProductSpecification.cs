namespace api.Entities
{
    public class ProductSpecification : BaseEntitySoftDelete<long>
    {
        public long ProductId { get; set; }
        public required Product Product { get; set; }

        public long SpecificationId { get; set; }
        public required Specification Specification { get; set; }

        public required string Value { get; set; }
    }
}