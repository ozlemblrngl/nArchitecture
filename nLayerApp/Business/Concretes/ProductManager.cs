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

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
            Product product = new Product();
            product.Id = Guid.NewGuid();
            product.ProductName = createProductRequest.ProductName;
            product.QuantityPerUnit = createProductRequest.QuantityPerUnit;
            product.UnitPrice = createProductRequest.UnitPrice;
            product.UnitsInStock = createProductRequest.UnitsInStock;

           Product createdProduct = await _productDal.AddAsync(product);
           
           CreatedProductResponse createdProductResponse = new CreatedProductResponse();
            createdProductResponse.Id = createdProduct.Id;
            createdProductResponse.ProductName = createProductRequest.ProductName; 
            createdProductResponse.QuantityPerUnit = createProductRequest.QuantityPerUnit;
            createdProductResponse.UnitPrice = createProductRequest.UnitPrice;
            createdProductResponse.UnitsInStock= createProductRequest.UnitsInStock;

            return createdProductResponse;
        }
        //GetListProductResponce mapper kullanmadan çevir
        public async Task<Paginate<CreatedProductResponse>> GetListAsync()
        {
            var result= await _productDal.GetListAsync();
            return result;
        }

       
    }
}
