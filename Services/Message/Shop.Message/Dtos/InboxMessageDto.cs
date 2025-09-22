namespace Shop.Message.Dtos
{
    public class InboxMessageDto
    {
        public int UserMessageID { get; set; }

        public string MessageSenderID { get; set; }

        public string MessageReceiverID { get; set; }

        public string MessageSubject { get; set; }

        public string MessageDetail { get; set; }

        public DateTime MessageDate { get; set; }

        public bool MessageIsRead { get; set; }
    }
}
