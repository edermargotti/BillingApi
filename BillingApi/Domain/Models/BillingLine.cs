using System.Text.Json.Serialization;

namespace BillingApi.Domain.Models
{
    public class BillingLine
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        [JsonPropertyName("unit_price")]
        public int UnitPrice { get; set; }
        public int SubTotal { get; set; }
    }
}
