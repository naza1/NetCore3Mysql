using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeachMdq.Api.Services
{
    public class FlagService : IFlagService
    {
        private readonly BeachMdqContext _context;

        public FlagService(BeachMdqContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flag>> GetFlags()
        {
            return await _context.Flags.ToListAsync();
        }
    }
}
