namespace Shared.Data.DTOs
{
    public class SMSDto
    {
        public string From { get; set; }
        public string[] To { get; set; }
        public string Content { get; set; }
    }
}
