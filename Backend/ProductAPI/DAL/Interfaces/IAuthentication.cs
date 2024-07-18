using DAL.Models;
using DAL.Request_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuthentication
    {
        User AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}
