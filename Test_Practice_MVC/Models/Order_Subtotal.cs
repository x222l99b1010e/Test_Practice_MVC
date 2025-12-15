using System;
using System.Collections.Generic;

namespace Test_Practice_MVC.Models;

public partial class Order_Subtotal
{
    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
