using BookStore.Domain.Common;

namespace BookStore.Domain
{
    public class Orders : BaseDomainEntity
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public List<Books> Books { get; set; }
    }
}
