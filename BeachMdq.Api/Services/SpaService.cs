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

        public async Task<EntityOperationResult<Spa>> AddSpa(string name)
        {
            var spa = await _context.Spas.FirstOrDefaultAsync(x => x.Name == name);
            
            if (spa != null)
            {
                var result = new EntityOperationResult<Spa>();
                result.AddError("Duplicado", "Ya existe el nombre del balneario");
                return result;
            }

            var newSpa = new Spa
            {
                Name = name,
                Active = true
            };

            _context.Spas.Add(newSpa);

           await _context.SaveChangesAsync();

           return new EntityOperationResult<Spa>(newSpa);
        }
    }
}
