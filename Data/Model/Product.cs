﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreWebApi.Data.Model
{
    public class Product
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public decimal? NewPrice { get; set; }
        public int InStock { get; set; }            
        public int? CreatedBy { get; set; }
        public Admin Admin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<ProductCategory> productCategory { get; set; }
        public List<Tag> Tag { get; set; }
    }
}
