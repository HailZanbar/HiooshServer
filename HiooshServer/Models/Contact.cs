namespace HiooshServer.Models
{
    public class Contact
    {
        public Contact(string _id, string _name, string _server)
        {
            id = _id;
            name = _name; 
            server = _server;
            last = null;
            lastdate = null;
            image = null;
            chat = new List<Message>();
        }
        public string id { get; set; }
        public string name { get; set; }
        public string server { get; set; }
        public string? last { get; set; }
        public string? lastdate { get; set; }
        public string? image { get; set; }
        public List<Message> chat { get; set; }
    }
}
