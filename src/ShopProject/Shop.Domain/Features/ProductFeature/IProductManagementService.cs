using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Features.ProductFeature
{
    public interface IProductManagementService
    {
        Task CreateProductAsync(string productTitle, string description, uint price);
    }
}
