using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using noofs.SWRules.Powers.Dto;
using noofs.SWRules.Powers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noofs.SWRules.Powers
{
    public class PowersAppService : AsyncCrudAppService<Power, PowerDto, int, GetAllPowersInput, CreatePowerInput, UpdatePowerInput>
    {
        public PowersAppService(IRepository<Power, int> repository) : base(repository)
        {
        }

        protected override IQueryable<Power> CreateFilteredQuery(GetAllPowersInput input)
        {
            // todo: make configurable
            return base.CreateFilteredQuery(input).Where(p => p.Book != PowerConsts.Books.DeadLandsOld);
        }

    }
}
