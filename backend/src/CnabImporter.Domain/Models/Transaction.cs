namespace CnabImporter.Domain.Models;

public class Transaction
{
    public int Id { get; set; }

    // Foreign key
    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;

    public int TransactionType { get; set; }
    public string Cpf { get; set; } = null!;
    public string Card { get; set; } = null!;
    public decimal Value { get; set; }

    // Signed value based on transaction type
    public decimal SignedValue => Value * TransactionTypeMap.GetSign(TransactionType);
}