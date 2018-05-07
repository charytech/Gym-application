using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gym_application.Repository.Data;
using Gym_application.Repository.Models.DataBase;
using Gym_application.Repository.Models.IRepo;
using Gym_application.Repository.Models.ViewModels.DietViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Gym_application.GYMMY.Controllers
{
    [Authorize]
    public class DietController : Controller
    {
        private readonly IDietRepo _context;

        public DietController(IDietRepo context)
        {
            _context = context;
        }

        // GET: Diet
        public async Task<IActionResult> Index()
        {
            var dietlist = _context.UserDietList(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(await dietlist.ToListAsync());
        }

        //GET: Diet/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || !_context.Check_Access_to_Diet((int)id, this.User.FindFirstValue(ClaimTypes.NameIdentifier)) )
            {
                return NotFound();
            }
            
            //var diet = await _context.GetDiet((int)id);
            var model = _context.Get_Days_and_Meals_for_Diet((int)id).ToList();
            //if (model == null)
            //{
            //    return NotFound();
            //}
            ViewBag.DietId = id;
            return View(model);
        }

        //// GET: Diet/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Diet/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nazwa")] Diet diet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    diet.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    diet.Created_Date = DateTime.Now;
                    _context.AddDiet(diet);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = diet.Id });
                }
                catch(Exception e)
                {

                }
                
            }
            return View(diet);
        }

        //// GET: Diet/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var diet = await _context.Diets.SingleOrDefaultAsync(m => m.Id == id);
        //    if (diet == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", diet.UserId);
        //    return View(diet);
        //}

        //// POST: Diet/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,UserId,OwnerId,Created_Date")] Diet diet)
        //{
        //    if (id != diet.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(diet);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DietExists(diet.Id))
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
        //    ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", diet.UserId);
        //    return View(diet);
        //}

        //// GET: Diet/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var diet = await _context.Diets
        //        .Include(d => d.User)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (diet == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(diet);
        //}

        //// POST: Diet/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var diet = await _context.Diets.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Diets.Remove(diet);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DietExists(int id)
        //{
        //    return _context.Diets.Any(e => e.Id == id);
        //}
    }
}
