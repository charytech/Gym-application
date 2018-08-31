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
using Newtonsoft.Json;

namespace Gym_application.GYMMY.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Meal__Nutritional_Value")]
    public class Meal__Nutritional_ValueController : Controller
    {
        private readonly IMealRepo _context;
        private readonly INutritional_ValuesRepo _context_Nutritional_Values;

        public Meal__Nutritional_ValueController( IMealRepo context,INutritional_ValuesRepo context2)
        {
            _context = context;
            _context_Nutritional_Values = context2;
        }
        [HttpGet]
        public async Task<List<Nutritional_Value>> GetMeal__Nutritional_Values()
        {
            return await _context_Nutritional_Values.GetValuesAsync();

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
        public async Task<JsonResult> PostMeal__Nutritional_Value([FromBody]MealViewModel data)
        {
            List<KeyValuePair<string, string>> result_message = new List<KeyValuePair<string, string>>();
            if (!ModelState.IsValid)
            {
                result_message.Add(new KeyValuePair<string, string>("message", "Wrong model"));
                return Json(result_message);
            }
            var UserId = User.getUserId();

            if (await _context.CheckAccessToDiet(UserId, data.Meal.Id)==false)
            {
                result_message.Add(new KeyValuePair<string, string>("message", "Can't access to data"));
                return Json(result_message);
            }
            try
            {
                bool result = await _context.Check__Modify_Save(data, UserId);
                await _context.Upadate_Meal(data.Meal.Id, _context.Calculate_makro(data));
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                result_message.Add(new KeyValuePair<string, string>("message", e.Message));
                return Json(result_message);

            }

            //_context.Meal__Nutritional_Values.Add(meal__Nutritional_Value);
            //await _context.SaveChangesAsync();
            result_message.Add(new KeyValuePair<string, string>("message", "Saved"));
            return Json(result_message);

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