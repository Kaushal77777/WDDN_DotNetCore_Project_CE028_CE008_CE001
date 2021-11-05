using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Models
{
    public interface IUserRepository
    {
        User GetUser(string phoneno,string password);
        User Add(User User);
    }
}
