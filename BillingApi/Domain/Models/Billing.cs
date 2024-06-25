using System.Text.Json.Serialization;

namespace BillingApi.Domain.Models
{
    public class Billing
    {
        [JsonPropertyName("invoice_number")]
        public string InvoiceNumber { get; set; }

        public Customer Customer { get; set; }
        public DateTime Date { get; set; }

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }
        public string Currency { get; set; }
        public List<BillingLine> Lines { get; set; }
    }
}


/*
 "invoice_number": "INV-001",
        "customer": {
            "id": "12081264-5645-407a-ae37-78d5da96fe59",
            "name": "Cliente Exemplo 1",
            "email": "cliente1@example.com",
            "address": "Rua Exemplo 1, 123"
        },
        "date": "2024-02-01",
        "due_date": "2024-02-08",
        "total_amount": 100,
        "currency": "BRL",
        "lines": [{
                "productId": "48c6dc20-a943-4f8f-83ca-1e1cf094a683",
                "description": "Produto 1",
                "quantity": 2,
                "unit_price": 25,
                "subtotal": 50
            }, {
                "productId": "48c6dc20-a943-4f8f-83ca-1e1cf094a612",
                "description": "Produto 2",
                "quantity": 1,
                "unit_price": 50,
                "subtotal": 50
            }
        ]
 */