using noofs.SWRules.EntityFrameworkCore;

namespace noofs.SWRules.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly SWRulesDbContext _context;

        public TestDataBuilder(SWRulesDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}