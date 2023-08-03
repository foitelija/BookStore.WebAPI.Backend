using BookStore.Domain.Common;

namespace BookStore.Domain
{
    public class Orders : BaseDomainEntity
    {
        public string CustomerName { get; set; }
    }
}
