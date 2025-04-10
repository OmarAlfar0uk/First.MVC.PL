using First.DAL.Models.IdentityModel;
using First.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace First.PL.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
              if(!ModelState.IsValid) return View(viewModel);
            var User = new AppUser()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                UserName = viewModel.UserName,
                Email = viewModel.Email

            };

           var Result = _userManager.CreateAsync(User, viewModel.Password).Result;
            if(Result.Succeeded)
            {
                return RedirectToAction("Login");   
            }
            else
            {
                foreach(var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(viewModel);
            }
        }

    }
}
