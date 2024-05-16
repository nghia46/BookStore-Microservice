using BookStore.UserService.Domain.Entities;
using MediatR;

namespace BookStore.UserService.Commands.Commands.Users;

public record AddUserCommand(User User) : IRequest<User>;
