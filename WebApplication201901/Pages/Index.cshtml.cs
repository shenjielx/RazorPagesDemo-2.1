using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication201901.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty] public InputForm Input { get; set; }
		[TempData] public string Message { get; set; }
		public sealed class InputForm
		{
			public string UserName { get; set; }
			[Required, EmailAddress]
			public string Email { get; set; }
		}

		public IActionResult OnPost()
		{
			var temp = Input;
			if (ModelState.IsValid)
			{
				Message = "Valid is Successfully.";
				return RedirectToPage();
			}
			return Page();
		}

	}
}
