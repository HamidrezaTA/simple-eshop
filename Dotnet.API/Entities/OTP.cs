namespace api.Entities
{
    public class OTP : BaseEntity<long>
    {
        public required string MobileNumber { get; set; }
        public required string Code { get; set; }
        public DateTimeOffset ExpireAt { get; set; }
    }
}