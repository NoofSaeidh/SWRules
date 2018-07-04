using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // POST: Powers/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Book,Points,Duration,Distance,Rank,Trappings,Text,IsDeleted,DeleterUserId,DeletionTime,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId,Id")] Power power)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _powersRepo.Add(power);
        //        await _powersRepo.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(power);
        //}

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

        // POST: Powers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,Book,Points,Duration,Distance,Rank,Trappings,Text,IsDeleted,DeleterUserId,DeletionTime,LastModificationTime,LastModifierUserId,CreationTime,CreatorUserId,Id")] Power power)
        //{
        //    if (id != power.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _powersRepo.Update(power);
        //            await _powersRepo.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PowerExists(power.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(power);
        //}

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
    }
}
