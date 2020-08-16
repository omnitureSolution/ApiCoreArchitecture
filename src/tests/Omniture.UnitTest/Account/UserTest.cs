//using System;
//using System.Collections.Generic;
//using Omniture.Core.Model.Account;
//using Omniture.Insurance.Data.Repository.Account;
//using Omniture.Db.Context;
//using Omniture.Db.Entity.Account;
//using Omniture.Db.Entity.Database;
//using Omniture.Shared.Common;
//using Xunit;
//using Omniture.Insurance.Services.Account;

//namespace Omniture.UnitTest.Account
//{
//    public class UserTest : IClassFixture<UserConntextFixture>
//    {
//        UserService userService;
//        UsersRepository userRepo;
//        UserConntextFixture _fixture;
//        public UserTest(UserConntextFixture fixture)
//        {
//            _fixture = fixture;
//            userRepo = new UsersRepository(_fixture.Context);

//            userService = new UserService(_fixture.Context,
//                userRepo, null, TestCommon.AuthConfiguration);
//        }

//        [Theory]
//        [InlineData("user", "password", "user")]
//        public void Should_add_user(string username, string password, string expectedResult)
//        {
//            var u = new Users()
//            {
//                UserName = username,
//                UserPassword = new List<UserPassword> { new UserPassword { Password = password } }
//            };
//            userRepo.Add(u);
//            _fixture.Context.SaveChanges();

//            var result = userRepo.Find(u.UserId);
//            Assert.Equal(result.UserName, expectedResult);
//        }

//        [Theory]
//        [InlineData("admin", "admin1")]
//        public void Should_thow_error_when_invalid_credential(string username, string password)
//        {
//            Assert.Throws<ValidModelException>(() => userService.Login(new LoginModel
//            {
//                Password = password,
//                UserName = username
//            }));
//        }

//        [Theory]
//        [InlineData("admin", "admin")]
//        public void Should_login_when_valid_credential(string username, string password)
//        {
//            var loginRes = userService.Login(new LoginModel
//            {
//                Password = username,
//                UserName = password
//            });
//            Assert.NotNull(loginRes);
//        }

//        [Theory]
//        [InlineData(3)]
//        public async void Should_delete_user(int userid)
//        {
//            userRepo.Delete(userid);
//            await _fixture.Context.SaveChangesAsync();
//        }

//        [Theory]
//        [InlineData(5, "admin22")]
//        public async void Should_update_user(int userid, string username)
//        {
//            var loginRes = new Users
//            {
//                UserId = userid,
//                UserName = username
//            };
//            userRepo.Update(loginRes);
//            await _fixture.Context.SaveChangesAsync();
//        }
//        [Theory]
//        [InlineData("superuser", "superuser")]
//        public void Should_not_refresh_token_when_invalid_token(string username, string password)
//        {
//            var loginRes = userService.Login(new LoginModel
//            {
//                Password = username,
//                UserName = password
//            });
//            Assert.Throws<ArgumentException>(() => userService.Refresh("invalidtoken", loginRes.refresh_token));
//        }

//        [Theory]
//        [InlineData("superuser", "superuser")]
//        public void Should_refresh_token_when_valid_token(string username, string password)
//        {
//            var loginRes = userService.Login(new LoginModel
//            {
//                Password = username,
//                UserName = password
//            });
//            var newToken = userService.Refresh(loginRes.access_token, loginRes.refresh_token);
//            Assert.NotNull(newToken);
//            Assert.NotEmpty(newToken.access_token);
//        }

//        [Theory]
//        [InlineData(1, "admin1", "newpass")]
//        public void Should_not_change_password_if_wrong_information(int userId, string currentpassword, string updatepassword)
//        {

//            Assert.Throws<ModelNotFoundException>(() => userService.ChangePassword(new ChangePasswordModel
//            {
//                userId = userId,
//                CurrentPassword = currentpassword,
//                NewPassword = updatepassword
//            }));
//        }

//        [Theory]
//        [InlineData(4, "updateuser", "updateuser")]
//        public void Should_change_password(int userId, string currentpassword, string updatepassword)
//        {
//            Assert.True(userService.ChangePassword(new ChangePasswordModel
//            {
//                userId = userId,
//                CurrentPassword = currentpassword,
//                NewPassword = updatepassword
//            }));
//        }
//    }


//    public class UserConntextFixture : IDisposable
//    {
//        public SocietyCareContext Context { get; }
//        public UserConntextFixture()
//        {
//            Context = ContextProvider.GetContext();
//            Context.Database.EnsureDeleted();

//            var userRepo = new UsersRepository(Context);


//            userRepo.Add(new Users
//            {
//                UserName = "admin",
//                UserPassword =
//                                                       new List<UserPassword> { new UserPassword { Password = "admin" } }
//            });
//            userRepo.Add(new Users
//            {
//                UserName = "superuser",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "superuser" } }
//            });
//            userRepo.Add(new Users
//            {
//                UserName = "deleteuser",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "deleteuser" } }
//            });
//            userRepo.Add(new Users
//            {
//                UserName = "updateuser",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "updateuser" } }
//            });
//            userRepo.Add(new Users
//            {
//                UserName = "user5",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "user5" } }
//            });


//            Context.SaveChanges();
//            Context.DetachGraph();

//        }

//        public void Dispose()
//        {
//        }


//    }
//}
