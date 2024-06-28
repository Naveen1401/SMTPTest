namespace SmtpMailApi.Models
{
    public class MailRequest
    {
        public required string ToEmail { get; set; }
        public string Subject { get; set; } = "SMTP Test Mail";
        public string Body { get; set; } = "This is a test mail. Please don't reply to this mail";
        public required string FromEmail { get; set; }
        public required string SmtpServer { get; set; }
        public int Port { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool UseSSl { get; set; }
    }
}