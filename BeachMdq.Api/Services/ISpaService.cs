using System.Threading.Tasks;
using Entities;

namespace BeachMdq.Api.Services
{
    public interface ISpaService
    {
        Task<Spa> GetSpa(int spaCode);
        Task<EntityOperationResult<Spa>> AddSpa(string name);
        Task<Spa> GetSpaByUser(int userId);
    }
}
