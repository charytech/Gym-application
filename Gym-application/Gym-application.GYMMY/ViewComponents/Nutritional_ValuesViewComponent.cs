using Gym_application.Repository.Models.IRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_application.GYMMY.ViewComponents
{
    public class Nutritional_ValuesViewComponent : ViewComponent
    {
        private readonly INutritional_ValuesRepo _context;

        public Nutritional_ValuesViewComponent(INutritional_ValuesRepo context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.GetValuesAsync();
            return View(items);
        }
        //private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        //{
        //    return db.ToDo.Where(x => x.IsDone == isDone &&
        //                         x.Priority <= maxPriority).ToListAsync();
        //}

    }
}
