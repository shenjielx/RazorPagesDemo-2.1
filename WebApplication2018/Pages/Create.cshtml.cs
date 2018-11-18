using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2018.Pages
{
	public class CreateModel : PageModel
	{

		[BindProperty]
		public InputForm Input { get; set; }
		public sealed class InputForm
		{
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			public List<Item> Items { get; set; }

			public sealed class Item
			{
				public int ID { get; set; }
				[Required]
				public string Name { get; set; }
				public string Age { get; set; }
			}
		}

		public void OnGet()
		{
			Input = new InputForm
			{
				Items = new List<InputForm.Item>
				{
					new InputForm.Item{ID=1}
				}
			};
		}

		public void OnPost()
		{
			var model = Input;
		}

		public void OnPostAddItem()
		{
			var model = Input;
			Input.Items.Add(new InputForm.Item { ID = Input.Items.Max(x => x.ID) + 1 });
		}
	}
}