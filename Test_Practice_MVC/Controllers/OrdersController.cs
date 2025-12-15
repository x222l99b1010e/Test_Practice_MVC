using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Practice_MVC.Models;
using Test_Practice_MVC.Models.ViewModels;

namespace Test_Practice_MVC.Controllers
{
	

	public class OrdersController : Controller
	{
		private readonly NorthwindContext _context;

		public OrdersController(NorthwindContext context)
		{
			_context = context;
		}

		public IActionResult Index(int? SelectedOrderId)
		{
			var vm = new OrderViewModel();

			//下拉選單資料
			vm.Orders = _context.Orders
				.Include(o => o.Employee)
				.Select(o => new SelectListItem
				{
					Value = o.OrderID.ToString(),
					Text = $"{o.OrderID} - {o.Employee.LastName}"
				})
				.ToList();

			//若有選 Order
			if (SelectedOrderId.HasValue)
			{
				var order = _context.Orders
					.Include(o => o.Employee)
					.Include(o => o.Order_Details)
					.FirstOrDefault(o => o.OrderID == SelectedOrderId.Value);

				if (order != null)
				{
					vm.SelectedOrderId = order.OrderID;
					vm.OrderDate = order.OrderDate;
					vm.EmployeeName = $"{order.Employee?.LastName} {order.Employee?.FirstName}";
					vm.OrderDetails = order.Order_Details.ToList();
					Console.WriteLine($"OrderId={order.OrderID}, Details={order.Order_Details.Count}");
				}

				if (order == null)
					Console.WriteLine($"找不到 OrderId {SelectedOrderId}");
			}
			return View(vm);
		}
	}
}
