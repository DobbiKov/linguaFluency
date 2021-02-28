using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaFluency.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string DateOfRegister { get; set; }
        public string LastActive { get; set; }
    }
}
