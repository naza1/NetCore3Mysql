using System.Threading.Tasks;
using BeachMdq.Api.Services;
using Entities;

namespace Registration_Login_Api.Services
{
    public interface IUserService
    {
        Task<EntityOperationResult<User>> Register(User user, string password);
        Task<EntityOperationResult<User>> Authenticate(string username, string password);
        Task<User> GetById(int id);
    }
}
