using System.Collections.Generic;
using Vouch.AffordabilityChecks.Service.Models;


namespace Vouch.AffordabilityChecks.Service
{
    public interface IAffordabilityProcess
    {
        List<Property> Run(string filesLocation);
    }
}
