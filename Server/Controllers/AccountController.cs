﻿using BlazorChat.Server.Data;
using BlazorChat.Server.Data.Entities;
using BlazorChat.Server.Hubs;
using BlazorChat.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ChatContext _chatContext;
        private readonly TokenService _tokenService;
        private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;

        public AccountController(ChatContext chatContext, TokenService tokenService, IHubContext<ChatHub, IChatHubClient> hubContext) 
        {
            _chatContext = chatContext;
            _tokenService = tokenService;
            _hubContext = hubContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            var usernameExist = await _chatContext.Users.AsNoTracking().AnyAsync(u => u.UserName == dto.UserName, cancellationToken);
            if (usernameExist) 
            {
                return BadRequest($"{nameof(dto.UserName)} already exist");

            }
            var user = new User
            {
                UserName = dto.UserName,
                AddedOn = DateTime.Now,
                Name = dto.Name,
                Password = dto.Password
            };

            await _chatContext.Users.AddAsync(user, cancellationToken);

            await _chatContext.SaveChangesAsync(cancellationToken);

           await _hubContext.Clients.All.UserConnected(new UserDto(user.Id, user.Name));
           
            return Ok(GenerateToken(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            var user = await _chatContext.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName && u.Password == dto.Password, cancellationToken);
            if (user is null)
            {
                return BadRequest("Incorrect login or password");
            }
            return Ok(GenerateToken(user));


        }

        private AuthResponseDto GenerateToken(User user)
        {
           var token =  _tokenService.GenerateJWT(user);
            return new AuthResponseDto(new UserDto(user.Id, user.Name), token);
        }
    }
    }
       