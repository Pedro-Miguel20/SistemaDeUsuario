using Microsoft.EntityFrameworkCore;
using SistemaDeUsuario.Data;
using SistemaDeUsuario.Models;

public class AuthService
{
    private readonly UsersDbContext _context;

    public AuthService(UsersDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string email, string password)
    {
        var normalizedEmail = email?.Trim().ToLowerInvariant();

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == normalizedEmail && u.IsActive);

        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            return user;

        return null;
    }
}
