namespace CnabImporter.Domain.Models;

public static class TransactionTypeMap
{
    private static readonly Dictionary<int, int> Signs = new()
    {
        { 1, 1 },   // Debit
        { 2, -1 },  // Boleto
        { 3, -1 },  // Financing
        { 4, 1 },   // Credit
        { 5, 1 },   // Loan Receipt
        { 6, 1 },   // Sales
        { 7, 1 },   // TED Receipt
        { 8, 1 },   // DOC Receipt
        { 9, -1 }   // Rent
    };

    public static int GetSign(int type) => Signs.GetValueOrDefault(type, 0);
}