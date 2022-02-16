using System.ServiceProcess;
using System.Threading;

namespace FolderLoggerService
{
    public partial class LoggerService : ServiceBase
    {
        private Logger _logger;
        public LoggerService()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _logger = new Logger();
            var loggerThread = new Thread(_logger.Start);
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            _logger.Stop();
            Thread.Sleep(1000);
        }
    }

    
}
