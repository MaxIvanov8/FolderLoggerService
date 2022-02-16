using System.ServiceProcess;

namespace FolderLoggerService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new LoggerService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
