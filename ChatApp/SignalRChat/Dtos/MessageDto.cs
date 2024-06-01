namespace SignalRChat.Dtos
{
    public record MessageDto
    {
        public string SenderUserName { get; set; }
        public string Content { get; set; }
    }
}
