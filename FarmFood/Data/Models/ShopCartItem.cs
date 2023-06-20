namespace FarmFood.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; } // ID объекта

        public Product product { get; set; }

        public string shopCartID { get; set; }

        public int quantity { get; set; }
    }
}