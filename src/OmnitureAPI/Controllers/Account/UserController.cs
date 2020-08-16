using AutoMapper;
using Omniture.Core.Interfaces.Services.Account;
using Omniture.Core.Model.Account;
using Omniture.Db; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocietyCareAPI.Filters;
using System.Threading.Tasks;
using Omniture.Db.Entity.Notification;

namespace SocietyCareAPI.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IUser _userRepository;
        private IMapper _mapper;
        private IUnitOfWork _uow;
        private readonly IUserService _userService;
        public UserController(IUser userRepository, IUnitOfWork uow, IMapper mapper,
            IUserService userService)
        {
            _userRepository = userRepository;
            _uow = uow;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("{id}", Name = "user"), TransactionRequired, Authorize]
        public IActionResult Get(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
                return NotFound();
            return Ok(_mapper.Map<UsersViewModel>(user));
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost, TransactionRequired, Authorize]
        public async Task<IActionResult> Post([FromBody] UsersViewModel user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userRepository.CreateUser(userEntity);
            await _uow.SaveAsync();
            return CreatedAtRoute("user", new { id = userEntity.UserId }, null);
        }
               

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] UsersViewModel user)
        {
            var userEntity = _mapper.Map<User>(user);
            userEntity.UserId = id;
            _userRepository.Update(userEntity);
            await _uow.SaveAsync();
            return Created("user", new { id = userEntity.UserId });
        }

        [HttpDelete("{id}"), TransactionRequired, Authorize]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            _userRepository.Delete(id);
            await _uow.SaveAsync();
            return NoContent();
        }

    }
}
