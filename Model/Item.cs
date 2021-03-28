using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListAPI.Model
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ItemName { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string ShopName { get; set; }
        [Column(TypeName ="nvarchar(50")]
        public string DateAdded{ get; set; }
    }
}
