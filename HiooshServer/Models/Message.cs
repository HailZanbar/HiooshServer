namespace HiooshServer.Models
{
    public class Message
    {
        public Message(int _id, string _type, string _content, string _from, string _to, string _time, string _date)
        {
            id = _id;
            type = _type;
            content = _content;
            from = _from;
            to = _to;
            time = _time;
            date = _date;
        }
        public int id { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string time { get; set; }
        public string date { get; set; }
    }
}
