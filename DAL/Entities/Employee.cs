﻿using DAL.Enums;

namespace DAL.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? Patronymic { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public IEnumerable<Role> Roles { get; set; }
    public string Password { get; set; }
    public Guid Salt { get; set; }
}