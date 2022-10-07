namespace Fonedynamics.API.Models.ViewModels.SMS
{
    public class SMSViewModel
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Status { get; set; }
    }
}
