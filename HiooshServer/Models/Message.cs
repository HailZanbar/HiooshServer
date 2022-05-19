namespace HiooshServer.Models
{
    public class Message
    {
        public Message(int _id, string _content, bool _sent, string _created ,string _type)
        {
            id = _id;
            content = _content;
            sent = _sent;
            created = _created;
            type = _type;
        }
        public int id { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public bool sent { get; set; }
        public string created { get; set; }
    }
}
