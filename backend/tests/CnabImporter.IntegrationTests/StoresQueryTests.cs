using CnabImporter.Infrastructure.Repositories.Stores;

namespace CnabImporter.IntegrationTests
{
    public class StoresQueryTests : IntegrationTestsBase
    {
        private StoreRepository _storeRepository;

        [SetUp]
        public void Init()
        {
            _storeRepository = new StoreRepository(Context);
        }

        [Test]
        public async Task GetStores_ReturnsSeededStores()
        {
            var stores = await _storeRepository.GetStoresAsync(0, 10);
            Assert.IsTrue(stores.Count >= 2);
        }
    }
}