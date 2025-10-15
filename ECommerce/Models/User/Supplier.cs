using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Supplier 
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string ShopName { get; set; }
        public string ShopLocation { get; set; }
        public string ShopLogo { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
