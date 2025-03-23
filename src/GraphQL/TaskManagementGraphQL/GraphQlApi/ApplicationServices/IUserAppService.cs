// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.GraphQL.Api.Models;

namespace AnishCeDev.TaskManagement.GraphQL.Api.ApplicationServices
{
    public interface IUserAppService
    {
        Task<UserModel> GetUserAsync(int userId);
        Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}