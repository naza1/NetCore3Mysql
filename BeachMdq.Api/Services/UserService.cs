using System;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeachMdq.Api.Services
{
    public class UserService : IUserService
    {
        private readonly BeachMdqContext _context;

        public UserService(BeachMdqContext context)
        {
            _context = context;
        }

        public async Task<EntityOperationResult<User>> Register(User user)
        {
            var result = new EntityOperationResult<User>();

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                result.AddError("Password", "Password is required");
                return result;
            }

            var userRepeated = await _context.Users.FirstOrDefaultAsync(x => x.Spa.Id == user.SpaId && x.Active && x.Name == user.Name);

            if (userRepeated != null)
            {
                result.AddError("Repeated user", "Username \"" + user.Name + "\" is already taken");
                return result;
            }

            var spaAssociated = await _context.Spas.FirstOrDefaultAsync(x => x.Id == user.SpaId);

            if (spaAssociated == null)
            {
                result.AddError("Spa", "Spa \"" + user.SpaId + "\" is not already exist");
                return result;
            }

            var newUser = new User
            {
                Email = user.Email,
                Active = true,
                Name = user.Name,
                Password = user.Password,
                SpaId = user.SpaId
            };
            
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new EntityOperationResult<User>(newUser);
        }
    }
}
