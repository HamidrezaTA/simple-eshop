namespace api.Entities;
public class BaseEntitySoftDelete<T> : BaseEntity<T>
{
    public DateTimeOffset? DeletedAt { get; set; }
}
