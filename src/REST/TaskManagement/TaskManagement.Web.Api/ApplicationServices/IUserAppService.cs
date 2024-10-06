// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Web.Api.Models;

namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices
{
    public interface IUserAppService
    {
        Task<UserModel> GetUserAsync(int userId);
        Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}