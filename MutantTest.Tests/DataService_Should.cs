using Microsoft.EntityFrameworkCore;
using MutantTest.Infra.Repository;
using MutantTest.Infra.Service;
using NuGet.Frameworks;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MutantTest.Tests
{
    public class DataService_Should
    {
        private IUserRepository _repository;
        private IUserDataService _dataService;
        
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<CoreContext>()
                .UseInMemoryDatabase("test_db")
                .Options;
                        
            _repository = new FakeUserRepository(new CoreContext(contextOptions));            
            _dataService = new UserDataService(_repository);
        }

        [TestCase("Suite 879")]
        [TestCase("- suite 745")]
        [TestCase("royal suite")]
        public void ShouldBeAbleToIdentifyIsSuiteTrue(string suite)
        {
            var userData = FakeDataGetter.GetFakeUserData(1, suite).ToList();
            Assert.IsTrue(userData[0].ToUserInfo().Address.IsSuite);
        }

        [TestCase("Apt. 556")]
        [TestCase("apt 41")]
        [TestCase("anything 52")]
        public void ShouldBeAbleToIdentifyIsSuiteFalse(string suite)
        {
            var userData = FakeDataGetter.GetFakeUserData(1, suite).ToList();
            Assert.IsFalse(userData[0].ToUserInfo().Address.IsSuite);
        }

        [Test]
        public async Task ShouldInsertOnlySuites()
        {
            var sampleData = FakeDataGetter.GetFakeUserData(6);
            var insertResult = await _dataService.SaveUserData(sampleData.Select(u => u.ToUserInfo()));

            int aptInserted = insertResult.Where(u => !u.Address.IsSuite).Count();            
            Assert.AreEqual(0, aptInserted);
        }
              

        
    }
}