namespace Vouch.AffordabilityChecks.Service.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int RentPerMonthPence { get; set; }

        // Public constructor.
        public Property(int id, string address, int rentPerMonthPence)
        {
            Id = id;
            Address = address;
            RentPerMonthPence = rentPerMonthPence;
        }
    }
}
