using System.Collections.Generic;
using Vouch.AffordabilityChecks.Service.Models;


namespace Vouch.AffordabilityChecks.Service
{
    public interface IAffordabilityService
    {
        List<Property> Check(List<BankStatement> statements, List<Property> properties);
    }
}
