using Microsoft.AspNetCore.Mvc;
using Test_Practice_MVC.Models;
using Test_Practice_MVC.Models.ViewModels;

namespace Test_Practice_MVC.Controllers
{
	public class ProductsController : Controller
	{
		//Controller 要用 DB，一定要注入
		private readonly NorthwindContext _context;//唯讀 

		//DI（依賴注入）
		public ProductsController(NorthwindContext context)//
		{
			_context = context;
		}
		public IActionResult Index(string? keyword)
		{
			var query = _context.Products.AsQueryable();
			if (!string.IsNullOrWhiteSpace(keyword))
			{
				query = query.Where(p => p.ProductName.Contains(keyword));
			}

			var vm = new ProductsIndexViewModel
			{
				Products = query.ToList(),
				Keyword = keyword
			};

			return View(vm);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(ProductsCreateViewModel vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			var product = new Product
			{
				ProductName = vm.ProductName,
				UnitPrice = vm.UnitPrice,
				UnitsInStock = vm.UnitsInStock
			};

			_context.Products.Add(product);
			_context.SaveChanges();

			TempData["Success"] = "新增成功";
			return RedirectToAction("Index");

		}
	}
}
