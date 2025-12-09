
// entity nekad i model, cesto tabela u bazi
namespace API.Entities; // ponekad fizicki gdje se fajl nalazi, a ane mora uopste
// DbContext class - bridge between DB and Entity classes
public class AppUser
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string DisplayName{ get; set; }

    public required string Email { get; set; }
}
