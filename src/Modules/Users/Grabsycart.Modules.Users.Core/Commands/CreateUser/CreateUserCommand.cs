using Grabsycart.Common.Core.Result;
using Mediator;

namespace Grabsycart.Modules.Users.Core.Commands.CreateUser;

public record CreateUserCommand(string Email, string Password, string PasswordConfirm) : IRequest<Result>;