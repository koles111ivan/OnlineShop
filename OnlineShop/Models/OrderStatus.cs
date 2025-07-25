﻿using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Models
{
    public enum OrderStatus
    {
        [Display(Name ="Создан")]
        Created,
        [Display(Name = "Обработан")]
        Processed,
        [Display(Name = "В пути")]
        Delivering,
        [Display(Name = "Доставлен")]
        Delivered,
        [Display(Name = "Отменен")]
        Canceled
    }
}