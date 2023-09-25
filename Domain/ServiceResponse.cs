
namespace Domain
{
    public class ServiceResponse
    {
        public bool response { get; set; }
        public string message { get; set; }
    }

    public class ServiceResponseTicket
    {
        public bool response { get; set; }
        public string message { get; set; }
        public ticketCreado ticket { get; set; }
    }
}
