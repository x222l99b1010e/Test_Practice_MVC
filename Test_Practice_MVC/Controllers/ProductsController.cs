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
			//查詢
			var query = _context.Products.AsQueryable();
			//將變數賦予查詢結果
			if (!string.IsNullOrWhiteSpace(keyword))
			{
				query = query.Where(p => p.ProductName.Contains(keyword));
			}
			//將查詢結果丟回VM
			var vm = new ProductsIndexViewModel
			{
				Products = query.ToList(),
				Keyword = keyword
			};
			//回傳VM
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
