namespace JWT_Authorization.Models;

public class UserDTO
{
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}
