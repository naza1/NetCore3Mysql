using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data.Models;

namespace BeachMdq.Api.Services
{
    public interface IFlagService
    {
        public Task<IEnumerable<Flag>> GetFlags();
    }
}
