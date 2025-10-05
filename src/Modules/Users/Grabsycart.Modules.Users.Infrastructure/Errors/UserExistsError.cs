using Grabsycart.Common.Core.Result;

namespace Grabsycart.Modules.Users.Infrastructure.Errors;

public sealed record UserExistsError(string Email) : Error($"User with email {Email} already exists");
