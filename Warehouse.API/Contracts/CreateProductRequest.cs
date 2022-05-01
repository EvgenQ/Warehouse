using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain;

namespace Warehouse.API.Contracts
{
    public class CreateProductRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double PricePerKg { get; set; }

        public double Weight { get; set; }

        public ProductCategory Category { get; set; }
    }
}
