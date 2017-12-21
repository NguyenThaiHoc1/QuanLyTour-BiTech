using System;
namespace Core.Services
{
    public interface IUserServices<T> where T : class
    {
        bool changePassword(string username, string newPassword);

        bool checkingPassword(string username,string password);

        T getUsername(string username);
    }
}
