﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Вы не указали название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вы не указали цену")]
        [Range(0, 1000000, ErrorMessage = "Цена должна быть в пределах от 0 до 1 000 000 руб")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Вы не указали описание")]
        public string Description { get; set; }
        public string ImagePath { get; set; }
       
    }
}
