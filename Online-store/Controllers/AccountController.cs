using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_store.Data;
using Online_store.Models;
using Online_store.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Online_store.Controllers
{
	public class AccountController : Controller
	{
		private readonly StoreContext _context;
		private int NextId = 10;

		public AccountController(StoreContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				UserModel user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Username);
				if (user == null)
				{
					_context.Users.Add(new UserModel {Name = model.Username, Password = model.Password, Id = NextId});
					await _context.SaveChangesAsync();
					NextId++;

					await Authenticate(model.Username);

					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Invalid login or password");
				}
			}

			return View(model);
		}

		

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				UserModel user =
					await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Username && u.Password == model.Password);
				if (user != null)
				{
					await Authenticate(model.Username);

					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Invalid username or password");
			}

			return View(model);
		}
		private async Task Authenticate(string username)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, username)
			};

			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}
	}
}
