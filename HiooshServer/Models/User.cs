namespace HiooshServer.Models
{
    public class User
    {
        public User (string id, string password, string nickname, string image)
        {
            Id = id;   
            Password = password;
            Nickname = nickname;
            Image = image;
            Contacts = new List<Contact> ();
            Server = "localhost:5034";
        }
        public string Id { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Nickname { get; set; }
        public string? Image { get; set; }
        public List<Contact>? Contacts { get; set; }

    }
}
