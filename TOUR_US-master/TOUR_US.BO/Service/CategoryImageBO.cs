using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.BO.ViewModels;
using TOUR_US.DAL;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace TOUR_US.BO.Service
{
    public class CategoryImageBO : QueryFilterBO<CategoryImage>
    {

        public CategoryImageBO(IUnitOfWork unit,
            IGenericRepos<CategoryImage> generic, 
            IMapper mapper) : base(unit, generic, mapper)
        {

        }

        public IEnumerable<CategoryImageVM> GetCategories(QueryFilter query)
        {
            IEnumerable<CategoryImage> Categories = Filter(query);
            IEnumerable<CategoryImageVM> CategoryImageList = (from CategoryImage in Categories select Convert(CategoryImage));
            return CategoryImageList;
        }

        public async Task<CategoryImageVM> Add(CategoryImageVM CategoryImage)
        {
            try
            {
                string imageUrl = await CategoryImage.FormFile.SaveImage("Categories");
                CategoryImage cat = Convert(CategoryImage);
                cat.ImageUrl = imageUrl;
                cat = await _uow.CategoryImageRepos.Create(cat);
                return Convert(cat);
            }
            catch
            {
                return CategoryImage;
            }
        }

        public async Task Delete(int CategoryImageId)
        {
            await _uow.CategoryImageRepos.Delete(CategoryImageId);
        }

        public async Task<CategoryImageVM> Update(CategoryImageVM CategoryImage)
        {
            string imageUrl = await CategoryImage.FormFile.SaveImage("Categories");
            CategoryImage cat = Convert(CategoryImage);
            cat.ImageUrl = imageUrl;
            cat = await _uow.CategoryImageRepos.Update(cat);
            return Convert(cat);
        }

        public async Task<CategoryImageVM> GetById(int CategoryImageId)
        {
            return Convert(await _uow.CategoryImageRepos.GetById(CategoryImageId));
        }

        private CategoryImageVM Convert(CategoryImage CategoryImage)
        {
            return _mapper.Map<CategoryImageVM>(CategoryImage);
        }

        private CategoryImage Convert(CategoryImageVM CategoryImage)
        {
            return _mapper.Map<CategoryImage>(CategoryImage);
        }


    }
}
