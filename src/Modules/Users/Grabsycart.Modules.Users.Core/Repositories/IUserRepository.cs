using Grabsycart.Common.Core.Result;
using Grabsycart.Modules.Users.Core.Models;

namespace Grabsycart.Modules.Users.Core.Repositories;

public interface IUserRepository
{
    Task<Result> CreateUser(User user, string password);
}