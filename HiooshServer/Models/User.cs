namespace HiooshServer.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string? Image { get; set; }
        public List<Contact>? Contacts { get; set; }

    }
}
