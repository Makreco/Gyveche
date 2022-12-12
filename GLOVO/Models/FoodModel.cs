using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLOVO.Models
{
    public class FoodModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Ястие")]
        public string FoodName { get; set; }
        [Required]
        [DisplayName("Описание")]
        public string FoodDescription { get; set; }
        [Required]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Снимка")]
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("Грамаж")]
        public decimal FoodWeight { get; set; }
        [Required]
        [DisplayName("Брой поръчки")]
        public int OrdersCount { get; set; }

        public FoodModel(int id, string foodName, string foodDescription, decimal price, string imageUrl, decimal foodWeight, int ordersCount)
        {
            Id = id;
            FoodName = foodName;
            FoodDescription = foodDescription;
            Price = price;
            ImageUrl = imageUrl;
            FoodWeight = foodWeight;
            OrdersCount = ordersCount;
        }
        public FoodModel()
        {

        }
    }
}