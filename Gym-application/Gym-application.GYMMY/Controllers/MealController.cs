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
using Microsoft.AspNetCore.Authorization;

namespace Gym_application.GYMMY.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        private readonly IMealRepo _context;
        private readonly INutritional_ValuesRepo _context2;

        public MealController(IMealRepo context,INutritional_ValuesRepo context2)
        {
            _context = context;
            _context2 = context2;

        }

        // GET: Meal
        //public async Task<IActionResult> Index(int id)
        //{
        //    return View(await _context.GetMealAsync(id));
        //}


        //public JsonResult Data_Meal(int id) {
        //    return Json(_context.MealData((int)id));
        //}
        public async Task<JsonResult> Values()
        {
            return Json(await _context2.GetValuesAsync());
        }
        public async Task<JsonResult> Mealdata(int id)
        {
            return Json(await _context.MealData((int)id));
        }

        // GET: Meal/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? Did,int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.MealData((int)id);
            if (data == null)
            {
                return NotFound();
            }
            ViewBag.DietId = Did;
            return View(data);
        }

        // GET: Meal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Calories,Protein,Fat,Carbohydrates")] Meal meal)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(meal);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(meal);
        //}

        //// GET: Meal/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var meal = await _context.Meals.SingleOrDefaultAsync(m => m.Id == id);
        //    if (meal == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(meal);
        //}

        //// POST: Meal/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Calories,Protein,Fat,Carbohydrates")] Meal meal)
        //{
        //    if (id != meal.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(meal);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MealExists(meal.Id))
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
        //    return View(meal);
        //}

        //// GET: Meal/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var meal = await _context.Meals
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (meal == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(meal);
        //}

        //// POST: Meal/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var meal = await _context.Meals.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Meals.Remove(meal);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MealExists(int id)
        //{
        //    return _context.Meals.Any(e => e.Id == id);
        //}
    }
}
