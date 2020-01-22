using System.Threading.Tasks;
using Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeachMdq.Api.Services
{
    public class SpaService : ISpaService
    {
        private readonly BeachMdqContext _context;

        public SpaService(BeachMdqContext context)
        {
            _context = context;
        }

        public async Task<Spa> GetSpa(int spaCode)
        {
            return await _context.Spas.FirstOrDefaultAsync(x => x.Id == spaCode);
        }

        public async Task AddSpa(string name)
        {
           var spa = new Spa
           {
               Name = name,
               Active = true
           };

           _context.Spas.Add(spa);
           await _context.SaveChangesAsync();
        }
    }
}
