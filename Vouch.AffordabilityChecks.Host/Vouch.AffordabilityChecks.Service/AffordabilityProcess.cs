using System.Collections.Generic;
using Vouch.AffordabilityChecks.Service.Models;

namespace Vouch.AffordabilityChecks.Service
{
    public class AffordabilityProcess : IAffordabilityProcess
    {
        private readonly IFileService fileService;
        private readonly IAffordabilityService affordabilityService;
        public AffordabilityProcess(IFileService fileService, IAffordabilityService affordabilityService)
        {
            this.fileService = fileService;
            this.affordabilityService = affordabilityService;
        }
        public List<Property> Run(string filesLocation)
        {
            var feed  = fileService.ReadFeed(filesLocation);

            var props = affordabilityService.Check(feed.BankStatements, feed.Properties);

            return props;
        }
    }
}
