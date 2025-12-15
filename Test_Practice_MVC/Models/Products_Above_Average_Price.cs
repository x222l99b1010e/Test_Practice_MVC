using System;
using System.Collections.Generic;

namespace Test_Practice_MVC.Models;

public partial class Products_Above_Average_Price
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
