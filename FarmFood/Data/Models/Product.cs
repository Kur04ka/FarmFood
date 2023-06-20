using System;

namespace FarmFood.Data.Models
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public string desc { get; set; }

        public string img { get; set; }

        public ushort price { get; set; }

        public string categoryName { get; set; }

        public virtual Category Category { get; set; }

        public int quantity { get; set; }

        public string unitOfMeasure { get; set; }

        public string cityOfOrigin { get; set; }

        public string sellerName { get; set; }

        public string sellerEmail { get; set; }

        public string dateOfRegistration { get; set; }
    }
}
