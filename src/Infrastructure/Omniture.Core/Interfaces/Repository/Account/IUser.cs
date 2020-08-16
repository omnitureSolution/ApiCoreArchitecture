using Omniture.Db.Abstractions.Repository;
 
using Omniture.Db.Entity.Notification;
using System;

namespace Omniture.Core.Interfaces.Services.Account
{
    public interface IUser : IEntityRepository<User>
    {
        void UpdateRefreshToken(int UserId, string refreshtoken, DateTime expireafter);
        void CreateUser(User entity); 
        void UpdateImage(int userId,string imageUrl);
        
    }
}
