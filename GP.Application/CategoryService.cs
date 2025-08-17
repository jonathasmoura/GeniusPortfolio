using GP.Application.DTOs;
using GP.Application.Interfaces;
using GP.Domain.Entities;
using GP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Application
{
	public class CategoryService : ICategoryService
	{
		public IUnitOfWork _unitOfWork;

		public CategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<CategoryDto>> GetAllProducts()
		{
			var all = new List<CategoryDto>();
			var allCategories = await _unitOfWork.Categories.GetAll();

			foreach (var item in allCategories)
			{
				var categoryDto = new CategoryDto();
				categoryDto.Id = item.Id;
				categoryDto.Name = item.Name;
				categoryDto.Description = item.Description;
				all.Add(categoryDto);
			}
			return all;
		}

		public async Task<CategoryDto> GetProductById(Guid categoryId)
		{
			if (!String.IsNullOrEmpty(categoryId.ToString()))
			{
				var categoryobj = await _unitOfWork.Categories.GetById(categoryId);
				if (categoryobj != null)
				{
					var categoryDto = new CategoryDto();
					categoryDto.Id = categoryobj.Id;
					categoryDto.Name = categoryobj.Name;
					categoryDto.Description = categoryobj.Description;

					return categoryDto;
				}
			}
			return null;
		}

		public async Task<bool> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var categoryObj = new Category();

			if (createCategoryDto != null)
			{
				categoryObj.Name = createCategoryDto.Name;
				categoryObj.Description = createCategoryDto.Description;

				await _unitOfWork.Categories.Add(categoryObj);

				var result = _unitOfWork.Save();

				if (result > 0)
					return true;
				else
					return false;
			}
			return false;
		}

		public async Task<bool> DeleteCategory(Guid categoryId)
		{
			if (categoryId.ToString() != "")
			{
				var categoryObj = await _unitOfWork.Categories.GetById(categoryId);
				if (categoryObj != null)
				{
					categoryObj.IsActive = false;
					_unitOfWork.Categories.Update(categoryObj);
					var result = _unitOfWork.Save();

					if (result > 0)
						return true;
					else
						return false;
				}
			}
			return false;
		}
		public async Task<bool> UpdateProduct(UpdateCategoryDto updateCategoryDto)
		{
			if (updateCategoryDto != null)
			{
				var categoryObj = await _unitOfWork.Categories.GetById(updateCategoryDto.Id);

				if (categoryObj != null)
				{
					categoryObj.Name = updateCategoryDto.Name;
					categoryObj.Description = updateCategoryDto.Description;

					_unitOfWork.Categories.Update(categoryObj);
					var result = _unitOfWork.Save();

					if (result > 0)
						return true;
					else
						return false;
				}
			}
			return false;
		}
	}
}
