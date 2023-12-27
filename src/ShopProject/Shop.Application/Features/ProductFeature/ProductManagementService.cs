﻿using Shop.Domain.Entities;
using Shop.Domain.Features.ProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.ProductFeature
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly IApplicationUnitOfWork _unitofWork;
        public ProductManagementService(IApplicationUnitOfWork unitofWork) 
        { 
            _unitofWork = unitofWork;
        }

        public async Task CreateProductAsync(string productTitle, string description, uint price)
        {
            Product product = new Product()
            {
                ProductTitle = productTitle,
                Description = description,
                Price = price
            };
           await _unitofWork.ProductRepository.AddAsync(product);
            await _unitofWork.SaveAsync();
        }
    }
}