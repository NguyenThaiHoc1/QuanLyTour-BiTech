using System;
namespace Core.Services
{
    public interface IUserServices<T> where T : class
    {
        T login(string username, string password);

        bool logout();

        bool changePassword(string username, string newPassword);

        bool checkingPassword(string username,string password);
    }
}
