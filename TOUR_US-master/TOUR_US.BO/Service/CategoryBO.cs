using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.BO.ViewModels;
using TOUR_US.DAL;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace TOUR_US.BO.Service
{
    public class CategoryBO : QueryFilterBO<Category>
    {
        private readonly CategoryImageBO _image;
        public CategoryBO(IUnitOfWork unit, IGenericRepos<Category> generic, IMapper mapper, CategoryImageBO image) : base(unit, generic, mapper)
        {
            _image = image;
        }

        public IEnumerable<CategoryVM> GetCategories(QueryFilter query)
        {
            IEnumerable<Category> Categories = Filter(query);
            IEnumerable<CategoryVM> CategoryList = (from category in Categories select Convert(category));
            return CategoryList;
        }

        public async Task<CategoryVM> Add(CategoryVM category)
        {
            try
            {
                Category cat = Convert(category);
                cat = await _uow.CategoryRepos.Create(cat);

                if (cat != default(Category))
                {
                    if (category.FormFiles.Count() > 0)
                    {
                        foreach(IFormFile formfile in category.FormFiles)
                        {
                            category.CategoryImageVMs.Add(await _image.Add(new CategoryImageVM { CategoryId = cat.Id, FormFile = formfile, ImageTag = formfile.FileName }));
                        }
                    }
                }
                return Convert(cat);
            }
            catch
            {
                return category;
            }
        }

        public async Task Delete(int categoryId)
        {
            await _uow.CategoryRepos.Delete(categoryId);
        }

        public async Task<CategoryVM> Update(CategoryVM category)
        {
            Category cat = Convert(category);
            cat = await _uow.CategoryRepos.Update(cat);
            if (cat != default(Category))
            {
                if (category.FormFiles.Count() > 0)
                {
                    foreach (IFormFile formfile in category.FormFiles)
                    {
                        category.CategoryImageVMs.Add(await _image.Add(new CategoryImageVM { CategoryId = cat.Id, FormFile = formfile, ImageTag = formfile.FileName }));
                    }
                }
            }
            return Convert(cat);
        }

        public async Task<CategoryVM> GetById(int categoryId)
        {
            return Convert(await _uow.CategoryRepos.GetById(categoryId));
        }

        private CategoryVM Convert(Category category)
        {
            return _mapper.Map<CategoryVM>(category);
        }

        private Category Convert(CategoryVM category)
        {
            return _mapper.Map<Category>(category);
        }


    }
}
