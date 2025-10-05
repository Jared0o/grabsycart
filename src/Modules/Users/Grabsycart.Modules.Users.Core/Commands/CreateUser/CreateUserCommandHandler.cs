using FluentValidation;
using Grabsycart.Common.Core.Result;
using Grabsycart.Common.Core.Result.Errors;
using Grabsycart.Modules.Users.Core.Models;
using Grabsycart.Modules.Users.Core.Repositories;
using Mediator;

namespace Grabsycart.Modules.Users.Core.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IValidator<CreateUserCommand> _validator;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IValidator<CreateUserCommand> validator, IUserRepository userRepository)
    {
        _validator = validator;
        _userRepository = userRepository;
    }
    
    public async ValueTask<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var validationError = ValidationHelper.ToValidationError(validationResult);
            return Result.Failure(validationError);
        }

        var user = new User
        {
            Id = Guid.CreateVersion7(),
            Email = request.Email,
            UserName = request.Email,
        };

        return await _userRepository.CreateUser(user, request.Password);
    }
}