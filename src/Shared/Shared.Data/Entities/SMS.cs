using Fonedynamics.Data.Enums;

namespace Shared.Data.Entities
{
    public class SMS
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public Status? Status { get; set; }
    }
}
