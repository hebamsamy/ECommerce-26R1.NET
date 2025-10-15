using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositories
{
    public class ProductRepository :BaseRepository<Product>
    {
        public ProductRepository(EcommerceContext _context) : base(_context)
        {
        }

    }
}
