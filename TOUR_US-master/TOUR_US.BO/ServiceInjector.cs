using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.BO.Service;
using TOUR_US.DAL;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Repos;
using TOUR_US.DAL.Services;

namespace TOUR_US.BO
{
    public class ServiceInjector
    {
        private readonly IServiceCollection _services;
        public ServiceInjector(IServiceCollection services)
        {
            _services = services;
        }

        public void Render()
        {
            _services.AddScoped<IGenericRepos<Category>, GenericRepos<Category>>();
            _services.AddScoped<IGenericRepos<ActivityImage>, GenericRepos<ActivityImage>>();
            _services.AddScoped<IGenericRepos<Activity>, GenericRepos<Activity>>();
            _services.AddScoped<IGenericRepos<CategoryImage>, GenericRepos<CategoryImage>>();
            _services.AddScoped<IGenericRepos<Activity>, GenericRepos<Activity>>();
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            _services.AddScoped<QueryFilterBO<Category>>();
            _services.AddScoped<QueryFilterBO<CategoryImage>>();
            _services.AddScoped<QueryFilterBO<Activity>>();
            _services.AddScoped<QueryFilterBO<ActivityImage>>();
            _services.AddScoped<ActivityBO>();
            _services.AddScoped<ActivityImageBO>();
            _services.AddScoped<CategoryBO>();
            _services.AddScoped<CategoryImageBO>();
            _services.AddScoped<BaseBO>();
            var configurationMapper = new MapperConfiguration(option => option.AddProfile(new UserProfile()));
            var mapper = configurationMapper.CreateMapper();
            _services.AddSingleton<IMapper>(mapper);
        }
    }
}
