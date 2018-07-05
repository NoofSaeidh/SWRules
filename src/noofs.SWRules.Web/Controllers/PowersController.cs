using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using noofs.SWRules.EntityFrameworkCore;
using noofs.SWRules.Rules;
using noofs.SWRules.Web.Views.Powers.ViewModels;

namespace noofs.SWRules.Web.Controllers
{
    public class PowersController : SWRulesControllerBase
    {
        private readonly IRepository<Power> _powersRepo;

        public PowersController(IRepository<Power> powersRepo)
        {
            _powersRepo = powersRepo;
        }

        // GET: Powers
        public async Task<IActionResult> Index()
        {
            //todo: configurable default filter
            var powers = await _powersRepo
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

        // GET: Powers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _powersRepo.FirstOrDefaultAsync((int)id);
            if (power == null)
            {
                return NotFound();
            }

            return View(power);
        }

        // GET: Powers/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Powers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([PowerEditBind] Power power)
        {
            if (ModelState.IsValid)
            {
                await _powersRepo.InsertAsync(power);
                return RedirectToAction(nameof(Index));
            }
            return View(power);
        }

        // GET: Powers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _powersRepo.FirstOrDefaultAsync((int)id);
            if (power == null)
            {
                return NotFound();
            }
            return View(power);
        }

        //POST: Powers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [PowerEditBind(withId: true)] Power power)
        {
            if (id != power.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _powersRepo.UpdateAsync(power);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PowerExists(power.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(power);
        }

        // GET: Powers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _powersRepo.FirstOrDefaultAsync((int)id);
            if (power == null)
            {
                return NotFound();
            }

            return View(power);
        }

        // POST: Powers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _powersRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PowerExists(int id)
        {
            return await _powersRepo.Query(async e => await e.AnyAsync(ee => ee.Id == id));
        }

        public class PowerEditBindAttribute : BindAttribute
        {
            protected static readonly string IdProperty = nameof(IEntity.Id);

            protected static readonly string[] Properties =
            {
                nameof(Power.Book),
                nameof(Power.Distance),
                nameof(Power.Duration),
                nameof(Power.Name),
                nameof(Power.Points),
                nameof(Power.Rank),
                nameof(Power.Text),
                nameof(Power.Trappings)
            };

            protected static readonly string[] PropertiesWithId;

            static PowerEditBindAttribute()
            {
                PropertiesWithId = new string[Properties.Length + 1];
                Array.Copy(Properties, PropertiesWithId, Properties.Length);
                PropertiesWithId[Properties.Length] = IdProperty;
            }

            public PowerEditBindAttribute(bool withId = false) 
                : base(withId ? PropertiesWithId : Properties)
            {
            }
        }
    }
}
