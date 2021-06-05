namespace Attenderizer.Models
{
    public interface ILoginModel
    {
        string FirstName { get; set; }
        string Id { get; set; }
        bool IsAbsent { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        int Username { get; set; }
    }
}