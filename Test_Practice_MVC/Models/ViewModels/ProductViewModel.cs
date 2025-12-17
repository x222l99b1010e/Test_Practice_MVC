using System.ComponentModel.DataAnnotations;//[Required]
namespace Test_Practice_MVC.Models.ViewModels
{
	public class ProductViewModel
	{
		//名稱要跟Model一樣
		public int ProductID { get; set; }

		[Required]
		public string? ProductName { get; set; }

		[Required]
		[Range(0.01,double.MaxValue)]//單價範圍
		public decimal UnitPrice { get; set; }//decimal

		[Required]
		[Range(0, short.MaxValue)]
		public short UnitsInStock { get; set; }//short

	}
}
