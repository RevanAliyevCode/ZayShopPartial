using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZayShopMVC.Areas.Admin.Models.Product;

public class ProductUpdateVM
{
    [Required(ErrorMessage = "Please enter product name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter product description")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Please enter product price")]
    public decimal Price { get; set; }

    public IFormFile? ImageFile { get; set; }

    public string? ImageName { get; set; }
    
    [Required(ErrorMessage = "Please enter product stock")]
    public int Stock { get; set; }

    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    public List<SelectListItem>? Categories { get; set; }

    [Display(Name = "Size")]
    public List<int> SizeIds { get; set; }

    public List<SelectListItem>? Sizes { get; set; }
}
