namespace HiooshServer.Models
{
    public class Message
    {
        public Message(int id, string type, string content, string own, string time, string date)
        {
            Id = id;
            Type = type;
            Content = content;
            Own = own;
            Time = time;
            Date = date;
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string Own { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }
}
