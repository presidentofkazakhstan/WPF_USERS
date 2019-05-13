using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Services
{
    public class DataEncryptor
    {
        
        public static string HashPassword(string password )
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool isTruePassword(string candidatePassword , string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(candidatePassword, hashedPassword);
        }
    }
}
