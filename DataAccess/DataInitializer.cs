using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Services;

namespace DataAccess
{
    public class DataInitializer : CreateDatabaseIfNotExists<ProgramContext>
    {
        protected override void Seed(ProgramContext context)
        {
            context.Users.Add(new Models.User
            {
                Login = "admin",
                Password = DataEncryptor.HashPassword("123")
            });
        }
    }
} 
