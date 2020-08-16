using Omniture.Core.Interfaces.Services.Account;
using Omniture.Db;
using Omniture.Db.Entity.Database;
using System;
using System.Linq;
using Omniture.Db.Entity.Notification;

namespace Omniture.Insurance.Data.Repository.Account
{
    public class UserRepository : Repository<User>, IUser
    {
        private readonly OmnitureContext _visionContext;
        public UserRepository(OmnitureContext context) : base(context)
        {
            _visionContext = context;
           
        }

        public void UpdateRefreshToken(int userId, string refreshtoken, DateTime expireafter)
        {
            
        }

        public override void Add(User entity)
        {
            base.InsertGraph(entity);
        }

        public override void Validate(User entity)
        {
            base.Validate(entity);
        }

        public void CreateUser(User entity)
        {
            
            Add(entity);
        }

        

        public void UpdateImage(int userId, string imageUrl)
        {
            var user = Find(userId);
            user.ImageUrl = imageUrl;
            Update(user);
        }
    }
}
