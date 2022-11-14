﻿
namespace DO;

public struct Product
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
    public Category Category { get; set; }  //public string? ProductCategory { get; set; }
    public int? inStock { get; set; }
    public override string ToString() => $@"
ID               ={ID},
Name             ={Name},
Price            ={Price},
Category         ={Category},
inStock          ={inStock}
";
}
