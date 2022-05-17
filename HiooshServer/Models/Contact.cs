namespace HiooshServer.Models
{
    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string server { get; set; }
        public string last { get; set; }
        public string lastdate { get; set; }
        public string image { get; set; }
        public List<Message> chat { get; set; }

    }
}
