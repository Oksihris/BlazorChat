using BlazorChat.Server.Data;
using BlazorChat.Server.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorChat.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly ChatContext _chatContext;

        public UsersController(ChatContext chatContext)
        {
            _chatContext = chatContext;
           
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers() =>
            await _chatContext.Users.AsNoTracking().Where(u => u.Id != UserId)
            .Select(u => new UserDto(u.Id, u.Name))
            .ToListAsync();
    }
}
       