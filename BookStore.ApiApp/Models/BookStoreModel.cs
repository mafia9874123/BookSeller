using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models
{
    public class BookStoreModel
    {
        public string ISBNCode { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public StoreModel Store { get; set; }
    }

    public class StoreModel
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
