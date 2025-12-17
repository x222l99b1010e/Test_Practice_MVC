using System.ComponentModel.DataAnnotations;

namespace Test_Practice_MVC.Models.ViewModels
{
	public class ProductsCreateViewModel
	{
		[Required]
		public string ProductName { get; set; } = null!;
		[Required]
		[Range(0.01,double.MaxValue)]//價格必須 > 0
		public decimal? UnitPrice { get; set; }
		[Required]
		[Range(0.01, short.MaxValue)]
		public short UnitsInStock { get; set; }
	}
}
