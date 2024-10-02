﻿// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Web.Api.Models;

namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices
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