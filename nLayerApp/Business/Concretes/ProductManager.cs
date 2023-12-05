using Business.Abstracts;
using Core.DataAccess.Paging;
using Entities.Concretes;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public async Task Add(Product product)
        {
            product.Id = Guid.NewGuid();
            _productDal.AddAsync(product);
        }

        public async Task<Paginate<Product>> GetListAsync()
        {
            var result= await _productDal.GetListAsync();
            return result;
        }
    }
}
