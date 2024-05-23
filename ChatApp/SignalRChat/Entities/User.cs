namespace SignalRChat.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<long> Chats { get; set; }  
    }
}
