using Grabsycart.Common.Core.Result;
using Grabsycart.Modules.Users.Core.Models;
using Grabsycart.Modules.Users.Core.Repositories;
using Grabsycart.Modules.Users.Infrastructure.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Grabsycart.Modules.Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(UserManager<User> userManager, ILogger<UserRepository> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }
    
    public async Task<Result> CreateUser(User user, string password)
    {
        var checkUser = await _userManager.FindByEmailAsync(user.Email);
        if (checkUser != null)
        {
            return Result.Failure(new UserExistsError(user.Email));
        }

        var userResult = await _userManager.CreateAsync(user, password);

        if (!userResult.Succeeded)
        {
            Result.Failure(new UserCreatedError("Cannot create user, try again later"));
        }
        
        return Result.Success();
    }
}