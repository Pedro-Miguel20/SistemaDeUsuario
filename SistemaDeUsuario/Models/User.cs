﻿namespace SistemaDeUsuario.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
