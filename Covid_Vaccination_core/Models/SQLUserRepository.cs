using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        User IUserRepository.Add(User User)
        {
            context.Users.Add(User);
            context.SaveChanges();
            return User;
        }

        User IUserRepository.GetUser(string phoneno,string password)
        {
            User u = context.Users.FirstOrDefault(u => ((u.Phoneno == phoneno) && (u.Password == password)) );
            return u;
        }
    }
}
