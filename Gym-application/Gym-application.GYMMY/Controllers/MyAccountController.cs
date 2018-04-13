using Microsoft.AspNetCore.Mvc;
using Gym_application.Repository.Models.IRepo;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Gym_application.Repository.Models.DataBase;
using System;
using Gym_application.Repository.Models.ViewModels;

namespace Gym_application.GYMMY.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        private ISizesRepo _context_Sizes;
        private IUser_DetailRepo _context_UserDetail;
        public MyAccountController(ISizesRepo repo1,IUser_DetailRepo repo2)
        {
            _context_Sizes = repo1;
            _context_UserDetail = repo2;
        }

        public async Task<IActionResult> Index() //like edit action for calculators
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserDetail = await _context_UserDetail.GetUserDetail(userId);
            if (UserDetail == null)
            {
               return RedirectToAction("Create");
            }            
            else
            {
                MyAccountViewModel viewMo = new MyAccountViewModel() { UserDetail = UserDetail, Sizes = await _context_Sizes.GetActualSize(userId)?? new Size()};
                return View(viewMo);
            }
        }
       
        //[Bind("Somatotyp,Aim,Height,Sex,Activity")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("UserDetail,UserDetail.Aim,UserDetail.Somatotyp,UserDetail.Age,UserDetail.Sex,UserDetail.Activity,UserDetail.Calculator_Type,UserDetail.Authomatic_calculate,UserDetail.Calories_after_BMR_multiply_activity,UserDetail.Calories_for_calculators," +
            "Sizes,Sizes.Weight,Sizes.Biceps,Sizes.Waist,Sizes.Height,Sizes.Chest,Sizes.Thigh,Sizes.Forearm,Sizes.Hips,Sizes.Fat,Sizes.Muscle_Mass")] MyAccountViewModel myModel, short new_BMR, bool save_new_BMR)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (save_new_BMR == true)
                    {
                        myModel.UserDetail.Calories_after_BMR_multiply_activity = new_BMR;
                    }
                    string userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    myModel.Sizes.Kind_Of_Sizes = Kind_of_Sizes.Actual;
                    myModel.Sizes.Create_Date = DateTime.Now;
                    myModel.Sizes.UserId=userid ;
                    myModel.UserDetail.Id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _context_Sizes.SaveActualSizes(myModel.Sizes);
                    await _context_Sizes.SaveChangesAsync();
                    _context_UserDetail.UpdateUserDetail(myModel.UserDetail);
                    await _context_UserDetail.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return View(myModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Somatotyp,Aim,Height,Sex,Activity")] User_Detail user_Detail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    user_Detail.Id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _context_UserDetail.Add_User_Detail(user_Detail);
                    await _context_UserDetail.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return View(user_Detail);
        }

        // GET: Diet/Edit/5
        public async Task<IActionResult> Edit()
        {           
            var diet = await _context_UserDetail.GetUserDetail(User.Identity.Name);
            if (diet == null)
            {
                return NotFound();
            }
            return View(diet);
        }

        // POST: Diet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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



        public IActionResult Sizes()
        {
            //string userId = User.Identity.Id;
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_context_Sizes.GetUserSizes(userId));
        }
    }
}