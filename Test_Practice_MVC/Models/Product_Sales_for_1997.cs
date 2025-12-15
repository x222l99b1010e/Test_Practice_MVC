using System;
using System.Collections.Generic;

namespace Test_Practice_MVC.Models;

public partial class Product_Sales_for_1997
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}
