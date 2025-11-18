namespace AccountsssSupport.API.Models
{
    public class EmailDetailResponse
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool HasAttachments { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
    }
}