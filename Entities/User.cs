namespace Entities;

public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public int UserId { get; set; }
    
    // Constructor to initialize all properties
    public User(int userId, string userName, string password)
    {
        UserId = userId;
        UserName = userName;
        Password = password;
    }
    
    public User()
    {
        UserId = 1;
        UserName = "dummyuser123";
        Password = "dummypassword";
    }
}