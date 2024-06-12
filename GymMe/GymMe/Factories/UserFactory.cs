using System;
using GymMe.Models;

public class UserFactory
{
    public static User CreateUser(string userName, string userEmail, DateTime userDOB, string userGender, string userRole)
    {
        return new User
        {
            UserName = userName,
            UserEmail = userEmail,
            UserDOB = userDOB,
            UserGender = userGender,
            UserRole = userRole
        };
    }
}
