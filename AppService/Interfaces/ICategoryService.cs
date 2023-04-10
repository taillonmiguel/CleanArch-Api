using CleanArch.AppService.DTOs;

namespace CleanArch.AppService.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetById(int? id);
        Task Add(CategoryDto categoryDto);
        Task Update(CategoryDto categoryDto);
        Task Remove(int? id);
    }
}
