﻿using Business.Dtos.Request;
using Business.Dtos.Requests;
using Business.Dtos.Response;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);
    }
}
