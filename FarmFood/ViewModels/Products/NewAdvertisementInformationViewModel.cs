using FarmFood.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FarmFood.ViewModels.Products
{
    public class NewAdvertisementInformationViewModel
    {
        //TODO: Доделать атрибуты

        [Required(ErrorMessage = " ")]
        public string productName { get; set; }

        [Required(ErrorMessage = " ")]
        public string productDescription { get; set; }

        [Required(ErrorMessage = " ")]
        public ushort productQuantity { get; set; }

        [Required(ErrorMessage = " ")]
        public ushort productPrice { get; set; }

        [Required(ErrorMessage = " ")]
        public string email { get; set; }

        [Required(ErrorMessage = " ")]
        public string unitOfMeasure { get; set; }

        [Required(ErrorMessage = " ")]
        public string sellerName { get; set; }

        [Required(ErrorMessage = " ")]
        public string categoryName { get; set; }
    }
}
