using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeUsuario.Data;
using SistemaDeUsuario.Models;

namespace SistemaDeUsuario.Services
{
    public class UserValidatorService
    {
        private readonly UsersDbContext _context;

        public UserValidatorService(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DoesEmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && u.IsActive);
        }

        public string? GetPasswordValidationError(string password)
        {
            var hasNumber = password.Any(char.IsDigit);
            var hasUpper = password.Any(char.IsUpper);

            if (password.Length < 8 || !hasNumber || !hasUpper)
            {
                return "Deve ter pelo menos 8 caracteres, um número e uma letra maiúscula.";
            }

            return null;
        }
    }
}
