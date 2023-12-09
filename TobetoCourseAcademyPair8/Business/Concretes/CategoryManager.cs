using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Response;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.Name = createCategoryRequest.Name;

            Category createdCategory = await _categoryDal.AddAsync(category);

            CreatedCategoryResponse createdCategoryResponse = new CreatedCategoryResponse();
            createdCategoryResponse.Id = createdCategory.Id;
            createdCategoryResponse.Name = createdCategory.Name;

            return createdCategoryResponse;
        }

        public async Task<IPaginate<CreatedCategoryResponse>> GetListAsync()
        {
            var result = await _categoryDal.GetListAsync();
            return result;
        }
    }
}



