using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TestRailProject.Models;


namespace TestRailProject.Services;

public interface IUserService
{
    User GetUser(int userId);
    User GetUserByEmail(string userEmail);
    User UpdateUser(User user, int userId);
    User GetCurrentUser(int userId);
    /*Task<User> GetUsers(int projectId);
    Task<User> AddUser(User user); */
}
