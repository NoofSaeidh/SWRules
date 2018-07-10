using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using noofs.SWRules.EntityFrameworkCore;
using noofs.SWRules.Powers;
using noofs.SWRules.Powers.Dto;

namespace noofs.SWRules.Web.Controllers
{
    public class PowersController : SWRulesControllerBase
    {
        public PowersController(PowersAppService powersAppService)
        {
            PowersAppService = powersAppService;
        }

        protected PowersAppService PowersAppService { get; }

        // GET: Powers
        public async Task<IActionResult> Index()
        {
            //todo: tmp, remove
            var result = await PowersAppService.GetAll(new GetAllPowersInput
            {
                MaxResultCount = 1000,
            });

            return View(result);
        }

        // GET: Powers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await PowersAppService.Get(id);
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
        public async Task<IActionResult> Create(CreatePowerInput power)
        {
            if (ModelState.IsValid)
            {
                await PowersAppService.Create(power);
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

            var power = await PowersAppService.Get(id);
            if (power == null)
            {
                return NotFound();
            }
            return View(power);
        }

        //POST: Powers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UseCase(Description = "Admin updates powers")]
        public async Task<IActionResult> Edit(int id, UpdatePowerInput power)
        {
            if (id != power.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await PowersAppService.Update(power);
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

            var power = await PowersAppService.Get(id);
                
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
            await PowersAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PowerExists(int id)
        {
            return await PowersAppService.Get(id) != null;
        }
    }
}
