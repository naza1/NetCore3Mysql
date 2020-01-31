using System;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Registration_Login_Api.Services
{
    public class UserService : IUserService
    {
        private readonly BeachMdqContext _context;

        public UserService(BeachMdqContext context)
        {
            _context = context;
        }

        public async Task<EntityOperationResult<User>> Register(User user, string password)
        {
            var result = new EntityOperationResult<User>();

            if (string.IsNullOrWhiteSpace(password))
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

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            var newUser = new User
            {
                Email = user.Email,
                Active = true,
                Name = user.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                SpaId = user.SpaId
            };
            
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new EntityOperationResult<User>(newUser);
        }

        public async Task<EntityOperationResult<User>> Authenticate(string username, string password)
        {
            var result = new EntityOperationResult<User>();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                result.AddError("Login fail", "Name or Password are empty");
                return result;
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == username);

            if (user == null)
            {
                result.AddError("User inexistent", "User is nor registered");
                return result;
            }
            
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                result.AddError("User invalid", "User password invalid");
                return result;
            }

            // authentication successful
            return new EntityOperationResult<User>(user);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) 
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password)) 
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) 
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password)) 
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");

            if (storedSalt.Length != 128) 
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) 
                        return false;
                }
            }

            return true;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
