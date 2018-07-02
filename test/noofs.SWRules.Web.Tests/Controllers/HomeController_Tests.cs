using System.Threading.Tasks;
using noofs.SWRules.Web.Controllers;
using Shouldly;
using Xunit;

namespace noofs.SWRules.Web.Tests.Controllers
{
    public class HomeController_Tests: SWRulesWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
