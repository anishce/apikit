using AnishCeDev.TaskManagement.Web.Api.Data.Repositories;
using AnishCeDev.TaskManagement.Web.Api.Models;
namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices;
public sealed class StatusAppService(StatusRepository statuses, LinkRepository links) : IStatusAppService
{
    public async Task<StatusModel> GetStatusAsync(int id) { var item = await statuses.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Status {id} was not found."); return item.ToModel(await links.GetByParentAsync("Status", item.StatusId)); }
    public async Task<IEnumerable<StatusModel>> GetStatusesAsync() { var result = new List<StatusModel>(); foreach (var item in await statuses.GetAllAsync()) result.Add(item.ToModel(await links.GetByParentAsync("Status", item.StatusId))); return result; }
}
