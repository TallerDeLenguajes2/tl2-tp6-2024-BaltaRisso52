public class InMemoryUserRepositury
{
    private readonly List<User> users;

    public InMemoryUserRepositury()
    {
        users = new List<User>{
        new User { Id = 1, Username = "admin", Password = "password123", acessLevel = AcessLevel.admin},
        new User { Id = 2, Username = "manager", Password = "password123", acessLevel = AcessLevel.admin},
        new User { Id = 3, Username = "employee", Password = "password123", acessLevel = AcessLevel.admin},
        new User { Id = 4, Username = "guest", Password = "password123", acessLevel = AcessLevel.admin} };
    }

    public User GetUser(string username, string password){
        return users.Where(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(password, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    }
}