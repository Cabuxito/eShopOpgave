﻿using eShop.DataLayer.Entities;
using eShop.DataLayer.Entities.JoinerTables;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int ProductId { get; set; } // PK
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public string Manufacture { get; set; }


    //Navigations Property

    public int? ImageId { get; set; } // FK
    public Image? Image { get; set; }


    public ICollection<OrderProduct> Orders { get; set; }
    public ICollection<CategoryProducts> Category { get; set; }

}

