// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Web.Api.Models;

namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices
{
    public interface ITaskAppService
    {
        Task AddNewTaskAsync(TaskModel task);
        Task<TaskModel> GetTaskAsync(int taskId);
        Task UpdateTaskAsync(TaskModel task);
    }
}