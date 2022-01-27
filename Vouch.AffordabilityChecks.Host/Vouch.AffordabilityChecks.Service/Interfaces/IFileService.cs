using Vouch.AffordabilityChecks.Service.Models;


namespace Vouch.AffordabilityChecks.Service
{
    public interface IFileService
    {
        UserFeed ReadFeed(string path);
    }
}
