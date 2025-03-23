// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.GraphQL.Api.Models;

namespace AnishCeDev.TaskManagement.GraphQL.Api.ApplicationServices
{
    public interface ITaskAppService
    {
        Task AddNewTaskAsync(TaskModel task);
        Task<TaskModel> GetTaskAsync(int taskId);
        Task UpdateTaskAsync(TaskModel task);
    }
}