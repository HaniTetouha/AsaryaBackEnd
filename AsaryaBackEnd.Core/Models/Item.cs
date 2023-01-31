﻿namespace AsaryaBackEnd.Core.Models
{
    public class Item
    {
        public long Id { get; set; }
        public int? Barcode { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}