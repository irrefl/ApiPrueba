namespace API.Models;

public record User(string userName, string password)
{
    public int IsActive { get; set; }
}
