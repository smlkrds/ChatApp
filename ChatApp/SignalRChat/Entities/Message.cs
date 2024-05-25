namespace SignalRChat.Entities
{
    public class Message
    {
        public long Id { get; set; }
        public string SenderUserName { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
