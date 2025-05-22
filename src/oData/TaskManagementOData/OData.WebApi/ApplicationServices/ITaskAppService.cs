// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Odata.Api.Models;

namespace AnishCeDev.TaskManagement.Odata.Api.ApplicationServices
{
    public interface ITaskAppService
    {
        Task AddNewTaskAsync(TaskModel task);
        Task<TaskModel> GetTaskAsync(int taskId);
        Task UpdateTaskAsync(TaskModel task);
    }
}