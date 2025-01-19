// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Web.Api.Models;

#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices
#pragma warning restore VSSpell001 // Spell Check
#pragma warning restore VSSpell001 // Spell Check
{
#pragma warning disable VSSpell001 // Spell Check
    public interface IPriorityAppService
#pragma warning restore VSSpell001 // Spell Check
    {
        Task<PriorityModel> GetPriorityAsync(int priorityId);
        Task<IEnumerable<PriorityModel>> GetPrioritiesAsync();
    }
}