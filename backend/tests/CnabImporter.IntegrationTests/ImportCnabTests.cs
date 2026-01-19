using CnabImporter.Application.Commands.ImportCnab;
using CnabImporter.Infrastructure.Repositories.Stores;
using CnabImporter.Infrastructure.Repositories.Transactions;

namespace CnabImporter.IntegrationTests
{
    public class ImportCnabTests : IntegrationTestsBase
    {
        private ImportCnabCommandHandler _handler;
        private StoreRepository _storeRepository;
        private ITransactionRepository _transactionRepository;

        [SetUp]
        public void Init()
        {
            _storeRepository = new StoreRepository(Context);
            _transactionRepository = new TransactionRepository(Context);
            _handler = new ImportCnabCommandHandler(_storeRepository, _transactionRepository);
        }

        [Test]
        public async Task Handle_ValidCnabFile_SavesStoresAndTransactions()
        {
            // Arrange: sample CNAB content
            var fileContent = string.Join("\n",
                "3201903010000014200096206760174753****3153153453120000JOÃO MACEDO   BAR DO JOÃO   ",
                "5201903010000013200556418150633123****7687145607123456MARIA JOSEFINALOJA DO Ó - MATRIZ"
            );

            var command = new ImportCnabCommand(fileContent, "test.cnab");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsTrue(result);

            var stores = await _storeRepository.GetStoresAsync(0, 10);

            Assert.IsTrue(stores.Count >= 2, "At least 2 stores imported");
            Assert.IsTrue(stores.Sum(x => x.Transactions.Count) >= 2, "At least 2 transactions imported");
        }
    }
}