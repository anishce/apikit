using AnishCeDev.TaskManagement.Web.Api.Data;
using AnishCeDev.TaskManagement.Web.Api.Models;

namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices;

public sealed class CategoryAppService(CategoryRepository categories, LinkRepository links) : ICategoryAppService
{
    public async Task AddCategoryAsync(CategoryModel category) { var entity = await categories.AddAsync(category.ToEntity()); await links.ReplaceForParentAsync("Category", entity.CategoryId, (category.Links ?? []).Select(x => x.ToEntity())); }
    public async Task UpdateCategoryAsync(CategoryModel category) { await categories.UpdateAsync(category.ToEntity()); await links.ReplaceForParentAsync("Category", category.CategoryId, (category.Links ?? []).Select(x => x.ToEntity())); }
    public async Task UpdateCategoriesAsync(IEnumerable<CategoryModel> values) { foreach (var item in values) await UpdateCategoryAsync(item); }
    public Task RemoveCategoryAsync(int id) => categories.DeleteAsync(id);
    public async Task RemoveCategoriesAsync(IEnumerable<int> ids) { foreach (var id in ids) await RemoveCategoryAsync(id); }
    public async Task<CategoryModel> GetCategoryAsync(int id) { var entity = await categories.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category {id} was not found."); return entity.ToModel(await links.GetByParentAsync("Category", entity.CategoryId)); }
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync() { var result = new List<CategoryModel>(); foreach (var entity in await categories.GetAllAsync()) result.Add(entity.ToModel(await links.GetByParentAsync("Category", entity.CategoryId))); return result; }
}
