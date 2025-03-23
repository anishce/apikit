// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: App

using AnishCeDev.TaskManagement.GraphQL.Api.Models;

namespace AnishCeDev.TaskManagement.GraphQL.Api.ApplicationServices
{
    public class TaskAppService : ITaskAppService
    {
        public async Task<TaskModel> GetTaskAsync(int taskId)
        {
            return await Task.Run(() => GetTaskModel(taskId));
        }

        public async Task AddNewTaskAsync(TaskModel task)
        {

        }

        public async Task UpdateTaskAsync(TaskModel task)
        {

        }

        private TaskModel GetTaskModel(int taskId)
        {
            return new TaskModel
            {
                TaskId = taskId,
                Assignees = new List<UserModel>
                {
                    new UserModel
                    {
                        UserId = 1,
                        Firstname="John",
                        Lastname="Doe",
                        Email="john.doe@test.test",
                        Username="john.doe"
                    },
                    new UserModel
                    {
                        UserId = 2,
                        Firstname="Kevin",
                        Lastname="White",
                        Email="kevin.white@test.test",
                        Username="kevin.white"
                    }
                },
                Categories = new List<CategoryModel>
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
                },
                DateCompleted = DateTime.Now,
                DueDate = DateTime.Now.AddDays(1),
                Links = new List<LinkModel>
                {

                }
            };
        }
    }
}
