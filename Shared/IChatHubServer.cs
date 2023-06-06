using BlazorChat.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChat.Shared
{
    public interface IChatHubServer
    {
        Task SetUserOnline(UserDto user);

    }
}
