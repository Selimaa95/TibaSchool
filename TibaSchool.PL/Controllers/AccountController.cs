using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TibaSchool.BL.VModels;

namespace TibaSchool.PL.Controllers
{
    public class AccountController : Controller
    {

        #region Prop

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        #endregion

        #region Ctor

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #endregion

        #region Actions

        #region Registration

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {

            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(model);
        }


        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {
                //for login with username or email.
                /*var userName = await userManager.FindByNameAsync(model.UserName);
                var userEmail = await userManager.FindByEmailAsync(model.UserName);

                dynamic result;

                if (userEmail != null)
                {
                    result = await signInManager.PasswordSignInAsync(userEmail, model.Password, model.RememberMe, false);
                }
                else
                {
                    result = await signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
                }*/


                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminPanel");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User or Password");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Invalid User or Password");
            }

            return View(model);
        }

        #endregion

        #region Sign Out

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #endregion
    }
}
