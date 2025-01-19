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
    public class PriorityAppService : IPriorityAppService
#pragma warning restore VSSpell001 // Spell Check
    {
        public async Task<PriorityModel> GetPriorityAsync(int priorityId)
        {
            return await Task.Run(() => GetPriorityModel());
        }

        public async Task<IEnumerable<PriorityModel>> GetPrioritiesAsync()
        {
            return await Task.Run(() => GetPriorityModels());
        }

        private PriorityModel GetPriorityModel()
        {
            return new PriorityModel
            {
                PriorityId = 1,
                Ordinal = 2,
                Name = "In Progress",
                Links = new List<LinkModel>
                {
                    new LinkModel
                    {
                        Href="https://www.google.com",
                        Rel="",
                        Title="Google",
                        Type="HyperLink"
                    }
                }
            };
        }

        private IEnumerable<PriorityModel> GetPriorityModels()
        {
            return new List<PriorityModel>
            {
                new PriorityModel
                {
                    PriorityId = 1,
                    Ordinal = 2,
                    Name = "In Progress",
                    Links = new List<LinkModel>
                    {
                        new LinkModel
                        {
                            Href="https://www.google.com",
                            Rel="",
                            Title="Google",
                            Type="HyperLink"
                        }
                    }
                }
            };
        }
    }
}
