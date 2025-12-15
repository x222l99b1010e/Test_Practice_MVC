using Microsoft.AspNetCore.Mvc.Rendering;

namespace Test_Practice_MVC.Models.ViewModels
{
	public class OrderViewModel
	{
		//下拉選單
		public int? SelectedOrderId { get; set; }
		public List<SelectListItem> Orders { get; set; } = new();

		//上方顯示的Order欄位
		public DateTime? OrderDate { get; set; }
		public string? EmployeeName	{ get; set; }

		//下方全部OrderDetail全部欄位
		public List<Order_Detail> OrderDetails { get; set; } = new();
	}
}
