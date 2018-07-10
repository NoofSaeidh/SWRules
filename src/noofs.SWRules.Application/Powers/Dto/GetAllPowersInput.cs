using Abp.Application.Services.Dto;
using noofs.SWRules.Powers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noofs.SWRules.Powers.Dto
{
    public class GetAllPowersInput : PagedAndSortedResultRequestDto
    {
        // todo: make normal solution
        //public Func<IQueryable<Power>, IQueryable<Power>> Query { get; set; }
    }
}
