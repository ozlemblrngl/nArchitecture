﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Requests.Category;
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
            
            Category createdCategory = await _categoryDal.AddAsync(category);

            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }

        public async Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest)
        {
            Category category = await _categoryDal.GetAsync(predicate: c=> c.Id == deleteCategoryRequest.Id);
            await _categoryDal.DeleteAsync(category);

            DeletedCategoryResponse response = _mapper.Map<DeletedCategoryResponse>(category);

            return response;
        
        }

        public async Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest)
        {
            var result = await _categoryDal.GetListAsync(index:pageRequest.Index,size:pageRequest.Size);
            Paginate<GetListCategoryResponse> response = _mapper.Map<Paginate<GetListCategoryResponse>>(result);
          
            return response;
        }

        
        public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest)
        {
            Category category = await _categoryDal.GetAsync(predicate: c=>c.Id == updateCategoryRequest.Id );
            category.Name = updateCategoryRequest.Name;
            Category updatedCategory = await _categoryDal.UpdateAsync(category);
            UpdatedCategoryResponse response = _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
            return response;
        }

      

    }
}



