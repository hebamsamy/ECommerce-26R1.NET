using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    /// <summary>
    /// ////////////////////no base model (using IDENTITY)
    /// </summary>
    public class User :BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public Address Address { get; set; }
        public virtual Supplier? Supplier { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public  virtual ICollection<CartItem> CartItems { get; set; }
    }
}
