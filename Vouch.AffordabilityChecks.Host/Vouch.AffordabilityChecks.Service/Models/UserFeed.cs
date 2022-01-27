using System.Collections.Generic;
namespace Vouch.AffordabilityChecks.Service.Models
{
    public class UserFeed
    {
        public List<Property> Properties { get; set; }
        public List<BankStatement> BankStatements { get; set; }
    }
}
