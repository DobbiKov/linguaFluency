using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaFluency.Domain.Models
{
    public static class authJwtOptions
    {
        public static string Issuer { get; set; }
        public static string Audience { get; set; }
        public static int TokenLifeTime { get; set; }
        public static SymmetricSecurityKey SecretKey { get; set; }
    }
}
