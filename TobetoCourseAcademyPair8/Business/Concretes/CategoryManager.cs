using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Response;
using Business.Dtos.Responses;
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
            Category category = _mapper.Map<Category>(createCategoryRequest);
            category.Id = Guid.NewGuid();
            
            Category createdCategory = await _categoryDal.AddAsync(category);

            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(category);
            return createdCategoryResponse;
        }

        public async Task<IPaginate<GetListCategoryResponse>> GetListAsync()
        {
            var result = await _categoryDal.GetListAsync();
            Paginate<GetListCategoryResponse> response = new Paginate<GetListCategoryResponse>();
            response = _mapper.Map<Paginate<GetListCategoryResponse>>(result);

            return response;
        }
    }
}



