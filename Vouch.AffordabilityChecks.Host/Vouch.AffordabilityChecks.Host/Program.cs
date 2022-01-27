using System.IO;
using Unity;
using Vouch.AffordabilityChecks.Service;

namespace Vouch.AffordabilityChecks.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //Summary
            //Implemented unity for dependency injections
            //Applied SOLID principles, where separation of concerns are applied by separating file service, affordabbility service and the process to run
            //Created interfaces whereever required
            //Provided unit test coverage for all the services


            //register dependencies using unity
            var iuContainer = Register();

            //resolve dependencies
            var affordabilityProcess = iuContainer.Resolve<IAffordabilityProcess>();

            var affordableProps = affordabilityProcess.Run(Directory.GetCurrentDirectory() + "/files");

        }

        private static IUnityContainer Register()
        {
            IUnityContainer iuContainer = new UnityContainer();

            iuContainer.RegisterType<IFileService, FileService>();
            iuContainer.RegisterType<IAffordabilityService, AffordabilityService>();
            iuContainer.RegisterType<IAffordabilityProcess, AffordabilityProcess>();

            return iuContainer;
        }
    }
}
