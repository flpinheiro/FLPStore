﻿namespace FLPStore.Core.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(string username);
}
