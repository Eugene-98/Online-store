using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_store.Models;
using Online_store.ViewModel;

namespace Online_store.Controllers
{
	public class AccountController : Controller
	{
		public readonly UserManager<UserModel> _userManager;
		public readonly SignInManager<UserModel> _signInManager;

		public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				UserModel user = new UserModel
				{
					UserName = model.Username
				};

				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, false);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return View(model);
		}
	}
}
