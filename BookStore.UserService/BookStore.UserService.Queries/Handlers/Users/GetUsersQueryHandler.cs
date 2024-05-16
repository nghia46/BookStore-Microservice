using BookStore.UserService.Domain.Entities;
using BookStore.UserService.Domain.Interface;
using BookStore.UserService.Queries.Queries.Users;
using MediatR;

namespace BookStore.UserService.Queries.Handlers.Users;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return _userRepository.GetUsersAsync();
    }
}