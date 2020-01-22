using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace BeachMdq.Api.Services
{
    public interface IFlagService
    {
        public Task<IEnumerable<Flag>> GetFlags();
    }
}
