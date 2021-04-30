using Core.Services.Country;
using Core.Tests.ServiceSetup.Country;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests.Services.Country
{
    public class CountryUnitTest : IClassFixture<CountrySetup>
    {
        private readonly CountrySetup _setup;

        public CountryUnitTest(CountrySetup setup)
        {
            _setup = setup;
        }

        [Fact]
        public async Task GetBreadcrumb_Data_BreadcrumbSelectDtoList()
        {
            //Arrange
            var countryService = new CountryService(_setup._repoMoq, _setup._mapper);

            //Act
            var countryResult = await countryService.GetBreadCrumb(_setup.BreadcrumbFilterDtoTestData);

            //Assert
            Assert.NotNull(countryResult);
        }
    }
}