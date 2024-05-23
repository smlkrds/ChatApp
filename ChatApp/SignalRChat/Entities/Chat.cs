namespace SignalRChat.Entities
{
    public class Chat
    {
        public long Id { get; set; }
        public List<Message> Messages { get; set; }
    }
}
