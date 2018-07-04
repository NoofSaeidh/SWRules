using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using noofs.SWRules.Rules;
using noofs.SWRules.Web.Views.Powers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noofs.SWRules.Web.Controllers
{
    public class PowersController : SWRulesControllerBase
    {
        public PowersController(IRepository<Power> powers)
        {
            Powers = powers;
        }

        protected IRepository<Power> Powers { get; }

        public async Task<ActionResult> Index()
        {
            var powers = await Powers
                .GetAll()
                .Where(p => p.Book != PowerConsts.DeadLandsOld)
                .OrderBy(p => p.Name)
                .ToAsyncEnumerable()
                .ToList();

            return View(new PowersListViewModel
            {
                Powers = powers
            });
        }
    }
}
