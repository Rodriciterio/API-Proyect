﻿namespace PadelClubSystem.Abstractions
{
    public interface IDbContext<T> : IDbOperation<T> where T : class
    {

    }
}
