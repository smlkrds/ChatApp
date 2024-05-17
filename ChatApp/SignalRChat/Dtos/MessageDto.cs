namespace SignalRChat.Dtos
{
    public record MessageDto
    {
        public string Sender { get; set; }
        public string MessageContent { get; set; }
    }
}
