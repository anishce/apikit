using AnishCeDev.TaskManagement.Web.Api.Data;
using AnishCeDev.TaskManagement.Web.Api.Models;
namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices;
public sealed class UserAppService(UserRepository users, LinkRepository links) : IUserAppService
{
    public async Task<UserModel> GetUserAsync(int id) { var item = await users.GetByIdAsync(id) ?? throw new KeyNotFoundException($"User {id} was not found."); return item.ToModel(await links.GetByParentAsync("User", item.UserId)); }
    public async Task<IEnumerable<UserModel>> GetUsersAsync() { var result = new List<UserModel>(); foreach (var item in await users.GetAllAsync()) result.Add(item.ToModel(await links.GetByParentAsync("User", item.UserId))); return result; }
}
