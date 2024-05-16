using BookStore.UserService.Domain.Entities;
using MediatR;

namespace BookStore.UserService.Queries.Queries.Users;

public record GetUsersQuery() : IRequest<IEnumerable<User>>;
