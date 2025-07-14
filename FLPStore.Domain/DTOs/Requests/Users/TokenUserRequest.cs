using FLPStore.CrossCutting.DTOs.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLPStore.Domain.DTOs.Requests.Users;

public record TokenUserRequest : ITokenUserRequest
{
    public string Email { get; set; }

    public TokenUserRequest(string email)
    {
        Email = email;
    }
}
