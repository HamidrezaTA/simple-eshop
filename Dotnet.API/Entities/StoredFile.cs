using api.Enums;

namespace api.Entities
{
    public class StoredFile : BaseEntity<long>
    {
        public PersistFileType Type { get; set; }
        public required string Url { get; set; }
    }
}