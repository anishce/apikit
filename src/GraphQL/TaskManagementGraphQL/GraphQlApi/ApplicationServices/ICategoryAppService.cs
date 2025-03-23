// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.GraphQL.Api.Models;

namespace AnishCeDev.TaskManagement.GraphQL.Api.ApplicationServices
{
    public interface ICategoryAppService
    {
        Task AddCategoryAsync(CategoryModel category);
        Task<CategoryModel> GetCategoryAsync(int categoryId);
        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        Task RemoveCategoriesAsync(IEnumerable<int> categoryIds);
        Task RemoveCategoryAsync(int categoryId);
        Task UpdateCategoriesAsync(IEnumerable<CategoryModel> categories);
        Task UpdateCategoryAsync(CategoryModel category);
    }
}