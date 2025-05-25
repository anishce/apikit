// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Odata.Api.Models;

namespace AnishCeDev.TaskManagement.Odata.Api.ApplicationServices
{
    public interface ITaskAppService
    {
        Task<TaskModel> AddNewTaskAsync(TaskModel task);
        Task<TaskModel> GetTaskAsync(int taskId);
        Task<TaskModel> UpdateTaskAsync(TaskModel task);
    }
}