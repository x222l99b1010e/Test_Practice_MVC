namespace Test_Practice_MVC.Models.ViewModels
{
	public class ProductsIndexViewModel
	{
		public List<Product> Products { get; set; } = new();

		//搜尋條件（Keyword）不屬於資料表欄位
		public string? Keyword { get; set; }
	}
}
