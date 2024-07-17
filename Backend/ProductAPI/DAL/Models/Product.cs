using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
    }
}
