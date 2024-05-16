using BookStore.UserService.Domain.Entities;

namespace BookStore.UserService.Domain.Interface;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync();
}