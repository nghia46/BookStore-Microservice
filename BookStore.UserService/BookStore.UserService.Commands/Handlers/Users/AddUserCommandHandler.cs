using BookStore.UserService.Commands.Commands.Users;
using BookStore.UserService.Domain.Entities;
using BookStore.UserService.Domain.Interface;
using MediatR;

namespace BookStore.UserService.Commands.Handlers.Users;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        return _userRepository.AddUserAsync(request.User);
    }
}