namespace BillingApi.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BillingLine> BillingLine { get; set; }
    }
}
