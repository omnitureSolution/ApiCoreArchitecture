using Omniture.Core.Interfaces.Services.Account;
using Omniture.Core.Interfaces.Services.Masters;
using Omniture.Core.Model.Account;
using Omniture.Db;
using Omniture.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocietyCareAPI.Controllers.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyCareAPI.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : APIBaseController
    {
        private readonly IUserService _users;
        private readonly IFileUpload _fileUpload;
        private readonly IUserInfo _userInfo;
        private readonly IUnitOfWork _uow;
        private readonly IUser _userRepo;
        public LoginController(IUserService users, IFileUpload fileUpload,
               IUnitOfWork uow,
                IUser userRepo,
            IUserInfo userInfo)
        {
            _uow = uow;
            _users = users;
            _userInfo = userInfo;
            _fileUpload = fileUpload;
            _userRepo = userRepo;
        }
        [HttpPost]
        public IActionResult post([FromBody]LoginModel request)
        {
            return Ok(_users.Login(request));
        }
        [HttpPost]
        [Route("Refresh")]
        public IActionResult Refresh([FromBody] RefreshTokenModel token)
        {
            return Ok(_users.Refresh(token.Accesstoken, token.Refreshtoken,1));
        }
         
        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromBody]ChangePasswordModel changePassword)
        {
            return Ok(_users.ChangePassword(changePassword));
        }

        [HttpPost]
        [Route("ImageUpload"), Authorize]
        public async Task<IActionResult> ImageUpload()
        {
            if (!Request.HasFormContentType)
                return BadRequest();
            var formFile = Request.Form.Files.ToList().FirstOrDefault();
            string path = await _fileUpload.Upload(formFile);
            _userRepo.UpdateImage(_userInfo.UserId, path);
            await _uow.SaveAsync();
            return Ok();
        }
    }
}