using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Restaurant
{
    public class Food
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
