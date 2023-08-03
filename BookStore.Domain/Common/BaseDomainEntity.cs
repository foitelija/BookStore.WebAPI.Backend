namespace BookStore.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
    }
}
