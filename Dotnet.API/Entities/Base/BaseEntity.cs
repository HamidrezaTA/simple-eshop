namespace api.Entities;
public class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
