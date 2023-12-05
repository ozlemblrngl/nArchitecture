﻿using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<TobetoCourseContext>(options => options.UseSqlServer("Server=DESKTOP-3LFDKEV;Database=TobetoCourseCategoryTest;Trusted_Connection= true; TrustServerCertificate = True"));
           // services.AddDbContext<TobetoCourseContext>(options => options.UseInMemoryDatabase("TobetoCourse"));
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            return services;
        }
    }
}