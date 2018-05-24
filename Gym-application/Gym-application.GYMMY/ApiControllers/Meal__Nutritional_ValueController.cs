using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gym_application.Repository.Data;
using Gym_application.Repository.Models.DataBase;
using Gym_application.Repository.Models.IRepo;
using System.Net.Http;
using Gym_application.Repository.Models.ViewModels.MealViewModels;
using Gym_application.GYMMY.Common;

namespace Gym_application.GYMMY.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Meal__Nutritional_Value")]
    public class Meal__Nutritional_ValueController : Controller
    {
        private readonly IMealRepo _context;

        public Meal__Nutritional_ValueController(ApplicationDbContext context2, IMealRepo context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Nutritional_Value>> GetMeal__Nutritional_Values()
        {
            return await _context.GetValuesAsync();

        }
        // GET: api/Meal__Nutritional_Value
        //[HttpGet]
        //public IEnumerable<Meal__Nutritional_Value> GetMeal__Nutritional_Values()
        //{
        //    return _context.Meal__Nutritional_Values;
        //}

        //// GET: api/Meal__Nutritional_Value/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetMeal__Nutritional_Value([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var meal__Nutritional_Value = await _context.Meal__Nutritional_Values.SingleOrDefaultAsync(m => m.Id == id);

        //    if (meal__Nutritional_Value == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(meal__Nutritional_Value);
        //}

        // PUT: api/Meal__Nutritional_Value/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMeal__Nutritional_Value([FromRoute] int id, [FromBody] Meal__Nutritional_Value meal__Nutritional_Value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != meal__Nutritional_Value.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(meal__Nutritional_Value).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!Meal__Nutritional_ValueExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        [HttpPost]
        //public async Task<HttpResponseMessage> PostMeal__Nutritional_Value([FromBody]ValuesViewModel[] date, [FromBody] int id)
        public async Task<HttpResponseMessage> PostMeal__Nutritional_Value([FromBody]MealViewModel date)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            var UserId = User.getUserId();

            bool result =  await _context.Check__Modify_Save(date,UserId);

            //_context.Meal__Nutritional_Values.Add(meal__Nutritional_Value);
            //await _context.SaveChangesAsync();

            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }
        // POST: api/Meal__Nutritional_Value
        //[HttpPost]
        //public async Task<IActionResult> PostMeal__Nutritional_Value([FromBody] Meal__Nutritional_Value meal__Nutritional_Value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Meal__Nutritional_Values.Add(meal__Nutritional_Value);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMeal__Nutritional_Value", new { id = meal__Nutritional_Value.Id }, meal__Nutritional_Value);
        //}

        // DELETE: api/Meal__Nutritional_Value/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMeal__Nutritional_Value([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var meal__Nutritional_Value = await _context.Meal__Nutritional_Values.SingleOrDefaultAsync(m => m.Id == id);
        //    if (meal__Nutritional_Value == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Meal__Nutritional_Values.Remove(meal__Nutritional_Value);
        //    await _context.SaveChangesAsync();

        //    return Ok(meal__Nutritional_Value);
        //}

        //private bool Meal__Nutritional_ValueExists(int id)
        //{
        //    return _context.Meal__Nutritional_Values.Any(e => e.Id == id);
        //}
    }
   
}