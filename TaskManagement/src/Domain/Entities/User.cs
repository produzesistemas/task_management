﻿namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public User(string name, string role)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Role = role;
    }
}
