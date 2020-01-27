using System.Threading.Tasks;
using Entities;

namespace BeachMdq.Api.Services
{
    public interface IUserService
    {
        Task<EntityOperationResult<User>> Register(User user);
    }
}
