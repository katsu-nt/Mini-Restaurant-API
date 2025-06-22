using System;
using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBird { get; set; }
    public string? Nationality { get; set; }
}
