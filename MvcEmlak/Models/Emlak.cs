using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcEmlak.Models
{
    public class Emlak
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public int Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime IlanTarihi { get; set; }
        public string Photo { get; set; }
    }
}
