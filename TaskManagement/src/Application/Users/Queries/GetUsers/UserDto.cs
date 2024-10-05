using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Users.Queries.GetUsers;

public class UserDto : IMapFrom<User>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
