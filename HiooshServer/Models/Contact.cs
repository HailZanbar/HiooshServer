namespace HiooshServer.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string image { get; set; }
        public List<Message> Chat { get; set; }

    }
}
