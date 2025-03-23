// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: Anish App Api

using AnishCeDev.TaskManagement.GraphQL.Api.Models;

namespace AnishCeDev.TaskManagement.GraphQL.Api.ApplicationServices
{
    public class CategoryAppService : ICategoryAppService
    {
        public async Task AddCategoryAsync(CategoryModel category)
        {
            await Task.Run(() => AddNewCategory(category));
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            await Task.Run(() => UpdateCategory(category));
        }

        public async Task UpdateCategoriesAsync(IEnumerable<CategoryModel> categories)
        {
            await Task.Run(() => UpdateCategories(categories));
        }

        public async Task RemoveCategoryAsync(int categoryId)
        {
            await Task.Run(() => RemoveCategory(categoryId));
        }

        public async Task RemoveCategoriesAsync(IEnumerable<int> categoryIds)
        {
            await Task.Run(() => RemoveCategories(categoryIds));
        }

        public async Task<CategoryModel> GetCategoryAsync(int categoryId)
        {
            return await Task.Run(() => GetCategoryModel(categoryId));
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            return await Task.Run(() => GetCategoryModels());
        }

        private IEnumerable<CategoryModel> GetCategoryModels()
        {
            return new List<CategoryModel>
            {
                new CategoryModel
                {
                    CategoryId = 1,
                    Description = "Test",
                    Links = new List<LinkModel>
                    {
                        new LinkModel
                        {
                            Href="https://www.google.com",
                            Rel="",
                            Title="Google",
                            Type="HyperLink"
                        }
                    },
                    Name = "HyperLink Category"
                }
            };
        }

        private CategoryModel GetCategoryModel(int categoryId)
        {
            return new CategoryModel
            {
                CategoryId = categoryId,
                Description = "Test",
                Links = new List<LinkModel>
                {
                    new LinkModel
                    {
                        Href="https://www.google.com",
                        Rel="",
                        Title="Google",
                        Type="HyperLink"
                    }
                },
                Name = "HyperLink Category"
            };
        }

        private void AddNewCategory(CategoryModel category)
        {

        }

        private void UpdateCategory(CategoryModel category)
        {

        }

        private void UpdateCategories(IEnumerable<CategoryModel> categories)
        {

        }

        private void RemoveCategory(int categoryId)
        {

        }

        private void RemoveCategories(IEnumerable<int> categoryIds)
        {

        }
    }
}
