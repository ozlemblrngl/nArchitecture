using Business.Abstracts;
using Core.DataAccess.Paging;
using Entities.Concretes;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
           Product product = _mapper.Map<Product>(createProductRequest);
           Product createdProduct = await _productDal.AddAsync(product);

           CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
           return createdProductResponse;
        }

        public async Task<IPaginate<GetListProductResponse>> GetListAsync()
        {
            var data = await _productDal.GetListAsync(
            include: p => p.Include(p => p.Category)
            );

            var result = _mapper.Map<IPaginate<GetListProductResponse>>(data);
            return result;


        }
    }
        
}
