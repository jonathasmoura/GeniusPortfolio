using GP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GP.Application.Interfaces
{
	public interface ICategoryService
	{
		Task<bool> CreateCategory(CreateCategoryDto createCategoryDto);

		Task<IEnumerable<CategoryDto>> GetAllProducts();

		Task<CategoryDto> GetProductById(Guid categoryId);

		Task<bool> UpdateProduct(UpdateCategoryDto categoryDto);

		Task<bool> DeleteCategory(Guid categoryId);
	}
}
