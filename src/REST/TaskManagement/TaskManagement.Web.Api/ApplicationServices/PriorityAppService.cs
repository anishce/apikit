using AnishCeDev.TaskManagement.Web.Api.Data;
using AnishCeDev.TaskManagement.Web.Api.Models;
namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices;
public sealed class PriorityAppService(PriorityRepository priorities, LinkRepository links) : IPriorityAppService
{
    public async Task<PriorityModel> GetPriorityAsync(int id) { var item = await priorities.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Priority {id} was not found."); return item.ToModel(await links.GetByParentAsync("Priority", item.PriorityId)); }
    public async Task<IEnumerable<PriorityModel>> GetPrioritiesAsync() { var result = new List<PriorityModel>(); foreach (var item in await priorities.GetAllAsync()) result.Add(item.ToModel(await links.GetByParentAsync("Priority", item.PriorityId))); return result; }
}
