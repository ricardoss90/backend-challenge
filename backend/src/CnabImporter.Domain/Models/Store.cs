namespace CnabImporter.Domain.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Owner { get; set; } = null!;

        // Navigation property
        public List<Transaction> Transactions { get; set; } = [];

        // Computed property for store balance
        public decimal Balance => Transactions.Sum(t => t.SignedValue);
    }
}