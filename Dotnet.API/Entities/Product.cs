namespace api.Entities
{
    public class Product : BaseEntitySoftDelete<long>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ShortDescription { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }

        public long CategoryId { get; set; }
        public required Category Category { get; set; }

        public ICollection<ProductSpecification>? ProductSpecifications { get; set; }
        public ICollection<StoredFile>? Images { get; set; }

        //TODO: B: R&D about seo link and all the things related to seo topic.
    }
}