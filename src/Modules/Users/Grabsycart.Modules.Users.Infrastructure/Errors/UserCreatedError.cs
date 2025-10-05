using Grabsycart.Common.Core.Result;

namespace Grabsycart.Modules.Users.Infrastructure.Errors;

public sealed record UserCreatedError(string Message) : Error(Message);